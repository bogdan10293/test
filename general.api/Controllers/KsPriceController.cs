using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using General.Business.Managers.KsStad.Prices;
using General.Domain.ViewModels.KsStad;
using Microsoft.AspNetCore.Mvc;

namespace general.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KsPriceController : ControllerBase
    {
        IKsPriceManager _manager;
        public KsPriceController(IKsPriceManager manager)
        {
            _manager = manager;
        }
        [HttpPost]
        [ProducesResponseType(typeof(KsPriceViewModel), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> Create(KsPriceViewModel item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            KsPriceViewModel response = await _manager.Create(item);
            return new OkObjectResult(response);
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<KsPriceViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<KsPriceViewModel> response = await _manager.GetAll();
            return new OkObjectResult(response);
        }
        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(int id)
        {
            bool response = await _manager.Delete(id);
            return new OkObjectResult(response);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<KsPriceViewModel>),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(int id)
        {
            KsPriceViewModel data = await _manager.GetById(id);
            return new OkObjectResult(data);
        }
    }
}
