using General.Data.Core;
using General.Domain.Joins;
using General.Domain.ViewModels.KsStad;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace General.Business.Managers.KsStad.AdditionalService
{
    public class KsAdditionalServiceManager : IKsAdditionalServiceManager
    {
        DataContext _context;

        public KsAdditionalServiceManager(DataContext context)
        {
            _context = context;
        }
        public async Task<KsServiceAdditionalViewModel> Create(KsServiceAdditionalViewModel payload)
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
        public async Task<IEnumerable<KsServiceAdditionalViewModel>> GetAll()
        {
            IEnumerable<KsServiceAdditionalViewModel> data = await _context.KsAdditionalServices.ToListAsync();
            return data;
        }
        public async Task<bool> Delete(int id)
        {
            if(id <= 0)
            {
                throw new Exception("Invalid Id");
            }
            KsServiceAdditionalViewModel data = await _context.KsAdditionalServices.SingleOrDefaultAsync(x => x.Id == id);
                if(data == null)
            {
                return false;
            }
            else
            {
                _context.Remove(data);
               int dbChanges =  await _context.SaveChangesAsync();
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
        public async Task<KsServiceAdditionalViewModel> GetById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Invalid Id");
            }
            KsServiceAdditionalViewModel data = await _context.KsAdditionalServices.SingleOrDefaultAsync(x => x.Id == id);

            if (data != null)
            {
                return data;
            }
            else
            {
                return null;
            }
        }
        public async Task<KsServiceAdditionalViewModel> Update(KsServiceAdditionalViewModel payload)
        {
            _context.Entry(payload).State = EntityState.Modified;
            int dbChanges = await _context.SaveChangesAsync();
            //if (dbChanges)
            //{
            //    return payload;
            //}
            //else
            //{
            //    return null;
            //}
            return payload;
        }
        
    }
}
