using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using General.Business.Managers.KsStad.Customer;
using General.Domain.ViewModels.KsStad;
using Microsoft.AspNetCore.Mvc;

namespace general.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KsCustomerController : ControllerBase
    {
        IKsCustomerManager _manager;
        public KsCustomerController(IKsCustomerManager manager)
        {
            _manager = manager;
        }
        [HttpPost]
        [ProducesResponseType(typeof(KsApiResultViewModel<KsCustomerEntity>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(KsCustomerEntity item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            KsApiResultViewModel<KsCustomerEntity> response = await _manager.Create(item);
            return new OkObjectResult(response);
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<KsCustomerEntity>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<KsCustomerEntity> response = await _manager.GetAll();
            return new OkObjectResult(response);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(KsCustomerEntity), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Invalid Id");
            }
            KsCustomerEntity response = await _manager.GetById(id);
            return new OkObjectResult(response);
        }
        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Invalid Id");
            }
            bool response = await _manager.Delete(id);
            return new OkObjectResult(response);
        }
        [HttpPut]
        [ProducesResponseType(typeof(KsApiResultViewModel<KsCustomerEntity>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(KsCustomerEntity payload)
        {
            KsApiResultViewModel<KsCustomerEntity> response = await _manager.Update(payload);
            return new OkObjectResult(response);
        }
    }
}
