using eVideoPrime.Core.Entities;
using eVideoPrime.Core.Interfaces;
using eVideoPrime.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace eVideoPrime.Services.Implementations
{
    public class MovieService : Service<Movie>, IMovieService
    {
        IMovieRepository _movieRepo;
        IConfiguration _config;
        public MovieService(IMovieRepository movieRepo, IConfiguration config) : base(movieRepo)
        {
            _movieRepo = movieRepo;
            _config = config;
        }
        public IEnumerable<Movie> GetAllMovies()
        {
            var data = _movieRepo.GetAll().Select(m => new Movie
            {
                Id = m.Id,
                Banner = _config["ImageBaseAddress"] + m.Banner,
                Thumbnail = _config["ImageBaseAddress"] + m.Thumbnail,
                Name = m.Name,
                CategoryId = m.CategoryId,
                Description = m.Description,
                Duration = m.Duration,
                Summary = m.Summary,
                VideoUrl = m.VideoUrl,
                Language = m.Language,
            });
            return data;
        }

        public Movie GetMovie(int id)
        {
            var data = _movieRepo.Find(id);
            data.Banner = _config["ImageBaseAddress"] + data.Banner;
            data.Thumbnail = _config["ImageBaseAddress"] + data.Thumbnail;
            return data;
        }
        public int AddMovie(Movie model)
        {
            _movieRepo.Add(model);
            _movieRepo.SaveChanges();
            return model.Id;
        }
        public void UpdateImages(Movie model)
        {
            _movieRepo.UpdateImages(model);
        }
    }
}
