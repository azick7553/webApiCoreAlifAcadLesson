using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Db
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
    }
}