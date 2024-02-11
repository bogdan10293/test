using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace General.Business.Managers.Tangella.TProject
{
    public interface ITProjectManager
    {
        Task<TangellaServices.Project[]> GetProjectsAsync(int customerId, bool includeDeleted);
    }
}
