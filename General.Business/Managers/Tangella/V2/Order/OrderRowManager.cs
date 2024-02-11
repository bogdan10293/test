using General.Business.Managers.Tangella.V2.Token;
using General.Domain.DTO.Tengella.v2.Order;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace General.Business.Managers.Tangella.V2.Order
{
    public class OrderRowManager : IOrderRowManager
    {
        readonly IHttpClientFactory _clientFactory;
        readonly ITokenManager _tokenManager;
        public OrderRowManager(IHttpClientFactory clientFactory, ITokenManager tokenManager)
        {
            _clientFactory = clientFactory;
            _tokenManager = tokenManager;
        }
        public async Task<OrderRowResponseModel> CreateOrderRow(WorkOrderRowDTO orderRow)
        {
            string tangellaToken = await _tokenManager.GetToken();
            if (!string.IsNullOrEmpty(tangellaToken))
            {
                using (var content = new StringContent(JsonConvert.SerializeObject(orderRow), System.Text.Encoding.UTF8, "application/json"))
                {
                    HttpClient client = _clientFactory.CreateClient("tgV2");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tangellaToken);

                    HttpResponseMessage result = client.PostAsync("WorkOrderRows", content).Result;
                    //
                    // get response body from tengella API as string and return the object
                    // 
                    var jsonData = await result.Content.ReadAsStringAsync();
                    OrderRowResponseModel orderRowResponse = JsonConvert.DeserializeObject<OrderRowResponseModel>(jsonData);
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        return orderRowResponse;
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
