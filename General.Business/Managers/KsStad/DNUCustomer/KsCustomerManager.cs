//using General.Data.Core;
//using General.Domain.ViewModels;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace General.Business.Managers.Customer
//{
//    public class KsCustomerManager : IKsCustomerManager
//    {
//        DataContext _context;
//        public KsCustomerManager(DataContext context)
//        {
//            _context = context;
//        }

//        public async Task<KsCustomerViewModel> Create(KsCustomerViewModel payload)
//        {
//            try
//            {
//                if(payload == null)
//                {
//                    throw new Exception("No Data");
//                }
//                await _context.AddAsync(payload);
//                int dbChanges = await _context.SaveChangesAsync();
//                if(dbChanges > 0)
//                {
//                    return payload;
//                }
//                else
//                {
//                    return null;
//                }
//            }
//            catch(Exception ex)
//            {
//                string message = ex.Message;
//                return null;
//            }
//        }
//        public async Task<bool> Delete(int id)
//        {
//            if(id <= 0)
//            {
//                throw new Exception("Invalid Id");
//            }
//            KsCustomerViewModel data = await _context.KsCustomer.SingleOrDefaultAsync(x => x.Id == id);
//            if(data == null)
//            {
//                return false;
//            }
//            else
//            {
//                _context.Remove(data);
//                int dbChanges = await _context.SaveChangesAsync();
//                if(dbChanges > 0)
//                {
//                    return true;
//                }
//                else
//                {
//                    return false;
//                }
//            }
//        }
//        public async Task<IEnumerable<KsCustomerViewModel>> GetAll()
//        {
//            IEnumerable<KsCustomerViewModel> data = await _context.KsCustomer.ToListAsync();
//            return data;
//        }
//        public async Task<KsCustomerViewModel> GetById(int id)
//        {
//            if (id <= 0)
//            {
//                throw new Exception("Invalid Id");
//            }
//            KsCustomerViewModel data = await _context.KsCustomer.SingleOrDefaultAsync(x => x.Id == id);
//            if (data != null)
//            {
//                return data;
//            }
//            else
//            {
//                return null;
//            }

//        }
//        public async Task<KsCustomerViewModel> Update(KsCustomerViewModel payload)
//        {
//            _context.Entry(payload).State = EntityState.Modified;
//            int dbChanges = await _context.SaveChangesAsync();
//            return payload;
//        }
//    }
//}
