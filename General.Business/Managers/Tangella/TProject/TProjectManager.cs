using General.Data.Core;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TangellaServices;

namespace General.Business.Managers.Tangella.TProject
{
    public class TProjectManager : ITProjectManager
    {
        CustomerServiceClient tangellaClient;
        DataContext _context;
        public TProjectManager(DataContext context)
        {
            _context = context;
            BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportWithMessageCredential);
            binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;

            tangellaClient = new CustomerServiceClient(binding, new EndpointAddress("https://api.tengella.se/CustomerService.svc"));

            tangellaClient.ClientCredentials.UserName.UserName = "170-0004";
            tangellaClient.ClientCredentials.UserName.Password = "DACB1A0B41ED4F3E9F7B4C813F10507E96DF4EE1BA4F4B73A3B0FE0E35744510";
        }
        public async Task<TangellaServices.Project[]> GetProjectsAsync(int customerId, bool includeDeleted)
        {
            var data = await tangellaClient.GetProjectsAsync(customerId, includeDeleted);
            return data;
        }
    }
}
