using Microsoft.EntityFrameworkCore;
using SpecieMicroService.Models;

namespace SpecieMicroService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Species> Species { get; set; }
}