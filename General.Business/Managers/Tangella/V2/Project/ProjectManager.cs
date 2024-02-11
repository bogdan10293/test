using General.Business.Managers.Tangella.V2.Token;
using General.Domain.DTO.Tengella.v2.Project;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace General.Business.Managers.Tangella.V2.Project
{
    public class ProjectManager : IProjectManager
    {
        readonly IHttpClientFactory _clientFactory;
        readonly ITokenManager _tokenManager;
        public ProjectManager(IHttpClientFactory clientFactory, ITokenManager tokenManager)
        {
            _clientFactory = clientFactory;
            _tokenManager = tokenManager;
        }
        public async Task<ProjectResponseModel> CreateProject(ProjectDTO project)
        {
            string tangellaToken = await _tokenManager.GetToken();
            if (!string.IsNullOrEmpty(tangellaToken))
            {
                using (var content = new StringContent(JsonConvert.SerializeObject(project), System.Text.Encoding.UTF8, "application/json"))
                {
                    HttpClient client = _clientFactory.CreateClient("tgV2");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tangellaToken);

                    HttpResponseMessage result = client.PostAsync("Projects", content).Result;
                    //
                    // get response body from tengella API as string and return the object
                    // RootObject rootObj= JsonConvert.DeserializeObject<RootObject>(File.ReadAllText(pathFile));
                    var jsonData = await result.Content.ReadAsStringAsync();
                    ProjectResponseModel projectResponse = JsonConvert.DeserializeObject<ProjectResponseModel>(jsonData);
                    if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        return projectResponse;
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
