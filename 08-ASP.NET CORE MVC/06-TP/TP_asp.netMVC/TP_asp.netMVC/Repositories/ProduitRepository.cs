using TP_asp.netMVC.Data;
using TP_asp.netMVC.Models;

namespace TP_asp.netMVC.Repositories
{
    public class ProduitRepository : IProduitRepository
    {
        public void Add(Produit produit)
        {
            if (DbFake.Produits.Any())
            {
                produit.Id = DbFake.Produits.Max(p => p.Id) + 1;
            }
            else
            {
                produit.Id = 1;
            }

            produit.Categorie = GetCategoryById(produit.CategorieId);
            DbFake.Produits.Add(produit);
        }

        public bool Delete(int id)
        {
            var produit = GetById(id);

            if (produit != null)
            {
                DbFake.Produits.Remove(produit);
                return true;
            }

            return false;
        }

        public List<Produit> GetAll()
        {
            return DbFake.Produits;
        }

        public List<Categorie> GetAllCategories()
        {
            return DbFake.Categories.ToList();
        }

        public Produit? GetById(int id)
        {
            return DbFake.Produits.FirstOrDefault(p => p.Id == id);
        }

        public Categorie? GetCategoryById(int id)
        {
            return DbFake.Categories.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Produit produit)
        {
            var index = DbFake.Produits.FindIndex(p => p.Id == produit.Id);

            if (index >= 0)
            {
                produit.Categorie = GetCategoryById(produit.CategorieId);
                DbFake.Produits[index] = produit;
            }
        }
    }
}
