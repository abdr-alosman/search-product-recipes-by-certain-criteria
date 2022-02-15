using Microsoft.EntityFrameworkCore;
using SearchProductCode.Models;

namespace SearchProductCode.Data
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
           : base(options)
        {
        }
        public DbSet<LogoRecip>? LogoRecips { get; set; }
    }
}
