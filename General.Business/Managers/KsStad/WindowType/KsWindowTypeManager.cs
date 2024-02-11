using General.Data.Core;
using General.Domain.ViewModels.KsStad;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace General.Business.Managers.KsStad.WindowType
{
    public class KsWindowTypeManager : IKsWindowTypeManager
    {
        DataContext _context;
        public KsWindowTypeManager(DataContext context)
        {
            _context = context;
        }
        public async Task<KsWindowTypeViewModel> Create(KsWindowTypeViewModel payload)
        {
            if(payload == null)
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
        public async Task<IEnumerable<KsWindowTypeViewModel>> GetAll()
        {
            IEnumerable<KsWindowTypeViewModel> data = await _context.KsWindowTypes.ToListAsync();
            return data;
        }
        public async Task<bool> Delete(int id)
        {
            if(id <= 0)
            {
                throw new Exception("Invalid Id");
            }
            KsWindowTypeViewModel data = await _context.KsWindowTypes.SingleOrDefaultAsync(x => x.Id == id);
            if(data == null)
            {
                return false;
            }
            else
            {
                _context.Remove(data);
                int dbChanges = await _context.SaveChangesAsync();
                if(dbChanges > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public async Task<KsWindowTypeViewModel> GetById(int id)
        {
            if(id <= 0)
            {
                throw new Exception("Invalid Id");
            }
            KsWindowTypeViewModel data = await _context.KsWindowTypes.SingleOrDefaultAsync(x => x.Id == id);
            if(data != null)
            {
                return data;
            }
            else
            {
                return null;
            }
        }
        public async Task<KsWindowTypeViewModel> Update(KsWindowTypeViewModel payload)
        {
            _context.Entry(payload).State = EntityState.Modified;
            int dbChanges = await _context.SaveChangesAsync();
            return payload;
        }
    }
}
