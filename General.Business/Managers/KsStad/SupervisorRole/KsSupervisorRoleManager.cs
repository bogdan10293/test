using General.Data.Core;
using General.Domain.ViewModels.KsStad;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace General.Business.Managers.KsStad.SupervisorRole
{
    public class KsSupervisorRoleManager : IKsSupervisorRoleManager
    {
        DataContext _context;
        public KsSupervisorRoleManager(DataContext context)
        {
            _context = context;
        }
        public async Task<KsApiResultViewModel<KsSupervisorRoleViewModel>> Create(KsSupervisorRoleViewModel payload)
        {
            KsApiResultViewModel<KsSupervisorRoleViewModel> result;
            try
            {
                if(payload == null)
                {
                    throw new Exception("No Data");
                }

                await _context.AddAsync(payload);
                int dbChanges = await _context.SaveChangesAsync();
                if(dbChanges > 0)
                {
                    result = new KsApiResultViewModel<KsSupervisorRoleViewModel>
                    {
                        IsSuccess = true,
                        Message = "Allt gick bra",
                        Data = payload
                    };
                }
                else
                {
                    result = new KsApiResultViewModel<KsSupervisorRoleViewModel>
                    {
                        IsSuccess = false,
                        Message = "Det gick inte att lägga till titeln",
                        Data = payload
                    };
                }
            }
            catch(Exception ex)
            {
                result = new KsApiResultViewModel<KsSupervisorRoleViewModel>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Data = null
                };
            }
            return result;
        }
        public async Task<IEnumerable<KsSupervisorRoleViewModel>> GetAll()
        {
            IEnumerable<KsSupervisorRoleViewModel> data = await _context.KsSupervisorRoles.ToListAsync();
            return data;
        }
        public async Task<KsSupervisorRoleViewModel> GetById(int id)
        {
            if(id <= 0)
            {
                throw new Exception("No Data");
            }
            KsSupervisorRoleViewModel data = await _context.KsSupervisorRoles.SingleOrDefaultAsync(x => x.Id == id);
            if(data != null)
            {
                return data;
            }
            else
            {
                return null;
            }
        }
        public async Task<KsApiResultViewModel<KsSupervisorRoleViewModel>> Update(KsSupervisorRoleViewModel payload)
        {
            KsApiResultViewModel<KsSupervisorRoleViewModel> result;
            try
            {
                if(payload == null)
                {
                    throw new Exception("No Data");
                }
                KsSupervisorRoleViewModel role = await _context.KsSupervisorRoles.SingleOrDefaultAsync(x => x.Id == payload.Id);
                _context.Entry(role).CurrentValues.SetValues(payload);
                _context.Entry(role).State = EntityState.Modified;
                int dbChanges = await _context.SaveChangesAsync();
                if(dbChanges > 0)
                {
                    result = new KsApiResultViewModel<KsSupervisorRoleViewModel>
                    {
                        IsSuccess = true,
                        Data = payload,
                        Message = "Uppdatering genomförd"
                    };
                }
                else
                {
                    result = new KsApiResultViewModel<KsSupervisorRoleViewModel>
                    {
                        IsSuccess = false,
                        Message = "Uppdatering misslyckad",
                        Data = payload
                    };
                }
            }
            catch (Exception ex)
            {
                result =  new KsApiResultViewModel<KsSupervisorRoleViewModel>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Data = null
                };
            }
            return result;
        }
    }
}
