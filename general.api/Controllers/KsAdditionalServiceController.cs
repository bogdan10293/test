using General.Business.Managers.KsStad.AdditionalService;
using General.Domain.ViewModels.KsStad;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace general.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KsAdditionalServiceController : ControllerBase
    {
        IKsAdditionalServiceManager _context;
        public KsAdditionalServiceController(IKsAdditionalServiceManager context)
        {
            _context = context;
        }
        [HttpPost]
        [ProducesResponseType(typeof(KsServiceAdditionalViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(KsServiceAdditionalViewModel item)
        {
          
            if (item == null)
            {
                return BadRequest();
            }
            if (item.ServiceFk == 0)
            {
                return BadRequest();
            }
            KsServiceAdditionalViewModel response = await _context.Create(item);
            return new OkObjectResult(response);
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<KsServiceAdditionalViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<KsServiceAdditionalViewModel> response = await _context.GetAll();
            return new OkObjectResult(response);
        }
        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("No such id");
            }
            bool response = await _context.Delete(id);
            return new OkObjectResult(response);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(KsServiceAdditionalViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(int id)
        {
            if(id <= 0)
            {
                return BadRequest("No such id");
            }
            KsServiceAdditionalViewModel response = await _context.GetById(id);
            return new OkObjectResult(response);
        }
        [HttpPut]
        [ProducesResponseType(typeof(KsServiceAdditionalViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(KsServiceAdditionalViewModel item)
        {
            KsServiceAdditionalViewModel response = await _context.Update(item);
            return new OkObjectResult(response);
        }

    }
}
