using Microsoft.EntityFrameworkCore;

namespace REST_API_Example.Models
{
    public class ColorContext : DbContext
    {
        public ColorContext(DbContextOptions<ColorContext> options) : base(options)
        {}

        public DbSet<Color> ColorItems { get; set; }
    }
}