using General.Domain.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TangellaServices;

namespace General.Business.Managers.Tangella.TFreeTimeSlots
{
    public interface ITFreeTimeslotsManager
    {
        Task<List<TangellaServices.EventWithWorkAddress>> GetAllFreeTimeSlots(DateTime from, DateTime to, int employeeId);
        Task<FreeTimeSlot[]> PostFreeTimeslotsById(FilterFreeTimeSlots payload);
        Task<List<TangellaServices.FreeTimeSlot>> GetFreeTimeSlotsAsync(DateTime startDate, DateTime endDate, bool monday, bool tuesday, bool wednesday, bool thursday, bool friday, bool saturday, bool sunday, int serviceId);
    }
}
