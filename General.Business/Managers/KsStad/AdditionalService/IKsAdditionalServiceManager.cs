using General.Domain.ViewModels.KsStad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace General.Business.Managers.KsStad.AdditionalService
{
    public interface IKsAdditionalServiceManager
    {
        Task<KsServiceAdditionalViewModel> Create(KsServiceAdditionalViewModel payload);
        Task<IEnumerable<KsServiceAdditionalViewModel>> GetAll();
        Task<bool> Delete(int id);
        Task<KsServiceAdditionalViewModel> GetById(int id);
        Task<KsServiceAdditionalViewModel> Update(KsServiceAdditionalViewModel payload);
    }
}
