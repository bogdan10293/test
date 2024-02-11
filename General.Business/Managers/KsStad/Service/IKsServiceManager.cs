using General.Domain.ViewModels.KsStad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace General.Business.Managers.KsStad.Service
{
    public interface IKsServiceManager
    {
        Task<IEnumerable<KsServiceViewModel>> GetAll();
        Task<KsServiceViewModel> GetById(int id);
        Task<KsServiceViewModel> Create(KsServiceViewModel payload);
        Task<KsServiceViewModel> Update(KsServiceViewModel payload);
        Task<bool> Delete(int id);
    }
}
