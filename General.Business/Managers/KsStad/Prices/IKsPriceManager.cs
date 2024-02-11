using General.Domain.ViewModels.KsStad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace General.Business.Managers.KsStad.Prices
{
    public interface IKsPriceManager
    {
        Task<KsPriceViewModel> Create(KsPriceViewModel payload);
        Task<IEnumerable<KsPriceViewModel>> GetAll();
        Task<bool> Delete(int Id);
        Task<KsPriceViewModel> GetById(int id);
    }
}
