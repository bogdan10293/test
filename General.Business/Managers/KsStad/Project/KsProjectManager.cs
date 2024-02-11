using General.Data.Core;
using General.Domain.ViewModels.KsStad;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using General.Business.Managers.KsStad.Customer;
using System.Linq;
using General.Domain.Joins;

namespace General.Business.Managers.KsStad.Project
{
    public class KsProjectManager :IKsProjectManager
    {
        DataContext _context;
        IKsCustomerManager _customerManager;
        public KsProjectManager(DataContext context, IKsCustomerManager customerManager)
        {
            _context = context;
            _customerManager = customerManager;
        }
        public async Task<KsApiResultViewModel<KsProjectViewModel>> Create (KsProjectViewModel payload)
        {
            KsApiResultViewModel<KsProjectViewModel> result;
            try
            {
                if(payload == null)
                {
                    throw new Exception("No Data");
                }
                //KsCustomerEntity customer = (KsCustomerEntity) await _customerManager.GetAll();
                //foreach(var address in customer.Address)
                //{
                //    if(address.ZipCode == payload.ZipCode)
                //    {
                //        Console.wri
                //    }
                //}
                await _context.AddAsync(payload);
                int dbChanges = await _context.SaveChangesAsync();
                if(dbChanges > 0)
                {
                    result = new KsApiResultViewModel<KsProjectViewModel>
                    {
                        IsSuccess = true,
                        Message = "Projektet har skapats",
                        Data = payload
                    };
                }
                else
                {
                    result = new KsApiResultViewModel<KsProjectViewModel>
                    {
                        IsSuccess = false,
                        Message = "Projektet kunde ej skapas!",
                        Data = payload
                    };
                }
            }
            catch(Exception ex)
            {
                result = new KsApiResultViewModel<KsProjectViewModel>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Data = null
                };
            }
            return result;
        }
      public async Task<bool> Delete(int id)
        {
            if(id <= 0)
            {
                throw new Exception("Invalid Id");
            }
            KsProjectViewModel data = await _context.KsProjects.SingleOrDefaultAsync(x => x.Id == id);
            if (data == null)
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
        public async Task<IEnumerable<KsProjectViewModel>> GetAll()
        {
            IEnumerable<KsProjectViewModel> result = await _context.KsProjects
                .Include(x => x.KsCustomerProjectJoins)
                .ToListAsync();
            return result;
        }
        public async Task<KsProjectViewModel> GetById(int id)
        {
            if(id <= 0)
            {
                throw new Exception("Invalid Id");
            }
            KsProjectViewModel data = await _context.KsProjects
                .Include(x => x.KsCustomerProjectJoins).ThenInclude(c => c.KsCustomer)
                .Include(z => z.KsSupervisorProjectJoins).ThenInclude(x => x.KsSupervisor)
                .SingleOrDefaultAsync(x => x.Id == id);
            //var numberOfCustomers = data.KsCustomerProjectJoins.Count;
            if(data != null)
            {
                if (data.KsSupervisorProjectJoins != null)
                {
                    data.KsSupervisorIds = new List<int>();
                    foreach (var item in data.KsSupervisorProjectJoins)
                    {
                        try
                        {
                            if (item.SupervisorRole == null)
                            {
                                throw new Exception("No Data");
                            }
                            data.KsSupervisorIds.Add(item.KsSupervisorId);
                            var test = item.SupervisorRole.Split(",");
                            item.KsSupervisor.ProjectRoles = test.Select(int.Parse).ToList();
                        }
                        catch (Exception ex)
                        {
                            string message = ex.Message;
                        }
                       
                    }
                }
                if(data.KsCustomerProjectJoins != null)
                {
                    data.KsCustomerIds = new List<int>();
                    foreach(var item in data.KsCustomerProjectJoins)
                    {
                        data.KsCustomerIds.Add(item.KsCustomerId);
                    }
                }
                return data;
            }
            else
            {
                return null;
            }
        }
        public async Task<KsProjectViewModel> Update(KsProjectViewModel payload)
        {
            payload.Updated = DateTime.Now;

            KsProjectViewModel existingParent = await _context.KsProjects
                .Include(p => p.KsSupervisorProjectJoins)
                .SingleOrDefaultAsync(p => p.Id == payload.Id);

            if (existingParent != null)
            {
                //Update parent
                _context.Entry(existingParent).CurrentValues.SetValues(payload);

                // KsSupervisorProjectJoins
                foreach (var existingChild in existingParent.KsSupervisorProjectJoins.ToList())
                {
                    if (!payload.KsSupervisorIds.Any(c => c == existingChild.KsSupervisorId))
                        _context.KsSupervisorProjectJoins.Remove(existingChild);
                }
                if (payload.KsSupervisorIds != null)
                {
                    foreach (var childModel in payload.KsSupervisorIds)
                    {
                        var existingChild = existingParent.KsSupervisorProjectJoins.SingleOrDefault(c => c.KsSupervisorId == childModel);
                        if (existingChild != null)
                        {
                            _context.Entry(existingChild).State = EntityState.Modified;
                        }
                        else
                        {
                            var newChild = new KsSupervisorProjectJoin()
                            {
                                KsSupervisorId = childModel
                            };
                            existingParent.KsSupervisorProjectJoins.Add(newChild);
                        }
                    }
                }
                _context.Entry(existingParent).State = EntityState.Modified;
                _context.Entry(existingParent).Property(x => x.Created).IsModified = false;
                await _context.SaveChangesAsync();
            }
            return existingParent;
        }
    }
}
