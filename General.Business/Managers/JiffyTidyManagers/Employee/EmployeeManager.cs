//using General.Data.Core;
//using General.Domain.ViewModels.JIffyTidyViewModels;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace General.Business.Managers.JiffyTidyManagers.Employee
//{
//    public class EmployeeManager : IEmployeeManager
//    {
//        DataContext _context;
//        public EmployeeManager(DataContext context)
//        {
//            _context = context;
//        }
//        public async Task<EmployeeEntity> Create(EmployeeEntity payload)
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
//        public async Task<IEnumerable<EmployeeEntity>> GetAll()
//        {
//            IEnumerable<EmployeeEntity> result = await _context.Employees.ToListAsync();
//            return result;
//        }
//        public async Task<EmployeeEntity> GetById(Guid id)
//        {
//            EmployeeEntity data = await _context.Employees.SingleOrDefaultAsync(x => x.Id == id);
//            if(data != null)
//            {
//                return data;
//            }
//            else
//            {
//                return null;
//            }
//        }
//        public async Task<bool> Delete(Guid id)
//        {
//            EmployeeEntity data = await _context.Employees.SingleOrDefaultAsync(x => x.Id == id);
//            if(data == null)
//            {
//                return false;
//            }
//            else
//            {
//                _context.Remove(data);
//                int dbChanges = await _context.SaveChangesAsync();
//                if (dbChanges > 0)
//                {
//                    return true;
//                }
//                else
//                {
//                    return false;
//                }
//            }
//        }
//        public async Task<EmployeeEntity> Update(EmployeeEntity payload)
//        {
//            _context.Entry(payload).State = EntityState.Modified;
//            int dbChanges = await _context.SaveChangesAsync();
//            return payload;
//        }
//    }
//}
