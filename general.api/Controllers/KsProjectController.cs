using General.Business.Managers.KsStad.Project;
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
    public class KsProjectController : ControllerBase
    {
        IKsProjectManager _context;
        public KsProjectController(IKsProjectManager context)
        {
            _context = context;
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<KsProjectViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<KsProjectViewModel> response = await _context.GetAll();
            return new OkObjectResult(response);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(KsProjectViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(int id)
        {
            KsProjectViewModel response = await _context.GetById(id);
            return new OkObjectResult(response);
        }
        [HttpPost]
        [ProducesResponseType(typeof(KsApiResultViewModel<KsProjectViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(KsProjectViewModel item)
        {
            if(item == null)
            {
                return BadRequest();
            }
            KsApiResultViewModel<KsProjectViewModel> response = await _context.Create(item);
            return new OkObjectResult(response);
        }
        [HttpPut]
        [ProducesResponseType(typeof(KsProjectViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult>Update(KsProjectViewModel item)
        {
            KsProjectViewModel response = await _context.Update(item);
            return new OkObjectResult(response);
        }
        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult>Delete(int id)
        {
            bool response = await _context.Delete(id);
            return new OkObjectResult(response);
        }
    }
}
