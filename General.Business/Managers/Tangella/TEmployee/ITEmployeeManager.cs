using System.Collections.Generic;
using System.Threading.Tasks;

namespace General.Business.Managers.Tangella
{
    public interface ITEmployeeManager
    {
        Task<List<TangellaServices.Employee>> GetAllEmployees();
        Task<int> GetCustomerId(string identityNo);
        Task<int> GetCustomerContactId(string identityNo);
        Task<TangellaServices.Contact[]> GetCustomerAndProject(int customerId, int projectId);
    }
}
