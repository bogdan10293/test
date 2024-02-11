using General.Domain.Tengella;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace General.Business.Managers.Tangella.V2.Token
{
    public class TokenManager : ITokenManager
    {
        readonly IHttpClientFactory _clientFactory;
        public TokenManager(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<string> GetToken()
        {
            HttpContent data = new StringContent("=170-0004", Encoding.UTF8, "application/x-www-form-urlencoded");
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "login") { Content = data };
            HttpClient client = _clientFactory.CreateClient("tgV2");
            client.DefaultRequestHeaders.Add("X-TengellaApiKey", "DACB1A0B41ED4F3E9F7B4C813F10507E96DF4EE1BA4F4B73A3B0FE0E35744510");
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                TengellaToken result = JsonConvert.DeserializeObject<TengellaToken>(jsonString);
                return result.access_token;
            }
            else
            {
                return null;
            }
        }
    }
}
