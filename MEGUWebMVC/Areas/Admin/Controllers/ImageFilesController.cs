using Microsoft.AspNetCore.Mvc;
using MEGUWebMVC.Interfaces;
using System.Threading.Tasks;

namespace MEGUWebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ImageFilesController(IImageService imageService) : Controller
    {
        [HttpPost]
        public async Task<IActionResult> SaveImage([FromBody] string base64OrUrl)
            {
            if (string.IsNullOrEmpty(base64OrUrl))
            {
                return BadRequest("String cannot be null or empty.");
            }

            string result;

            if (!base64OrUrl.Contains("http"))
            {
                result = $"/images/400_{(await imageService.SaveImageFromBase64Async(base64OrUrl))}";
            }
            else
            {
                result = $"/images/400_{(await imageService.SaveImageFromUrlAsync(base64OrUrl))}";
            }

            return Ok(result);
        }

    }
}
