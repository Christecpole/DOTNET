using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TP_asp.netMVC.Extensions;
using TP_asp.netMVC.Models;
using TP_asp.netMVC.Services;
using TP_asp.netMVC.ViewModels;

namespace TP_asp.netMVC.Controllers
{
    public class ProduitController : Controller
    {
        private readonly IProduitService _service;

        public ProduitController(IProduitService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var viewModels = _service.GetAll();

            return View(viewModels.ToList());
        }

        public IActionResult Details(int id)
        {
            var viewModel = _service.GetById(id);

            if(viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = _service.GetFormViewModel(null);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProduitFormViewModel produitCree)
        {
            if (!ModelState.IsValid)
            {
                produitCree.CategoriesSelectList = _service.GetFormViewModel(null).CategoriesSelectList;
                return View(produitCree);
            }

            var success = _service.Create(produitCree);

            if (success)
            {
                TempData["Success"] = "Produit crée avec succès";
                return RedirectToAction("Index");
            }


            produitCree.CategoriesSelectList = _service.GetFormViewModel(null).CategoriesSelectList;
            return View(produitCree);

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _service.GetFormViewModel(id);

            if (viewModel.Id == null)
                return NotFound();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProduitFormViewModel produitModifie)
        {
            if (!ModelState.IsValid)
            {
                produitModifie.CategoriesSelectList = _service.GetFormViewModel(id).CategoriesSelectList;
                return View(produitModifie);
            }

            var success = _service.Update(id, produitModifie);

            if (success)
            {
                TempData["Success"] = "Produit modifié avec succès !";
                return RedirectToAction("Index");
            }

            return NotFound();

        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var success = _service.Delete(id);

            if (success)
            {
                TempData["Success"] = "Produit supprimé avec succès !";
                return RedirectToAction("Index");
            }

            return NotFound();
        }

    }
}
