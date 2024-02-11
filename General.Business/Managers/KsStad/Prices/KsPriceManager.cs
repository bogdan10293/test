using General.Business.Managers.KsStad.Prices;
using General.Data.Core;
using General.Domain.ViewModels.KsStad;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace General.Business.Managers.Prices
{
    public class KsPriceManager : IKsPriceManager
    {
        DataContext _context;
        public KsPriceManager(DataContext context)
        {
            _context = context;
        }
        public async Task<KsPriceViewModel> Create(KsPriceViewModel payload)
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
        public async Task<IEnumerable<KsPriceViewModel>> GetAll()
        {
            // IEnumerable<KsPriceViewModel> result = await _context.KsPrices.ToListAsync();
            return null;
        }
        public async Task<bool> Delete(int id)
        {
            if(id <= 0)
            {
                throw new Exception("Invalid Id");
            }
            //KsPriceViewModel data = await _context.KsPrices.SingleOrDefaultAsync(x => x.Id == id);
            //    if (data == null)
            //{
            //    return false;
            //}
            //    else
            //{
            //    _context.Remove(data);
            //    int dbChanges = await _context.SaveChangesAsync();
            //    if(dbChanges > 0)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            return true;
        }
        public async Task<KsPriceViewModel> GetById(int id)
        {
            //if(id <= 0)
            //{
            //    throw new Exception("Invalid Id");
            //}
            //KsPriceViewModel data = await _context.KsPrices.SingleOrDefaultAsync(x => x.Id == id);
            //if(data != null)
            //{
            //    return data;
            //}
            //else
            //{
            //    return null;
            //}
            return null;
        }
    }
}
