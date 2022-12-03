using MovieAPI.Entities;

namespace MovieAPI.Services
{
    public interface IRepository
    {
        Task<List<Genre>> GetAllGenres();
        Genre GetGenreById(int Id);
    }
}
