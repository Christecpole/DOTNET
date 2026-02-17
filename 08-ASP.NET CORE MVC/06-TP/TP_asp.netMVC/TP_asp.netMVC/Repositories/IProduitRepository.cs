using TP_asp.netMVC.Models;

namespace TP_asp.netMVC.Repositories
{
    public interface IProduitRepository
    {
        List<Produit> GetAll();

        Produit? GetById(int id);

        void Add(Produit produit);

        void Update(Produit produit);

        bool Delete(int id);

        List<Categorie> GetAllCategories();

        Categorie? GetCategoryById(int id);
    }
}
