using Microsoft.EntityFrameworkCore;
using MovieAPI.Entities;

namespace MovieAPI
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
    }
}
