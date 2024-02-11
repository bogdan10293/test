using General.Domain.DTO.Tengella.v2.Customer;
using System.Threading.Tasks;

namespace General.Business.Managers.Tangella.V2.Customer
{
    public interface ICustomerManager
    {
        Task<CustomerResponseModel> CreateCustomer(CustomerDTO customer);
    }
}
