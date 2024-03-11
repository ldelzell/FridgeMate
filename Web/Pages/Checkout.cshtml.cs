using BLL.Managers;
using BLL.Models;
using DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using Web.ViewModels;

namespace Web.Pages
{
    public class CheckoutModel : PageModel
    {
        private ProductManager productManager;
        public OrderNumberGenerator randomNumberGenerator;
        private UserManager userManager;
        private CheckoutManager checkoutManager;
        public List<Product> BasketItems { get; set; } = new();
        public string OrderNumber { get; set; }
        public double ProductSum { get; set; }
        public double ShippingPrice { get; set; }
        public double TotalSum { get; set; }
        public string CheckoutFirstName { get; set; }
        public string CheckoutLastName { get; set; }
        public string CheckoutUsername { get; set; }
        public string CheckoutEmail { get; set; }
        

        [BindProperty]
        public CheckoutViewModel CheckoutViewModel { get; set;}
        [BindProperty]
        public UserViewModel UserViewModel { get; set; }
        public CheckoutModel()
        {
            productManager = new ProductManager(new ProductDataAccess());
            randomNumberGenerator = new OrderNumberGenerator();
            userManager = new UserManager(new UserDataAccess());
            checkoutManager = new CheckoutManager(new CheckoutDataAccess());
        }
        public IActionResult OnGet()
        {
            //getting user data
            if (ModelState.IsValid) {
                try { 
                    if (!User.Identity.IsAuthenticated)
                    {
                        return RedirectToPage("LogIn");
                    }
                    var userId = User.FindFirst("id");
                    if (userId == null)
                    {
                        return RedirectToPage("LogIn");
                    }
                    else
                    {
                        int id = int.Parse(userId.Value);
                        var user = userManager.GetUserById(id);
                        UserViewModel = new(
                            user.FirstName,
                            user.LastName,
                            user.PhoneNumber,
                            user.Username,
                            user.Email,
                            user.Password,
                            user.ImagePath
                        );
                    }
                    CheckoutFirstName = UserViewModel.FirstName;
                    CheckoutLastName = UserViewModel.LastName;
                    CheckoutUsername = UserViewModel.Username;
                    CheckoutEmail = UserViewModel.Email;
                    //GETTING BASKET ITEMS
                    var basketItemIds = Request.Cookies["basket"]?.Split(',')
                                        .Where(itemId => !string.IsNullOrWhiteSpace(itemId))
                                        .Select(int.Parse)
                                        .ToList() ?? new List<int>();

                    var validBasketItemIds = basketItemIds
                                            .Where(itemId => itemId != 0)
                                            .ToList();
                    var basketItems = validBasketItemIds
                                      .Select(itemId => productManager.GetProductById(itemId))
                                      .ToList();

                    BasketItems = basketItems;

                    Response.Cookies.Append("basket", string.Join(",", validBasketItemIds), new CookieOptions
                    {
                        Expires = DateTimeOffset.Now.AddDays(1),
                        Path = "/"
                    });

                    OrderNumber = randomNumberGenerator.GenerateOrderNumber();
                    ProductSum = basketItems.Sum(item => item.Price);
                    ShippingPrice = 12.99;
                    TotalSum = Math.Round(ProductSum + ShippingPrice, 2);
                    return Page();
                }
                catch (Exception ex){
                    string errorMessage = $"Error occurred while uploading image: {ex.Message}";
                    ViewData["ErrorMessage"] = errorMessage;
                    return Page();
                }
            }
            return Page();
        }
        public IActionResult OnPost() {
            var userIdClaim = User.FindFirst("id");
            if (userIdClaim == null)
            {
                return RedirectToPage("/LogIn");
            }


            //var checkoutItemIds = Request.Cookies["basket"]?.Split(',')
            //                            .Where(itemId => !string.IsNullOrWhiteSpace(itemId))
            //                            .Select(int.Parse)
            //                            .ToList() ?? new List<int>();

            //var checkoutvalidBasketItemIds = checkoutItemIds
            //                        .Where(itemId => itemId != 0)
            //                        .ToList();
            //var checkoutItems = checkoutvalidBasketItemIds
            //                  .Select(itemId => productManager.GetProductById(itemId))
            //                  .ToList();

            //BasketItems = checkoutItems;

            //Response.Cookies.Append("basket", string.Join(",", checkoutvalidBasketItemIds), new CookieOptions
            //{
            //    Expires = DateTimeOffset.Now.AddDays(1),
            //    Path = "/"
            //});

            //OrderNumber = randomNumberGenerator.GenerateOrderNumber();
            //ProductSum = BasketItems.Sum(item => item.Price);
            //ShippingPrice = 12.99;
            //TotalSum = Math.Round(ProductSum + ShippingPrice, 2);



            if (ModelState.IsValid) {
                try
                {
                    var basketItemIds = Request.Cookies["basket"]?.Split(',')
                                .Where(itemId => !string.IsNullOrWhiteSpace(itemId))
                                .Select(int.Parse)
                                .ToList() ?? new List<int>();

                    var validBasketItemIds = basketItemIds
                                            .Where(itemId => itemId != 0)
                                            .ToList();
                    var basketItems = validBasketItemIds
                                      .Select(itemId => productManager.GetProductById(itemId))
                                      .ToList();

                    List<Product> BasketItems = basketItems;
                    List<string> items = new List<string>();
                    Response.Cookies.Append("basket", string.Join(",", validBasketItemIds), new CookieOptions
                    {
                        Expires = DateTimeOffset.Now.AddDays(1),
                        Path = "/"
                    });
                    foreach (var basketItem in BasketItems) {
                         items.Add(basketItem.ToString());
                    }
                    int userId = int.Parse(userIdClaim.Value);

                    OrderNumber = randomNumberGenerator.GenerateOrderNumber();
                    string basketItemsString = string.Join(", ", items);
                    Checkout checkout = new Checkout(0,CheckoutViewModel.FirstName, CheckoutViewModel.LastName, CheckoutViewModel.Username, CheckoutViewModel.Email, 
                        CheckoutViewModel.Adress, CheckoutViewModel.Country, CheckoutViewModel.ZipCode, CheckoutViewModel.CardHolderName, 
                        CheckoutViewModel.CardNumber, CheckoutViewModel.CardExperationDate, CheckoutViewModel.CVV, userId, basketItemsString, OrderNumber);

                    //string items = BasketItems.ToString();
                    if (checkoutManager.CreateCheckout(checkout)) {
                        TempData["SuccessMessage"] = "Checkout successful!";

                        string emailSubject = "Order Confirmation";

                        string logoUrl = Url.Content("http://localhost:5287/wwwroot/Pictures/Logo1.jpg");
                        string emailBody = $@"
                        <div style='font-family: Arial, sans-serif; background-color: #f4f4f4; padding: 20px; border-radius: 10px;'>
                            <div style='text-align: right;'>
                                <img src='{logoUrl}' alt='Company Logo' style='max-width: 100px; width: 100%; height: auto;' />
                            </div>
                            <h2 style='color: #333; text-align: center; margin-bottom: 20px;'>Email Confirmation for Your Order</h2>
                            <p style='color: #333;'>
                                Thank you for purchasing from FRIDGEMATE! 
                                Your Order Number: {OrderNumber}
                            </p>
                            <p style='color: #333;'>

                                <strong>Products:</strong> {basketItemsString}
                            </p>
                            <p style='color: #333; margin-top: 20px;'>
                                We look forward to seeing you again!.
                            </p>
                            <p style='color: #008000; font-weight: bold; margin-top: 20px;'>
                                Best Regards,
                                <br/>
                                FRIDGEMATE
                            </p>
                        </div>";

                        SendEmail(CheckoutViewModel.Email, emailSubject, emailBody);
                        //Delete Basket items
                        if (Request.Cookies.ContainsKey("basket"))
                        {
                            Response.Cookies.Delete("basket", new CookieOptions
                            {
                                Expires = DateTimeOffset.Now.AddDays(-1),
                                Path = "/"
                            });
                        }
                    }
                }
                catch (Exception ex){
                    string errorMessage = $"Error occurred while uploading image: {ex.Message}";
                    ViewData["ErrorMessage"] = errorMessage;
                    return Page();
                }
            }
            return Page();
        }
        private void SendEmail(string recipientEmail, string subject, string body)
        {
            try
            {
                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"))
                {
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new NetworkCredential("ldelzell17@gmail.com", "lguo rgyq iqha mppx");
                    smtpClient.EnableSsl = true;

                    using (MailMessage mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress("your-email@example.com");
                        mailMessage.To.Add(recipientEmail);
                        mailMessage.Subject = subject;

                        // Use HTML formatting for the email body
                        mailMessage.Body = $"<html><body>{body}</body></html>";
                        mailMessage.IsBodyHtml = true;

                        smtpClient.Send(mailMessage);
                    }
                }
            }
            catch (SmtpException ex)
            {
                Console.WriteLine("SmtpException: " + ex.Message);
                throw;
            }
        }
    }
}
