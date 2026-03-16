using Microsoft.EntityFrameworkCore;
using ServiceVoyage.Models;
using System.Data.Common;

namespace ServiceVoyage.Data
{
    public class AppDbContext :DbContext
    {

        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Voyage> Voyages { get; set; }
    }
}
