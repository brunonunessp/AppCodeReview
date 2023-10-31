using AppCodeReview.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApi6.Models
{
    public class AppCodeReviewContext : DbContext
    {
        public AppCodeReviewContext(DbContextOptions<AppCodeReviewContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Payment> Payment { get; set; } = null!;
    }
}
