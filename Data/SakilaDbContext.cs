using Microsoft.EntityFrameworkCore;
using ASPMVC.Models; 

namespace ASPMVC.Data 
{
    public class SakilaDbContext : DbContext
    {
        public SakilaDbContext(DbContextOptions<SakilaDbContext> options)
            : base(options)
        {
        }

        public DbSet<actor> actor { get; set; }
        public DbSet<film> film { get; set; }
        // Add more DbSets for other tables
    }
}
