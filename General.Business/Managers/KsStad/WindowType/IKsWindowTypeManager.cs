using General.Domain.ViewModels.KsStad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace General.Business.Managers.KsStad.WindowType
{
    public interface IKsWindowTypeManager
    {
        Task<KsWindowTypeViewModel> Create(KsWindowTypeViewModel payload);
        Task<IEnumerable<KsWindowTypeViewModel>> GetAll();
        Task<bool> Delete(int id);
        Task<KsWindowTypeViewModel> GetById(int id);
        Task<KsWindowTypeViewModel> Update(KsWindowTypeViewModel payload);
    }
}
