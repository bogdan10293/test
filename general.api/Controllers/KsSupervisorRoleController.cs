using General.Business.Managers.KsStad.SupervisorRole;
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
    public class KsSupervisorRoleController : ControllerBase
    {
        IKsSupervisorRoleManager _manager;
        public KsSupervisorRoleController(IKsSupervisorRoleManager manager)
        {
            _manager = manager;
        }
        [HttpPost]
        [ProducesResponseType(typeof(KsApiResultViewModel<KsSupervisorRoleViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(KsSupervisorRoleViewModel item)
        {
            if(item == null)
            {
                return BadRequest();
            }
            KsApiResultViewModel<KsSupervisorRoleViewModel> response = await _manager.Create(item);
            return new OkObjectResult(response);
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<KsSupervisorRoleViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<KsSupervisorRoleViewModel> response = await _manager.GetAll();
            return new OkObjectResult(response);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(KsSupervisorRoleViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(int id)
        { 
            if(id <= 0)
            {
                return BadRequest();
            }
            KsSupervisorRoleViewModel response = await _manager.GetById(id);
            return new OkObjectResult(response);
        }
        [HttpPut]
        [ProducesResponseType(typeof(KsApiResultViewModel<KsSupervisorRoleViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(KsSupervisorRoleViewModel item)
        {
            KsApiResultViewModel<KsSupervisorRoleViewModel> response = await _manager.Update(item);
            return new OkObjectResult(response);
        }
    }
}
