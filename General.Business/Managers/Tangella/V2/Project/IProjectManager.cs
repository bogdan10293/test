using General.Domain.DTO.Tengella.v2.Project;
using System.Threading.Tasks;

namespace General.Business.Managers.Tangella.V2.Project
{
    public interface IProjectManager
    {
        Task<ProjectResponseModel> CreateProject(ProjectDTO project);
    }
}
