using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace General.Business.Managers.Tangella.TSupervisor
{
    public interface ITSupervisorManager
    {
        Task<List<TangellaServices.Supervisor>> GetSupervisors();
    }
}
