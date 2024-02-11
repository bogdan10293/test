using System.Net;
using System.Threading.Tasks;
using General.Business.Managers.KsStad.Order;
using General.Domain.ViewModels.KsStad;
using Microsoft.AspNetCore.Mvc;

namespace general.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KsOrderController : ControllerBase
    {
        IKsOrderManager _manager;
        public KsOrderController(IKsOrderManager manager)
        {
            _manager = manager;
        }
        [HttpPost]
        [ProducesResponseType(typeof(KsOrderEntity), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(KsOrderEntity item)
        {
            if(item == null)
            {
                return BadRequest();
            }
            KsOrderEntity response = await _manager.Create(item);
            return new OkObjectResult(response);
        }
    }
}
