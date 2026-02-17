using TP_asp.netMVC.ViewModels;

namespace TP_asp.netMVC.Services
{
    public interface IProduitService
    {
        IEnumerable<ProduitListItemViewModel> GetAll();

        ProduitDetailsViewModel? GetById(int id);

        ProduitFormViewModel GetFormViewModel(int? id);

        bool Create(ProduitFormViewModel viewModel);

        bool Update(int id, ProduitFormViewModel viewModel);

        bool Delete(int id);
    }
}
