using eVideoPrime.APIs.FIlters;
using eVideoPrime.APIs.Helpers;
using eVideoPrime.Core.Entities;
using eVideoPrime.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace eVideoPrime.APIs.Controllers
{

    [CustomAuthorize(Roles = "Admin")]
    [EnableCors("AllowAll")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        IMovieService _movieService;
        IFileHelper _fileHelper;
        public MovieController(IMovieService movieService, IFileHelper fileHelper)
        {
            _movieService = movieService;
            _fileHelper = fileHelper;
        }

        [HttpGet]
        public IEnumerable<Movie> GetAll()
        {
            return _movieService.GetAllMovies();
        }

        [HttpGet("{id}")]
        public Movie Get(int id)
        {
            return _movieService.Find(id);
        }

        [HttpPost]
        public IActionResult Add(Movie model)
        {
            try
            {
                int id = _movieService.AddMovie(model);
                return StatusCode(StatusCodes.Status201Created, id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Movie model)
        {
            try
            {
                if (id != model.Id)
                    return BadRequest();

                _movieService.Update(model);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Movie movie = _movieService.Find(id);
                if (movie != null)
                {
                    _fileHelper.DeleteFile(movie.Thumbnail);
                    _fileHelper.DeleteFile(movie.Banner);
                    _movieService.Remove(movie);
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
