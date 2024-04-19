using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using eVideoPrime.Services.Interfaces;
using eVideoPrime.Core.Entities;
using eVideoPrime.APIs.Helpers;

namespace eVideoPrime.Web.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        IMovieService _movieService;
        IFileHelper _fileHelper;
        public FileController(IMovieService movieService, IFileHelper fileHelper)
        {
            _movieService = movieService;
            _fileHelper = fileHelper;
        }

        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var formCollection = Request.ReadFormAsync().Result;
                var file = formCollection.Files.First();

                var dbPath = _fileHelper.UploadFile(file);
                return Ok(new { dbPath });

                //var folderPath = "wwwroot/images";
                //var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderPath);

                //if (file.Length > 0)
                //{
                //    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                //    var fullPath = Path.Combine(pathToSave, fileName);
                //    var dbPath = "/images/" + fileName;

                //    using (var stream = new FileStream(fullPath, FileMode.Create))
                //    {
                //        file.CopyTo(stream);
                //    }
                //    return Ok(new { dbPath });
                //}
                //else
                //{
                //    return BadRequest();
                //}
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpDelete]
        public IActionResult DeleteFile(string imageUrl)
        {
            _fileHelper.DeleteFile(imageUrl);
            return Ok();
        }

        [HttpPost]
        public IActionResult UploadFiles()
        {
            try
            {
                var formCollection = Request.ReadFormAsync().Result;
                int id = Convert.ToInt32(formCollection["id"]);

                //var folderPath = "wwwroot/images";
                //var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderPath);

                var files = formCollection.Files;
                List<string> filesPaths = new List<string>();
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        var filePath = _fileHelper.UploadFile(file);
                        filesPaths.Add(filePath);

                        //var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        //var fullPath = Path.Combine(pathToSave, fileName);
                        //var filePath = "/images/" + fileName;
                        //using (var stream = new FileStream(fullPath, FileMode.Create))
                        //{
                        //    file.CopyTo(stream);
                        //}
                    }
                }
                Movie model = new Movie { Id = id, Thumbnail = filesPaths[0], Banner = filesPaths[1] };
                _movieService.UpdateImages(model);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
