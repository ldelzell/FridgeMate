using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controlers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageSaveAPI : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpClientFactory _httpClientFactory;

        public ImageSaveAPI(IWebHostEnvironment webHostEnvironment, IHttpClientFactory httpClientFactory)
        {
            _webHostEnvironment = webHostEnvironment;
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file == null || file.Length <= 0)
            {
                return BadRequest("Invalid file.");
            }

            // Get the wwwroot path
            var webRootPath = _webHostEnvironment.WebRootPath;

            // Generate a unique filename or use the original filename
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            // Combine the wwwroot path with the filename
            var filePath = Path.Combine(webRootPath, "Pictures", fileName);

            // Save the file
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            // Return the relative path of the saved file
            return Ok(Path.Combine("Pictures", fileName));
        }

    }
}
