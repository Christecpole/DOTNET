using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol.Core.Types;
using TP_asp.netMVC.Extensions;
using TP_asp.netMVC.Repositories;
using TP_asp.netMVC.ViewModels;

namespace TP_asp.netMVC.Services
{
    public class ProduitService : IProduitService
    {
        private readonly IProduitRepository _repository;

        public ProduitService(IProduitRepository repository)
        {
            _repository = repository;
        }

        public bool Create(ProduitFormViewModel viewModel)
        {
            var produit = viewModel.ToModel();

            produit.DateCreation = DateTime.Now;
            _repository.Add(produit);

            return true;
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public IEnumerable<ProduitListItemViewModel> GetAll()
        {
            var produits = _repository.GetAll();
            
            return produits.Select(p => p.ToListItem());
        }

        public ProduitDetailsViewModel? GetById(int id)
        {
            var produit = _repository.GetById(id);

            if(produit == null)
            {
                return null;
            }

            return produit.ToDetails();
        }

        public ProduitFormViewModel GetFormViewModel(int? id)
        {
            if (id == null)
            {
                return new ProduitFormViewModel
                {
                    CategoriesSelectList = GetCategoriesSelectList()
                };
            }

            var produit = _repository.GetById(id.Value);

            if (produit == null)
            {
                return new ProduitFormViewModel
                {
                    CategoriesSelectList = GetCategoriesSelectList()
                };
            }

            var viewModel = produit.ToFormViewModel();
            viewModel.CategoriesSelectList = GetCategoriesSelectList(produit.CategorieId);

            return viewModel;
        }

        public bool Update(int id, ProduitFormViewModel viewModel)
        {
            var produitExistant = _repository.GetById(id);
            if (produitExistant == null)
                return false;

            var produit = viewModel.ToModel();

            produit.Id = id;
            produit.DateCreation = produitExistant.DateCreation;

            _repository.Update(produit);

            return true;
        }


        private SelectList? GetCategoriesSelectList(int? selectedValue = null)
        {
            var categories = _repository.GetAllCategories();
            return new SelectList(categories, "Id", "Nom", selectedValue);
        }
    }
}
