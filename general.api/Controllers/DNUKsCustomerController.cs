//using System.Collections.Generic;
//using System.Net;
//using System.Threading.Tasks;
//using General.Business.Managers.Customer;
//using General.Domain.ViewModels;
//using Microsoft.AspNetCore.Mvc;

//namespace general.api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class KsCustomerController : ControllerBase
//    {
//        IKsCustomerManager _manager;
//        public KsCustomerController(IKsCustomerManager manager)
//        {
//            _manager = manager;
//        }
//        [HttpPost]
//        [ProducesResponseType(typeof(KsCustomerViewModel), (int)HttpStatusCode.OK)]

//        public async Task<IActionResult> Create(KsCustomerViewModel item)
//        {
//            if (item == null)
//            {
//                return BadRequest();
//            }
//            KsCustomerViewModel response = await _manager.Create(item);
//            return new OkObjectResult(response);
//        }

//        [HttpDelete]
//        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
//        public async Task<IActionResult> Delete(int id)
//        {
//            bool response = await _manager.Delete(id);
//            return new OkObjectResult(response);
//        }
//        [HttpGet]
//        [ProducesResponseType(typeof(IEnumerable<KsCustomerViewModel>), (int)HttpStatusCode.OK)]
//        public async Task<IActionResult> GetAll()
//        {
//            IEnumerable<KsCustomerViewModel> response = await _manager.GetAll();
//            return new OkObjectResult(response);
//        }
//        [HttpGet ("{id}")]
//        [ProducesResponseType(typeof(KsCustomerViewModel), (int)HttpStatusCode.OK)]

//        public async Task<IActionResult> GetById(int id)
//        {
//            KsCustomerViewModel response = await _manager.GetById(id);
//            return new OkObjectResult(response);
//        }
//        [HttpPut]
//        [ProducesResponseType(typeof(KsCustomerViewModel), (int)HttpStatusCode.OK)]
//        public async Task<IActionResult> Update(KsCustomerViewModel payload)
//        {
//            KsCustomerViewModel response = await _manager.Update(payload);
//            return new OkObjectResult(response);
//        }
//    }
//}
