using General.Data.Core;
//using General.Domain.Joins;
using General.Domain.ViewModels;
using General.Domain.ViewModels.KsStad;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace General.Business.Managers.KsStad.Employee
{
    public class KsEmployeeManager: IKsEmployeeManager
    {
        DataContext _context;
        public KsEmployeeManager(DataContext context)
        {
            _context = context;
        }

        public async Task<KsEmployeeViewModel> Create(KsEmployeeViewModel payload)
        {
            try
            {
                if (payload == null)
                {
                    throw new Exception("No Data");
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
            catch(Exception ex)
            {
                string message = ex.Message;
                return null;
            }
        }

        public async Task<bool> CreateRangeFromTangela(List<KsEmployeeViewModel> payload)
        {
            try
            {
                if (payload == null)
                {
                    throw new Exception("No Data");
                }
                List<KsEmployeeViewModel> finalResult = new List<KsEmployeeViewModel>();
                foreach(var item in payload)
                {
                    if(!_context.KsEmployees.Any(x => x.TangellaId == item.TangellaId))
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

        public async Task<bool> Delete(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Invalid Id");
            }
            KsEmployeeViewModel data = await _context.KsEmployees.SingleOrDefaultAsync(x => x.Id == id);
            if (data == null)
            {
                return false;
            }
            else
            {
                _context.Remove(data);
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
        }

        public async Task<IEnumerable<KsEmployeeViewModel>> GetAll()
        {
            IEnumerable<KsEmployeeViewModel> result = await _context.KsEmployees
                .Include(ed => ed.EmployeeServiceJoins).ThenInclude(d => d.Service)
                .ToListAsync();
            //asNoTrackning..lägg till
            return result;
        }

        public async Task<KsEmployeeViewModel> GetById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Invalid Id");
            }
            KsEmployeeViewModel data = await _context.KsEmployees
                .Include(ed => ed.EmployeeServiceJoins).ThenInclude(d => d.Service)
                .SingleOrDefaultAsync(x => x.TangellaId == id);
            if (data != null)
            {
                if(data.EmployeeServiceJoins != null)
                {
                    data.ServiceIds = new List<int>();
                    foreach(var item in data.EmployeeServiceJoins)
                    {
                        data.ServiceIds.Add(item.ServiceId);
                    }
                }
                return data;
            }
            else
            {
                return null;
            }
          
        }

        public async Task<KsEmployeeViewModel> Update(KsEmployeeViewModel payload)
        {
            payload.Updated = DateTime.Now;
           
            KsEmployeeViewModel existingParent = await _context.KsEmployees
                .Include(p => p.EmployeeServiceJoins)
                .SingleOrDefaultAsync(p => p.Id == payload.Id);

            if (existingParent != null)
            {
                //Update parent
                _context.Entry(existingParent).CurrentValues.SetValues(payload);

                // EmployeeDepartmentJoin
                foreach (var existingChild in existingParent.EmployeeServiceJoins.ToList())
                { 
                    if (!payload.ServiceIds.Any(c => c == existingChild.ServiceId))
                        _context.EmployeeServiceJoins.Remove(existingChild);
                }
                if(payload.ServiceIds != null)
                {
                    foreach (var childModel in payload.ServiceIds)
                    {
                        var existingChild = existingParent.EmployeeServiceJoins.SingleOrDefault(c => c.ServiceId == childModel);
                        if (existingChild != null)
                        {
                            _context.Entry(existingChild).State = EntityState.Modified;
                        }
                        else
                        {
                            var newChild = new EmployeeServiceJoin()
                            {
                                ServiceId = childModel
                            };
                            existingParent.EmployeeServiceJoins.Add(newChild);
                        }
                    }
                }
                // TangellaId is readonly
                _context.Entry(existingParent).State = EntityState.Modified;
                _context.Entry(existingParent).Property(x => x.TangellaId).IsModified = false;
                await _context.SaveChangesAsync();
            }
            return existingParent;
        }
    }
}
