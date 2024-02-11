using General.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using TangellaServices;

namespace General.Business.Managers.Tangella.TEventWithWorkAddress
{
    public class TEventWithWorkAddress : ITEventWithWorkAddress
    {
        CustomerServiceClient tangellaClient;
        DataContext _context;
        public TEventWithWorkAddress(DataContext context)
        {
            _context = context;
            BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportWithMessageCredential);
            binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;

            tangellaClient = new CustomerServiceClient(binding, new EndpointAddress("https://api.tengella.se/CustomerService.svc"));

            tangellaClient.ClientCredentials.UserName.UserName = "170-0004";
            tangellaClient.ClientCredentials.UserName.Password = "DACB1A0B41ED4F3E9F7B4C813F10507E96DF4EE1BA4F4B73A3B0FE0E35744510";
        }

        public async Task<IEnumerable<EventWithWorkAddress>> GetEventWithWorkAddress(int supervisorId, int regionId, int employeeId, DateTime fromDate, DateTime toDate)
        {

            var data = await tangellaClient.GetEventsWithWorkAddressAsync(fromDate, toDate, 0, 0, employeeId);
            return data;
        }
    }
}
