using General.Business.Managers.Tangella.V2.Token;
using General.Domain.DTO.Tengella.v2.Customer;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace General.Business.Managers.Tangella.V2.Customer
{
    public class CustomerManager : ICustomerManager
    {
        readonly IHttpClientFactory _clientFactory;
        readonly ITokenManager _tokenManager;
        public CustomerManager(IHttpClientFactory clientFactory, ITokenManager tokenManager)
        {
            _clientFactory = clientFactory;
            _tokenManager = tokenManager;
        }
        public async Task<CustomerResponseModel> CreateCustomer(CustomerDTO customer)
        {
            string tangellaToken = await _tokenManager.GetToken();
            if(!string.IsNullOrEmpty(tangellaToken))
            {
                using (var content = new StringContent(JsonConvert.SerializeObject(customer), System.Text.Encoding.UTF8, "application/json"))
                {
                    HttpClient client = _clientFactory.CreateClient("tgV2");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tangellaToken);

                    HttpResponseMessage result = client.PostAsync("Customers", content).Result;
                    //
                    // get response body from tengella API as string and return the object
                    // 
                    var jsonData = await result.Content.ReadAsStringAsync();
                    CustomerResponseModel customerResponse = JsonConvert.DeserializeObject<CustomerResponseModel>(jsonData);
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        return customerResponse;
                    string returnValue = result.Content.ReadAsStringAsync().Result;
                    throw new Exception($"Failed to POST data: ({result.StatusCode}): {returnValue}");
                }
            }
            else
            {
                return null;
            }
        }
    }
}
