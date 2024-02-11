using General.Data.Core;
using General.Domain.ViewModels.KsStad;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace General.Business.Managers.KsStad.Supervisor
{
    public class KsSupervisorManager : IKsSupervisorManager
    {
        DataContext _context;
        public KsSupervisorManager(DataContext context)
        {
            _context = context;
        }
        public async Task<KsSupervisorViewModel> Create(KsSupervisorViewModel payload)
        {
            try
            {
                if (payload == null)
                {
                    throw new Exception("No data");
                }
                await _context.AddAsync(payload);
                int dbChanges = await _context.SaveChangesAsync();
                if (dbChanges > 0)
                {
                    return payload;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return null;
            }
        }
        public async Task<IEnumerable<KsSupervisorViewModel>> GetAll()
        {
            IEnumerable<KsSupervisorViewModel> result = await _context.KsSupervisors.ToListAsync();
            return result;
        }
        public async Task<KsSupervisorViewModel> GetById(int id)
        {
                if(id <= 0)
                {
                    throw new Exception("No Data");
                }
                KsSupervisorViewModel data = await _context.KsSupervisors.Include(x => x.KsSupervisorProjectJoins).ThenInclude(d => d.KsProject).SingleOrDefaultAsync(c => c.Id == id);
                if(data != null)
                {
                    if(data.KsSupervisorProjectJoins != null)
                    {
                        data.ProjectIds = new List<int>();
                        data.ProjectRoles = new List<int>();

                    foreach (var item in data.KsSupervisorProjectJoins)
                        {
                            data.ProjectIds.Add(item.KsProjectId);
                        //if(item.SupervisorRole != null)
                        //{
                        //    var test = item.SupervisorRole.Split(",");
                        //    data.ProjectRoles = test.Select(int.Parse).ToList();
                            
                        //    Console.WriteLine(test);
                        //}
                        }
                    }
                    return data;
                }
                else
                {
                    return null;
                }
        }
        public async Task<bool> CreateRange(List<KsSupervisorViewModel> payload)
        {
            try
            {
                if (payload == null)
                {
                    throw new Exception("No Data");
                }
                List<KsSupervisorViewModel> finalResult = new List<KsSupervisorViewModel>();
                foreach (var item in payload)
                {
                    if (!_context.KsSupervisors.Any(x => x.SupervisorId == item.SupervisorId))
                    {
                        finalResult.Add(item);
                    }
                }
                await _context.AddRangeAsync(finalResult);
                int dbChanges = await _context.SaveChangesAsync();
                if (dbChanges > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return true;
            }
        }
    }
}
