using General.Business.Managers.Tangella.V2.Project;
using General.Domain.DTO.Tengella.v2.Project;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace general.api.Controllers.Tengella
{
    [Route("api/[controller]")]
    [ApiController]
    public class TengellaProjectV2Controller : ControllerBase
    {
        readonly IProjectManager _projectManager;
        public TengellaProjectV2Controller(IProjectManager projectManager)
        {
            _projectManager = projectManager;
        }
        [HttpPost("CreateProject")]
        [ProducesResponseType(typeof(ProjectResponseModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateProject(KsProjectDTO project)
        {
            ProjectDTO payload = new ProjectDTO(project);
            var data = await _projectManager.CreateProject(payload);
            return new OkObjectResult(data);
        }
    }
}
