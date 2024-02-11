using General.Domain.DTO.Tengella.v2.Order;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace General.Business.Managers.Tangella.V2.Order
{
    public interface IOrderRowManager
    {
        Task<OrderRowResponseModel> CreateOrderRow(WorkOrderRowDTO order);
    }
}
