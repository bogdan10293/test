using General.Data.Core;
using General.Domain.Filters;
using General.Domain.ViewModels;
using General.Domain.ViewModels.KsStad;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TangellaServices;

namespace General.Business.Managers.Tangella.TFreeTimeSlots
{
    public class TFreeTimeslotsManager : ITFreeTimeslotsManager
    {
        CustomerServiceClient tangellaClient;
        DataContext _context;
        public TFreeTimeslotsManager(DataContext context)
        {
            _context = context;
            BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportWithMessageCredential);
            // increased received message size, maybe remove if useless
            binding.MaxReceivedMessageSize = 2048000;
            binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;

            tangellaClient = new CustomerServiceClient(binding, new EndpointAddress("https://api.tengella.se/CustomerService.svc"));

            tangellaClient.ClientCredentials.UserName.UserName = "170-0004";
            tangellaClient.ClientCredentials.UserName.Password = "DACB1A0B41ED4F3E9F7B4C813F10507E96DF4EE1BA4F4B73A3B0FE0E35744510";
        }
        public async Task<List<TangellaServices.EventWithWorkAddress>> GetAllFreeTimeSlots(DateTime from, DateTime to, int employeeId)
        {
            try
            {
                List<EventWithWorkAddress> freeSlotList = new List<EventWithWorkAddress>();
                
                if(employeeId == 0)
                {
                    List<KsEmployeeViewModel> result = await _context.KsEmployees.ToListAsync();
                    foreach (var employee in result)
                    {
                        var data = await tangellaClient.GetEventsWithWorkAddressAsync(from, to, 0, 0, employee.TangellaId);
                        freeSlotList.AddRange(data);
                    }
                }
                else
                {
                    var data = await tangellaClient.GetEventsWithWorkAddressAsync(from, to, 0, 0, employeeId);
                    freeSlotList.AddRange(data);
                }

                return freeSlotList;
            }
            catch (Exception ex)
             {
                string message = ex.Message;
             }
            return null;
        }
        public async Task<List<FreeTimeSlot>> GetFreeTimeSlotsAsync(DateTime startDate, DateTime endDate, bool monday, bool tuesday, bool wednesday, bool thursday, bool friday, bool saturday, bool sunday, int serviceId)
        {
            List<KsEmployeeViewModel> avaibleEmps = new List<KsEmployeeViewModel>();
            var joins = await _context.EmployeeServiceJoins.Include(e => e.KsEmployee).Where(x => x.ServiceId == serviceId).AsNoTracking().ToListAsync();
            var data = await tangellaClient.GetFreeTimeSlotsAsync(startDate, endDate, monday, tuesday, wednesday, thursday, friday, saturday, sunday);
            var employeeFreeSlots = data.Where(x => joins.Any(y => y.KsEmployee.TangellaId == x.EmployeeId));

            return employeeFreeSlots.ToList();
        }
        public async Task<FreeTimeSlot[]> PostFreeTimeslotsById(FilterFreeTimeSlots payload)
        {
            try
            {
                if(payload.EmployeeId == 0)
                {
                    List<FreeTimeSlot> result = new List<FreeTimeSlot>();
                    var employees = await _context.KsEmployees.Where(x => x.IsDeleted == false).ToListAsync();
                    foreach(var employee in employees)
                    {
                        var freeSlots1 = await tangellaClient.GetFreeTimeSlotsAsync(
                            payload.FromDT,
                            payload.ToDT,
                            payload.Monday,
                            payload.Tuesday,
                            payload.Wednesday,
                            payload.Thursday,
                            payload.Friday,
                            payload.Saturday,
                            payload.Sunday);
                        result.AddRange(freeSlots1.ToList());
                    };
                    return result.ToArray();
                }
                var freeSlots = await tangellaClient.GetFreeTimeSlotsAsync(
                    payload.FromDT,
                    payload.ToDT,
                    payload.Monday,
                    payload.Tuesday,
                    payload.Wednesday,
                    payload.Thursday,
                    payload.Friday,
                    payload.Saturday,
                    payload.Sunday);

                return freeSlots;
            }
            catch (Exception ex)
            {
            }
            return null;
        }
    }
}
