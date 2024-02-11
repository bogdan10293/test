//using System;
//using System.Collections.Generic;
//using System.Net;
//using System.Threading.Tasks;
//using General.Business.Managers.JiffyTidyManagers.Employee;
//using General.Domain.ViewModels.JIffyTidyViewModels;
//using Microsoft.AspNetCore.Mvc;

//namespace general.api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class EmployeeController : ControllerBase
//    {
//        IEmployeeManager _manager;
//        public EmployeeController(IEmployeeManager manager)
//        {
//            _manager = manager;
//        }
//        [HttpPost]
//        [ProducesResponseType(typeof(EmployeeEntity), (int)HttpStatusCode.OK)]
//        public async Task<IActionResult> Create(EmployeeEntity item)
//        {
//            if(item == null)
//            {
//                return BadRequest();
//            }
//            EmployeeEntity response = await _manager.Create(item);
//            return new OkObjectResult(response);
//        }
//        [HttpGet]
//        [ProducesResponseType(typeof(IEnumerable<EmployeeEntity>), (int)HttpStatusCode.OK)]
//        public async Task<IActionResult> GetAll()
//        {
//            IEnumerable<EmployeeEntity> response = await _manager.GetAll();
//            return new OkObjectResult(response);
//        }
//        [HttpGet("{id}")]
//        [ProducesResponseType(typeof(EmployeeEntity), (int)HttpStatusCode.OK)]
//        public async Task<IActionResult> GetById(Guid id)
//        {
//            if (id == null || id == Guid.Empty)
//            {
//                throw new Exception("Invalid Id");
//            }
//            EmployeeEntity response = await _manager.GetById(id);
//            return new OkObjectResult(response);
//        }
//        [HttpDelete]
//        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
//        public async Task<IActionResult> Delete(Guid id)
//        {
//            if (id == null || id == Guid.Empty)
//            {
//                throw new Exception("Invalid Id");
//            }
//            bool response = await _manager.Delete(id);
//            return new OkObjectResult(response);
//        }
//        [HttpPut]
//        [ProducesResponseType(typeof(EmployeeEntity), (int)HttpStatusCode.OK)]
//        public async Task<IActionResult> Update(EmployeeEntity payload)
//        {
//            EmployeeEntity response = await _manager.Update(payload);
//            return new OkObjectResult(response);
//        }
//    }
//}
