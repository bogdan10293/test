using General.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using TangellaServices;

namespace General.Business.Managers.Tangella.Employee
{
    public class TEmployeeManager : ITEmployeeManager
    {
        CustomerServiceClient tangellaClient;
        DataContext _context;
        public TEmployeeManager(DataContext context)
        {
            _context = context;
            BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportWithMessageCredential);
            binding.MaxReceivedMessageSize = 2048000;
            binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;

            tangellaClient = new CustomerServiceClient(binding, new EndpointAddress("https://api.tengella.se/CustomerService.svc"));

            tangellaClient.ClientCredentials.UserName.UserName = "170-0004";
            tangellaClient.ClientCredentials.UserName.Password = "DACB1A0B41ED4F3E9F7B4C813F10507E96DF4EE1BA4F4B73A3B0FE0E35744510";
        }

        public async Task<List<TangellaServices.Employee>> GetAllEmployees()
        {
            var data = await tangellaClient.GetEmployeesAsync();
            List<TangellaServices.Employee> activeEmployees = new List<TangellaServices.Employee>();
            foreach (var employee in data.Where(x => !x.IsDeleted))
            {
                activeEmployees.Add(employee);
            }
            return activeEmployees;
        }

        public async Task<int> GetCustomerId(string identityNo)
        {
            var customerId = await tangellaClient.GetCustomerIdAsync(identityNo);
            return customerId;
        }


        public async Task<int> GetCustomerContactId(string identityNo)
        {
            var identity = await tangellaClient.GetCustomerIdAsync(identityNo);
            var data = await tangellaClient.GetGetCustomerContactsAsync(identity);
            var contactId = data.Select(x => x.ContactId).FirstOrDefault();

            return contactId;
        }
        public async Task<TangellaServices.Contact[]> GetCustomerAndProject(int customerId, int projectId)
        {
            var data = await tangellaClient.GetProjectGetCustomerContactsAsync(customerId, projectId);
            return data;
        }
    }
}
