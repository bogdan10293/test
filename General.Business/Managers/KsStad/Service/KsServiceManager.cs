using General.Business.Managers.KsStad.Service;
using General.Data.Core;
using General.Domain.Joins;
using General.Domain.ViewModels.KsStad;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace General.Business.Managers.Service
{
    public class KsServiceManager : IKsServiceManager
    {
        DataContext _context;
        public KsServiceManager(DataContext context)
        {
            _context = context;
        }

        public async Task<KsServiceViewModel> Create(KsServiceViewModel payload)
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

        public async Task<bool> Delete(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Invalid Id");
            }
            KsServiceViewModel data = await _context.KsServices.SingleOrDefaultAsync(x => x.Id == id);
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

        public async Task<IEnumerable<KsServiceViewModel>> GetAll()
        {
            IEnumerable<KsServiceViewModel> result = await _context.KsServices.ToListAsync();
            // OrderServiceEntity model = _mapper.Map<IEnumerable<ServiceViewModel>>(result);
            return result;
        }

        public async Task<KsServiceViewModel> GetById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Invalid Id");
            }
            KsServiceViewModel data = await _context.KsServices
                .Include(e => e.EmployeeServiceJoins).ThenInclude(d => d.KsEmployee)
                .SingleOrDefaultAsync(x => x.Id == id);
            if (data != null)
            {
                if(data.EmployeeServiceJoins != null)
                {
                    data.KsEmployeeIds = new List<int>();
                    foreach (var item in data.EmployeeServiceJoins)
                    {
                        data.KsEmployeeIds.Add(item.EmployeeId);
                    }
                }
                return data;
            }
            else
            {
                return null;
            }
        }

        public async Task<KsServiceViewModel> Update(KsServiceViewModel payload)
        {
            var test = await _context.KsServices.SingleOrDefaultAsync(x => x.Id == payload.Id);
            test.Description = payload.Description;
            test.Price = payload.Price;
            _context.Entry(test).State = EntityState.Modified;
            int dbChanges = await _context.SaveChangesAsync();
            return payload;
        }
    }
}
