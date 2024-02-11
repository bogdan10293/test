using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using General.Business.Managers.KsStad.Service;
using General.Domain.ViewModels.KsStad;
using Microsoft.AspNetCore.Mvc;

namespace general.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KsServiceController : ControllerBase
    {
        IKsServiceManager _context;
        public KsServiceController(IKsServiceManager context)
        {
            _context = context;
        }
        [HttpGet]
        /*for swagger, generate classes to frontend apiGeneral */
        [ProducesResponseType(typeof(IEnumerable<KsServiceViewModel>), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> GetAll()
        {
            IEnumerable<KsServiceViewModel> response = await _context.GetAll();
            return new OkObjectResult(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(KsServiceViewModel), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> GetById(int id)
        {
            KsServiceViewModel response = await _context.GetById(id);
            return new OkObjectResult(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(KsServiceViewModel), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> Create(KsServiceViewModel item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            KsServiceViewModel response = await _context.Create(item);
            return new OkObjectResult(response);
        }
        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> Delete(int id)
        {
            bool response = await _context.Delete(id);
            return new OkObjectResult(response);
        }
        [HttpPut]
        [ProducesResponseType(typeof(KsServiceViewModel), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> Update(KsServiceViewModel item)
        {
            KsServiceViewModel response = await _context.Update(item);
            return new OkObjectResult(response);
        }
    }
}
