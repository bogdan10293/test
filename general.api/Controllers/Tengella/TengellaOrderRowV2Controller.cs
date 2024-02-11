using General.Business.Managers.Tangella.V2.Order;
using General.Domain.DTO.Tengella.v2.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace general.api.Controllers.Tengella
{
    [Route("api/[controller]")]
    [ApiController]
    public class TengellaOrderRowV2Controller : ControllerBase
    {
        readonly IOrderRowManager _orderRowManager;
        public TengellaOrderRowV2Controller(IOrderRowManager orderRowManager)
        {
            _orderRowManager = orderRowManager;
        }
        [HttpPost("CreateOrderRow")]
        [ProducesResponseType(typeof(OrderRowResponseModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateOrderRow(KsWorkOrderRowDTO orderRow)
        {
            WorkOrderRowDTO payload = new WorkOrderRowDTO(orderRow);
            var data = await _orderRowManager.CreateOrderRow(payload);
            return new OkObjectResult(data);
        }
    }
}
