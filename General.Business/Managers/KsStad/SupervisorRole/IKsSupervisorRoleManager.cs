using General.Domain.ViewModels.KsStad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace General.Business.Managers.KsStad.SupervisorRole
{
    public interface IKsSupervisorRoleManager
    {
        Task<IEnumerable<KsSupervisorRoleViewModel>> GetAll();
        Task<KsApiResultViewModel<KsSupervisorRoleViewModel>> Create(KsSupervisorRoleViewModel payload);
        Task<KsSupervisorRoleViewModel> GetById(int id);
        Task<KsApiResultViewModel<KsSupervisorRoleViewModel>> Update(KsSupervisorRoleViewModel payload);
    }
}
