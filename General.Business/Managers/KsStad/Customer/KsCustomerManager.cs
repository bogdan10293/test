using General.Data.Core;
using General.Domain.Joins;
using General.Domain.ViewModels.KsStad;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace General.Business.Managers.KsStad.Customer
{
    public class KsCustomerManager : IKsCustomerManager
    {
        DataContext _context;
        public KsCustomerManager(DataContext context)
        {
            _context = context;
        }
        public async Task<KsApiResultViewModel<KsCustomerEntity>> Create(KsCustomerEntity payload)
        {
            KsApiResultViewModel<KsCustomerEntity> result;
            try
            {
                
                if (payload == null)
                {
                    throw new Exception("No Data");
                }
                //bool isValidEmail = _context.KsCustomers.Any(x => x.Email == payload.Email);

                if (payload.CustomerMode == Domain.Enums.KsStad.CustomerModeEnums.Company)
                {
                    if (_context.KsCustomers.Any(x => x.CompanyNo == payload.CompanyNo))
                    {
                        throw new Exception("CompanyNo already exist in database");
                    }
                }
                if(payload.CustomerMode == Domain.Enums.KsStad.CustomerModeEnums.Private)
                {
                    if(_context.KsCustomers.Any(x => x.DateOfBirth == payload.DateOfBirth))
                    {
                        throw new Exception("DateOfBirth already exist in database");
                    }
                }
              
             
                await _context.AddAsync(payload);
                int dbChanges = await _context.SaveChangesAsync();
                if (dbChanges > 0)
                {
                    result = new KsApiResultViewModel<KsCustomerEntity>
                    {
                        IsSuccess = true,
                        Message = "Den har skapats",
                        Data = payload
                    };
                }
                else
                {
                    result = new KsApiResultViewModel<KsCustomerEntity>
                    {
                        IsSuccess = false,
                        Message = "Kunde ej skapas!",
                        Data = payload
                    };
                }
            }
            catch (Exception ex)
            {
                result = new KsApiResultViewModel<KsCustomerEntity>
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Data = null
                };
            }
            return result;
        }
        public async Task<IEnumerable<KsCustomerEntity>> GetAll()
        {
            IEnumerable<KsCustomerEntity> result = await _context.KsCustomers
                .Include(ed => ed.KsCustomerProjectJoins).ThenInclude(d => d.KsProject)
                .Include(z => z.Address).AsNoTracking()
                .ToListAsync();
            return result;
        }
        public async Task<KsCustomerEntity> GetById(int id)
        {
            KsCustomerEntity data = await _context.KsCustomers
                .Include(ed => ed.KsCustomerProjectJoins).ThenInclude(d => d.KsProject)
                .Include(ed => ed.Address).AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
            if (data != null)
            {
                if (data.KsCustomerProjectJoins != null)
                {
                    data.ProjectIds = new List<int>();
                    foreach (var item in data.KsCustomerProjectJoins)
                    {
                        data.ProjectIds.Add(item.KsProjectId);
                    }
                }
                return data;
            }
            else
            {
                return null;
            }
        }
        public async Task<bool> Delete(int id)
        {
            KsCustomerEntity data = await _context.KsCustomers.SingleOrDefaultAsync(x => x.Id == id);
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
        public async Task<KsApiResultViewModel<KsCustomerEntity>> Update(KsCustomerEntity payload)
        {
            KsApiResultViewModel<KsCustomerEntity> result;
            try
            {

                KsCustomerEntity customer = await _context.KsCustomers.Include(c => c.Address).Include(p => p.KsCustomerProjectJoins).SingleOrDefaultAsync(z => z.Id == payload.Id);

                _context.Entry(customer).CurrentValues.SetValues(payload);

                foreach (var existingChild in customer.Address.ToList())
                {
                //if not existing, remove 
                if (!payload.Address.Any(c => c.Id == existingChild.Id))
                    _context.KsCustomerAddress.Remove(existingChild);
                }
                if (payload.Address != null)
                {
                    foreach (var childModel in payload.Address)
                    {
                    // kollar första id och är noll och sen kollar att id inte är default, annars skrivs första objektet över
                        var existingChild = customer.Address.SingleOrDefault(c => c.Id == childModel.Id && c.Id != default);
                        if (existingChild != null)
                        {
                          _context.Entry(existingChild).CurrentValues.SetValues(childModel);
                        }
                     else
                        {
                            var newChild = new KsAddressViewModel()
                            {
                                Address = childModel.Address,
                                Address2 = childModel.Address2,
                                Country = childModel.Country,
                                City = childModel.City,
                                IsBillingAddress = childModel.IsBillingAddress,
                                ZipCode = childModel.ZipCode,
                                KsCustomerFk = childModel.KsCustomerFk
                            };
                            customer.Address.Add(newChild);
                        }
                    }
                }
                
                foreach(var existingChild in customer.KsCustomerProjectJoins.ToList())
                {
                    if (!payload.ProjectIds.Any(z => z == existingChild.KsProjectId))
                        _context.KsCustomerProjectJoins.Remove(existingChild);
                }
                if(payload.ProjectIds != null)
                {
                    foreach(var childModel in payload.ProjectIds)
                    {
                        var existingChild = customer.KsCustomerProjectJoins.SingleOrDefault(x => x.KsProjectId == childModel);
                        if(existingChild != null)
                        {
                            _context.Entry(existingChild).State = EntityState.Modified;
                        }
                        else
                        {
                            var newChild = new KsCustomerProjectJoin()
                            {
                                KsProjectId = childModel
                            };
                            customer.KsCustomerProjectJoins.Add(newChild);
                        }
                    }
                }
                _context.Entry(customer).State = EntityState.Modified;
                
                int dbChanges = await _context.SaveChangesAsync();
                    if (dbChanges > 0)
                    {
                        result = new KsApiResultViewModel<KsCustomerEntity>
                        {
                            IsSuccess = true,
                            Message = "Kunduppgifter har uppdaterats",
                            Data = payload
                        };
                    }
                    else
                    {
                        result = new KsApiResultViewModel<KsCustomerEntity>
                        {
                            IsSuccess = false,
                            Message = "Kunduppgifter kunde ej uppdateras!",
                            Data = payload
                        };
                    }
                    //return payload;
                }
                catch (Exception ex)
                {
                    result = new KsApiResultViewModel<KsCustomerEntity>
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
