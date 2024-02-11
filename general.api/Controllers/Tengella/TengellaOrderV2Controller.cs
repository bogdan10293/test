using General.Business.Managers.Tangella.V2.Order;
using General.Domain.DTO.Tengella.v2;
using General.Domain.DTO.Tengella.v2.Customer;
using General.Domain.DTO.Tengella.v2.Order;
using General.Domain.DTO.Tengella.v2.Project;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace general.api.Controllers.Tengella
{
    [Route("api/[controller]")]
    [ApiController]
    public class TengellaOrderV2Controller : ControllerBase
    {
        readonly IOrderManager _orderManager;
        public TengellaOrderV2Controller(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }
        [HttpPost("OrderFlow")]
        [ProducesResponseType(typeof(object), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> OrderFlow(OrderFlowDTO order)
        {
            var customer = new CustomerDTO(order.Customer);
            var project = new ProjectDTO(order.Project);
            var workOrder = new WorkOrderDTO(order.Order);
            var data = await _orderManager.CreateOrderFlow(customer, project, workOrder);
            return new OkObjectResult(data);
        }

        [HttpPost("CreateOrder")]
        [ProducesResponseType(typeof(OrderResponseModel), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> CreateOrder(KsWorkOrderDTO order)
        {
            WorkOrderDTO payload = new WorkOrderDTO(order);
            var data = await _orderManager.CreateOrder(payload);
            return new OkObjectResult(data);
        }
    }
}
