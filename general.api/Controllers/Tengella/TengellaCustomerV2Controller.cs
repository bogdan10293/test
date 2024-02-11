using General.Business.Managers.Tangella.V2.Customer;
using General.Domain.DTO.Tengella.v2.Customer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace general.api.Controllers.Tengella
{
    [Route("api/[controller]")]
    [ApiController]
    public class TengellaCustomerV2Controller : ControllerBase
    {
        readonly ICustomerManager _customerManager;
        public TengellaCustomerV2Controller(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }
        [HttpPost("CreateCustomer")]
        [ProducesResponseType(typeof(CustomerResponseModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateCustomer(KsCustomerDTO customer)
        {

            CustomerDTO payload = new CustomerDTO(customer);
            var data = await _customerManager.CreateCustomer(payload);
            return new OkObjectResult(data);
        }
    }
}
