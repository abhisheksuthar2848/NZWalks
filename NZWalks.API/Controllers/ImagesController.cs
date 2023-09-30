using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories.Interface;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        // post
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDTO request)
        {
            ValidateFileUpload(request);

            if (ModelState.IsValid)
            {
                // convert DTO to domain model
                var imageDomainModel = new Image
                {

                    File = request.File,
                    FileExtenction = Path.GetExtension(request.File.FileName),
                    FileName = request.File.FileName,
                    FileSizeInBytes = request.File.Length,
                    FileDescription = request.FileDescription
                };

               await imageRepository.Upload(imageDomainModel);

                return Ok(imageDomainModel);
            }

            return BadRequest(ModelState);
        }


        private void ValidateFileUpload(ImageUploadRequestDTO request)
        {
            var allowExtenction = new string[] { ".jpg", ".jpeg", ".png" };

            if (!allowExtenction.Contains(Path.GetExtension(request.File.FileName)))
            {
                ModelState.AddModelError("File", "Unsupported file extenction");
            }

            if (request.File.Length > 10485760)
            {
                ModelState.AddModelError("File", "File size more then 10MB, please upload small size file ");
            }
        }
    }
}

