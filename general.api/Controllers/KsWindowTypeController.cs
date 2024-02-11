using General.Business.Managers.KsStad.WindowType;
using General.Domain.ViewModels.KsStad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace general.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KsWindowTypeController : ControllerBase
    {
        IKsWindowTypeManager _context;
        public KsWindowTypeController(IKsWindowTypeManager context)
        {
            _context = context;
        }
        [HttpPost]
        [ProducesResponseType(typeof(KsWindowTypeViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(KsWindowTypeViewModel item)
        {
            if(item == null)
            {
                return BadRequest();
            }
            KsWindowTypeViewModel response = await _context.Create(item);
            return new OkObjectResult(response);
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<KsWindowTypeViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<KsWindowTypeViewModel> response = await _context.GetAll();
            return new OkObjectResult(response);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(KsWindowTypeViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(int id)
        {
            if(id <= 0)
            {
                return BadRequest("No such id");
            }
            KsWindowTypeViewModel response = await _context.GetById(id);
            return new OkObjectResult(response);
        }
        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(int id)
        {
            if(id <= 0)
            {
                return BadRequest("No such id");
            }
            bool response = await _context.Delete(id);
            return new OkObjectResult(response);
        }
        [HttpPut]
        [ProducesResponseType(typeof(KsWindowTypeViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(KsWindowTypeViewModel item)
        {
            KsWindowTypeViewModel response = await _context.Update(item);
            return new OkObjectResult(response);
        }

    }
}
