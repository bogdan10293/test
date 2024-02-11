using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using General.Business.Managers.Tangella;
using General.Business.Managers.Tangella.TEventWithWorkAddress;
using General.Business.Managers.Tangella.TFreeTimeSlots;
using General.Business.Managers.Tangella.TProject;
using General.Business.Managers.Tangella.TSupervisor;
using General.Business.Managers.Tangella.TWebOrder;
using General.Domain.Filters;
using General.Domain.ViewModels;
using General.Domain.ViewModels.Tangella;
using Microsoft.AspNetCore.Mvc;
using TangellaServices;

namespace general.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TangellaController : ControllerBase
    {

        ITEmployeeManager _employeeManager;
        ITEventWithWorkAddress _eventWithWorkAddress;
        ITFreeTimeslotsManager _freeTimeslotsManager;
        ITWebOrderManager _webOrderManager;
        ITSupervisorManager _supervisorManager;
        ITProjectManager _projectManager;

        public TangellaController(ITEmployeeManager employeeManager, ITEventWithWorkAddress eventWithWorkAddress, ITFreeTimeslotsManager freeTimeslotsManager, ITWebOrderManager webOrderManager, ITSupervisorManager supervisorManager, ITProjectManager projectManager)
        {

            _employeeManager = employeeManager;
            _eventWithWorkAddress = eventWithWorkAddress;
            _freeTimeslotsManager = freeTimeslotsManager;
            _webOrderManager = webOrderManager;
            _supervisorManager = supervisorManager;
            _projectManager = projectManager;

        }
        [HttpGet("TestApiGetWebOrderForms")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<string> TestApiGetWebOrderFormsAsync(string zipCode)
        {
            return await _webOrderManager.TestApiGetWebOrderFormsAsync(zipCode);
        }
        [HttpPost("TestApiAddWebOrderForm")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<int> TestApiAddWebOrderAsync(WebOrderFormReturnViewModel payload)
        {
            var res = await _webOrderManager.TestApiAddWebOrderAsync(payload);
            return res;
        }

        [HttpGet("GetAllEmployees")]
        [ProducesResponseType(typeof(List<Employee>), (int)HttpStatusCode.OK)]
        public async Task<List<Employee>> GetAllEmployees()
        {
            var data = await _employeeManager.GetAllEmployees();
            return data;
        }
        [HttpGet("GetEventWithWorkAddress")]
        [ProducesResponseType(typeof(List<EventWithWorkAddress>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<EventWithWorkAddress>> GetEventWithWorkAddress(int supervisorId, int regionId, int employeeId, DateTime fromDate, DateTime toDate)
        {
            var data = await _eventWithWorkAddress.GetEventWithWorkAddress(supervisorId, regionId, employeeId, fromDate, toDate);
            return data;
        }
        [HttpGet("GetAllFreeTimeslots")]
        [ProducesResponseType(typeof(List<EventWithWorkAddress>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<EventWithWorkAddress>> GetAllFreeTimeSlots(DateTime from, DateTime to, int employeeId)
        {
            var data = await _freeTimeslotsManager.GetAllFreeTimeSlots(from, to, employeeId);
            return data;
        }
        [HttpGet("GetFreeTimeSlotsAsync")]
        [ProducesResponseType(typeof(List<FreeTimeSlot>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<FreeTimeSlot>> GetFreeTimeSlotsAsync(DateTime from, DateTime to, bool monday, bool tuesday, bool wednesday, bool thursday, bool friday, bool saturday, bool sunday, int serviceId)
        {
            var data = await _freeTimeslotsManager.GetFreeTimeSlotsAsync(from, to, monday, tuesday, wednesday, thursday, friday, saturday, sunday, serviceId);
            return data;
        }
        [HttpPost("PostFreeTimeslotsById")]
        //*for swagger, generate classes to frontend apiGeneral */
        [ProducesResponseType(typeof(IEnumerable<FreeTimeSlot>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> PostFreeTimeslotsById(FilterFreeTimeSlots payload)
        {
            var freeSlots = await _freeTimeslotsManager.PostFreeTimeslotsById(payload);
            return new OkObjectResult(freeSlots);
        }
        //[HttpGet("GetGetCustomerContactsAsync")]
        //[ProducesResponseType(typeof(Contact), (int)HttpStatusCode.OK)]
        //public async Task<Contact[]> GetGetCustomerContactsAsync(int customerId)
        //{
        //    var data = await _employeeManager.GetGetCustomerContactsAsync(customerId);
        //    return data;
        //}
        [HttpGet("GetCustomerContactId")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<int> GetCustomerContactId(string identityNo)
        {
            var data = await _employeeManager.GetCustomerContactId(identityNo);
            return data;
        }
        [HttpGet("GetCustomerAndProject")]
        [ProducesResponseType(typeof(List<Contact[]>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCustomerAndProject(int customerId, int projectId)
        {
            var data = await _employeeManager.GetCustomerAndProject(customerId, projectId);
            return new OkObjectResult(data);
        }
        [HttpGet("GetSupervisors")]
        [ProducesResponseType(typeof(List<Supervisor>), (int)HttpStatusCode.OK)]
        public async Task<List<Supervisor>> GetSupervisors()
        {
            var data = await _supervisorManager.GetSupervisors();
            return data;
        }
        [HttpGet("GetProject")]
        [ProducesResponseType(typeof(List<Project[]>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProjectsAsync(int customerId, bool includeDeleted)
        {
            var data = await _projectManager.GetProjectsAsync(customerId, includeDeleted);
            return new OkObjectResult(data);
        }
        [HttpGet("GetCustomerId")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<int> GetCustomerId(string identityNo)
        {
            var data = await _employeeManager.GetCustomerId(identityNo);
            return data;
        }
    }
}
