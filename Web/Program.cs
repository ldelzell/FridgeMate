        using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => {
    options.LoginPath = new PathString("/LogIn");
    options.AccessDeniedPath = new PathString("/AccessDenied");
}
);
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddRazorPages();

var app = builder.Build();
app.MapPost("/images", async (HttpRequest request, HttpContext context) =>
{
    IFormFile? file = context.Request.Form.Files.FirstOrDefault();
    if (file != null && file.Length > 0)
    {
        // Generate name
        //Guid to not rewrite the files
        string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

        // Directory
        string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");

        if (!Directory.Exists(uploadPath))
        {
            Directory.CreateDirectory(uploadPath);
        }
        // File Path
        string filePath = Path.Combine(uploadPath, uniqueFileName);

        // Save the uploaded image to the specified path
        using (FileStream stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        context.Response.StatusCode = 200;

        string relativePath = Path.Combine("Images", uniqueFileName);

        return relativePath;
    }
    else
    {
        context.Response.StatusCode = 400;
        return "Bad Request: No file received.";
    }
});

app.MapGet("/Images", async (HttpContext context) => 
{
    IFormFile? file;
    string getLocalPath = context.Request.Path.ToString();

    string relativePath = getLocalPath.Replace("http://localhost:5287", "");

    string absolutePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", relativePath);

    using (FileStream stream = new FileStream(absolutePath, FileMode.Open))
    {
        return stream;
    }
});
app.MapDelete("/Images/{fileName}", async (HttpRequest request, HttpContext context) =>
{
    string fileName = (string)context.Request.RouteValues["fileName"];
    //Get the relative path
    string filePath = Path.Combine("wwwroot/Images", fileName);

    if (File.Exists(filePath))
    {
        try
        {
            File.Delete(filePath);
            context.Response.StatusCode = 200;
            return "File deleted successfully.";
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            return $"Internal Server Error: {ex.Message}";
        }
    }
    else
    {
        context.Response.StatusCode = 404;
        return "File not found.";
    }
});


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
