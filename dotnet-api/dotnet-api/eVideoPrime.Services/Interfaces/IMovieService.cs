using eVideoPrime.Core.Entities;

namespace eVideoPrime.Services.Interfaces
{
    public interface IMovieService : IService<Movie>
    {
        IEnumerable<Movie> GetAllMovies();
        int AddMovie(Movie model);
        void UpdateImages(Movie model);
        Movie GetMovie(int id);
    }
}
