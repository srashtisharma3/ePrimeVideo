using eVideoPrime.Core.Entities;
using eVideoPrime.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace eVideoPrime.APIs.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        IMovieService _movieService;
        private IMemoryCache _cache;
        ILogger<CatalogController> _logger;
        public CatalogController(IMovieService movieService, ILogger<CatalogController> logger, IMemoryCache cache)
        {
            _movieService = movieService;
            _cache = cache;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Movie> GetAll()
        {
            try
            {
                //for in-memory cache
                string key = "catalog";
                var items = _cache.GetOrCreate(key, entry =>
                {
                    entry.AbsoluteExpiration = DateTime.Now.AddHours(12);
                    entry.SlidingExpiration = TimeSpan.FromMinutes(15);
                    return _movieService.GetAllMovies();
                });
                return items;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return null;
            }
        }

        [HttpGet("{id}")]
        public Movie Get(int id)
        {
            return _movieService.GetMovie(id);
        }
    }
}
