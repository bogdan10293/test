using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace General.Business.Managers.Tangella.TEventWithWorkAddress
{
    public interface ITEventWithWorkAddress
    {
        Task<IEnumerable<TangellaServices.EventWithWorkAddress>> GetEventWithWorkAddress(int supervisorId, int regionId, int employeeId, DateTime fromDate, DateTime toDate);
    }
}
