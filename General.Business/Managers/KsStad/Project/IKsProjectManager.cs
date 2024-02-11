using General.Domain.ViewModels.KsStad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace General.Business.Managers.KsStad.Project
{
    public interface IKsProjectManager
    {
        Task<KsApiResultViewModel<KsProjectViewModel>> Create(KsProjectViewModel payload);
        Task<bool> Delete(int id);
        Task<IEnumerable<KsProjectViewModel>> GetAll();
        Task<KsProjectViewModel> GetById(int id);
        Task<KsProjectViewModel> Update(KsProjectViewModel payload);
    }
}
