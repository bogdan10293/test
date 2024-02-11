using General.Domain.ViewModels.KsStad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace General.Business.Managers.KsStad.Supervisor
{
    public interface IKsSupervisorManager
    {
        Task<bool> CreateRange(List<KsSupervisorViewModel> payload);
        Task<IEnumerable<KsSupervisorViewModel>> GetAll();
        Task<KsSupervisorViewModel> GetById(int id);
        Task<KsSupervisorViewModel> Create(KsSupervisorViewModel payload);
    }
}
