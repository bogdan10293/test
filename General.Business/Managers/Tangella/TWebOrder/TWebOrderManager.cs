using General.Data.Core;
using General.Domain.ViewModels.Tangella;
using Newtonsoft.Json;
using System;
using System.ServiceModel;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TangellaServices;

namespace General.Business.Managers.Tangella.TWebOrder
{
    public class TWebOrderManager : ITWebOrderManager
    {
        CustomerServiceClient tangellaClient;
        DataContext _context;
        public TWebOrderManager(DataContext context)
        {
            _context = context;
            BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportWithMessageCredential);
            binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;

            tangellaClient = new CustomerServiceClient(binding, new EndpointAddress("https://api.tengella.se/CustomerService.svc"));

            tangellaClient.ClientCredentials.UserName.UserName = "170-0004";
            tangellaClient.ClientCredentials.UserName.Password = "DACB1A0B41ED4F3E9F7B4C813F10507E96DF4EE1BA4F4B73A3B0FE0E35744510";
        }
        public async Task<string> TestApiGetWebOrderFormsAsync(string zipCode)
        {
            var data = await tangellaClient.TestApiGetWebOrderFormsAsync(zipCode);
            return data;
        }
        public async Task<int> TestApiAddWebOrderAsync(WebOrderFormReturnViewModel payload)
            // Must add date to object for testing [post}]
        {
            try
            {
                var data = JsonConvert.SerializeObject(payload);
                var res = await tangellaClient.TestApiAddWebOrderAsync(data);

                return res;
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
                return -99;
            }
        }
    }
}
