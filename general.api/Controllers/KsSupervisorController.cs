using General.Business.Managers.KsStad.Supervisor;
using General.Domain.ViewModels.KsStad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TangellaServices;

namespace general.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KsSupervisorController : ControllerBase
    {
        IKsSupervisorManager _manager;
        public KsSupervisorController(IKsSupervisorManager manager)
        {
            _manager = manager;
        }
        //[HttpPost]
        //[ProducesResponseType(typeof(KsSupervisorViewModel), (int)HttpStatusCode.OK)]
        //public async Task<IActionResult> Create(KsSupervisorViewModel item)
        //{
        //    if(item == null)
        //    {
        //        return BadRequest();
        //    }
        //    KsSupervisorViewModel response = await _manager.Create(item);
        //    return new OkObjectResult(response);
        //}
        [HttpPost]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(List<Supervisor> items)
        {
            if(items == null && items.Count > 0)
            {
                return BadRequest();
            }
            List<KsSupervisorViewModel> supervisors = new List<KsSupervisorViewModel>();
            foreach(var item in items)
            {
                supervisors.Add(new KsSupervisorViewModel()
                {
                    Email = string.Format(item.Email),
                    FirstName = string.Format(item.FirstName),
                    Id = 0,
                    IsDeleted = item.IsDeleted,
                    LastName = string.Format(item.LastName),
                    Mobile = string.Format(item.Mobile),
                    Phone = string.Format(item.Phone),
                    SupervisorId = item.SupervisorId
                });
            }
            bool result = await _manager.CreateRange(supervisors);
            return new OkObjectResult(result);
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<KsSupervisorViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<KsSupervisorViewModel> response = await _manager.GetAll();
            return new OkObjectResult(response);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(KsSupervisorViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(int id)
        {
            KsSupervisorViewModel response = await _manager.GetById(id);
            return new OkObjectResult(response);
        }
    }
}
