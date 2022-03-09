using AquaZooAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AquaZooAPI.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<AquaZooEntity> AquaZooEntities { get; set; }

        public DbSet<LocationProgramEntity> LocationProgramEntities { get; set; }
    }
}
