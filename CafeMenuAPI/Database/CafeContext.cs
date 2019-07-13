using Microsoft.EntityFrameworkCore;
using CafeMenuAPI.Models;
namespace CafeMenuAPI.Database
{
    public class CafeContext : DbContext
    {
        public CafeContext(DbContextOptions<CafeContext> options)
            : base(options)
        {

        }

        public DbSet<Food> Foods { get; set; }
    }
}
