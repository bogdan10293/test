using General.Domain.DTO.Tengella.v2.Customer;
using General.Domain.DTO.Tengella.v2.Order;
using General.Domain.DTO.Tengella.v2.Project;
using System.Threading.Tasks;

namespace General.Business.Managers.Tangella.V2.Order
{
    public interface IOrderManager
    {
        Task<OrderResponseModel> CreateOrder(WorkOrderDTO order);
        Task<bool> CreateOrderFlow(CustomerDTO customer, ProjectDTO project, WorkOrderDTO workOrder);

    }
}
