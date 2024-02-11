using General.Domain.ViewModels.KsStad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace General.Business.Managers.KsStad.Employee
{
    public interface IKsEmployeeManager
    {
        Task<IEnumerable<KsEmployeeViewModel>> GetAll();

        Task<KsEmployeeViewModel> GetById(int id);
        // async
        Task<bool> CreateRangeFromTangela(List<KsEmployeeViewModel> payload);
        Task<KsEmployeeViewModel> Create(KsEmployeeViewModel payload);

        Task<KsEmployeeViewModel> Update(KsEmployeeViewModel payload);

        Task<bool> Delete(int id);
    }
}
