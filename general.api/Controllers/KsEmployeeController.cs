using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using General.Business.Managers.KsStad.Employee;
using General.Domain.ViewModels.KsStad;
using Microsoft.AspNetCore.Mvc;
using TangellaServices;

namespace general.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KsEmployeeController : ControllerBase
    {
        IKsEmployeeManager _manager;
        public KsEmployeeController(IKsEmployeeManager manager)
        {
            _manager = manager;
        }
        [HttpGet]
        /*for swagger, generate classes to frontend apiGeneral */
        [ProducesResponseType(typeof(IEnumerable<KsEmployeeViewModel>), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> GetAll()
        {
            IEnumerable<KsEmployeeViewModel> response = await _manager.GetAll();
            return new OkObjectResult(response);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(KsEmployeeViewModel), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> GetById(int id)
        {
            KsEmployeeViewModel response = await _manager.GetById(id);
            return new OkObjectResult(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> Create(List<Employee> items)
        {
            if (items == null && items.Count > 0)
            {
                return BadRequest();
            }
            List<KsEmployeeViewModel> employees = new List<KsEmployeeViewModel>();
            foreach(var item in items)
            {
                employees.Add(new KsEmployeeViewModel()
                {
                    FirstName = string.Format(item.FirstName),
                    LastName = string.Format(item.LastName),
                    TangellaId = item.EmployeeId,
                    PersonalIdentityNumber = string.Format(item.PersonalIdentityNumber),
                    Created = DateTime.Now,
                    IsDeleted = item.IsDeleted,
                    Mail = string.Format(""),
                    Phone = string.Format(""),
                    RegionId = item.RegionId,
                    Role = string.Format(""),
                    SupervisorId = null,
                    Updated = DateTime.Now,
                    Id = 0,
                    Age = 0,
                    EmployeeNo = string.Format("")
                });
            }
            bool result = await _manager.CreateRangeFromTangela(employees);
            //return new OkObjectResult(response);
            return new OkObjectResult(result);
        }
        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> Delete(int id)
        {
            bool response = await _manager.Delete(id);
            return new OkObjectResult(response);
        }
        [HttpPut]
        [ProducesResponseType(typeof(KsEmployeeViewModel), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> Update(KsEmployeeViewModel item)
        {
            KsEmployeeViewModel response = await _manager.Update(item);
            return new OkObjectResult(response);
        }
    }
}
