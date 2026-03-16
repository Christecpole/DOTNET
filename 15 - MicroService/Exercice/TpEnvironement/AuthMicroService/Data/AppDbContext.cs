using AuthMicroService.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthMicroService.Data;

public class AppDbContext : DbContext
{
    
    public AppDbContext (DbContextOptions<AppDbContext> option) : base(option){}
    
    public DbSet<Utilisateur> Utilisateurs { get; set; }
    
}