using Microsoft.EntityFrameworkCore;
using vosplzen.sem2h1.Data.Model;

namespace vosplzen.sem2h1.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<SecurityToken> SecurityTokens { get; set; }
    }
}
