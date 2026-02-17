using Articles.Api.Data;
using Articles.Api.Models;
using Articles.Api_AvecBDD.Data;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Articles.Api.Repositories
{
    public class AuteurRepository : IAuteurRepository
    {
        private readonly ApplicationDbContext _context;

        public AuteurRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Auteur auteur)
        {
            _context.Add(auteur);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var auteur = await _context.Auteurs.FindAsync(id);

            if (auteur != null)
            {
                _context.Auteurs.Remove(auteur);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            // AnyAsync => Verifie si au moins un élément correspond
            // Plus rapide que getbyid car il ne charge pas l'objet entier
            return await _context.Auteurs.AnyAsync(a=> a.Id == id);
        }

        public async Task<List<Auteur>> GetAllAsync()
        {
            return await _context.Auteurs.ToListAsync();
            //return await _context.Auteurs.Include(a => a.Articles).ToListAsync();
        }

        public async Task<Auteur?> GetByIdAsync(int id)
        {
            return await _context.Auteurs.FirstOrDefaultAsync(a=>a.Id == id);
        }

        public async Task UpdateAsync(Auteur auteur)
        {
            _context.Auteurs.Update(auteur);
            await _context.SaveChangesAsync();
        }
    }
}
