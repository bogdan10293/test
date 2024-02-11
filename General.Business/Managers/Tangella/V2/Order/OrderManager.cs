using General.Business.Managers.Tangella.TProject;
using General.Business.Managers.Tangella.V2.Customer;
using General.Business.Managers.Tangella.V2.Project;
using General.Business.Managers.Tangella.V2.Token;
using General.Domain.DTO.Tengella.v2.Customer;
using General.Domain.DTO.Tengella.v2.Order;
using General.Domain.DTO.Tengella.v2.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace General.Business.Managers.Tangella.V2.Order
{
    public class OrderManager : IOrderManager
    {
        readonly IHttpClientFactory _clientFactory;
        readonly ITokenManager _tokenManager;
        readonly ICustomerManager _customerManager;
        readonly IProjectManager _projectManager;
        readonly ITEmployeeManager _oldCustomerManager;
        readonly ITProjectManager _iTProjectManager;
        readonly IOrderRowManager _iOrderRowManager;

        public OrderManager(
            IHttpClientFactory clientFactory,
            ITokenManager tokenManager,
            ICustomerManager customerManager,
            IProjectManager projectManager,
            ITEmployeeManager oldCustomerManager,
            ITProjectManager iTProjectManager,
            IOrderRowManager iOrderRowManager)
        {
            _clientFactory = clientFactory;
            _tokenManager = tokenManager;
            _customerManager = customerManager;
            _projectManager = projectManager;
            _oldCustomerManager = oldCustomerManager;
            _iTProjectManager = iTProjectManager;
            _iOrderRowManager = iOrderRowManager;
        }
        public async Task<OrderResponseModel> CreateOrder(WorkOrderDTO order)
        {
            string tangellaToken = await _tokenManager.GetToken();
            if (!string.IsNullOrEmpty(tangellaToken))
            {
                using (var content = new StringContent(JsonConvert.SerializeObject(order), System.Text.Encoding.UTF8, "application/json"))
                {
                    HttpClient client = _clientFactory.CreateClient("tgV2");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tangellaToken);

                    HttpResponseMessage result = client.PostAsync("WorkOrders", content).Result;
                    //
                    // get response body from tengella API as string and return the object
                    // 
                    var jsonData = await result.Content.ReadAsStringAsync();
                    OrderResponseModel orderResponse = JsonConvert.DeserializeObject<OrderResponseModel>(jsonData);
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        return orderResponse;
                    string returnValue = result.Content.ReadAsStringAsync().Result;
                    throw new Exception($"Failed to POST data: ({result.StatusCode}): {returnValue}");
                }
            }
            else
            {
                return null;
            }
        }

        private async Task<int> GetCustomerId(CustomerDTO customer)
        {
            var custId = await _oldCustomerManager.GetCustomerId(customer.RegNo);

            if (custId == 0)
            {
                CustomerResponseModel newCustomer = await _customerManager.CreateCustomer(customer);
                custId = newCustomer.CustomerId;
            }
            return custId;
        }

        private async Task<int> GetProjectId(ProjectDTO project)
        {
            var projectId = 0;
            var projectExist = await _iTProjectManager.GetProjectsAsync(project.CustomerId.Value, false);
            if(projectExist.Any())
            {
                foreach (var item in projectExist)
                {
                    if (item.ProjectName == "Projekt från hemsidan")
                    {
                        projectId = item.ProjectId;
                    }
                }
            }

            if(projectId == 0)
            {
                ProjectResponseModel projectResponse = await _projectManager.CreateProject(project);
                projectId = projectResponse.ProjectId;
            }
            return projectId;
        }

        public async Task<bool> CreateOrderFlow(CustomerDTO customer, ProjectDTO project, WorkOrderDTO workOrder)
        {
            project.CustomerId = await GetCustomerId(customer);
            workOrder.ProjectId = await GetProjectId(project);
            OrderResponseModel orderResponse = await CreateOrder(workOrder);
            return true;
        }
    }
}
