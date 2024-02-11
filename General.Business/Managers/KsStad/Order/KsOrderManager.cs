using General.Business.Managers.KsStad.Customer;
using General.Data.Core;
using General.Domain.ViewModels;
//using General.Domain.ViewModels.JIffyTidyViewModels;
using General.Domain.ViewModels.KsStad;
using System;
using System.Threading.Tasks;

namespace General.Business.Managers.KsStad.Order
{
    public class KsOrderManager : IKsOrderManager
    {
        DataContext _context;
        // dependencie injection
        IKsCustomerManager _customerManager;
        public KsOrderManager(DataContext context, IKsCustomerManager customerManager)
        {
            _context = context;
            _customerManager = customerManager;
        }
        public async Task<KsOrderEntity> Create(KsOrderEntity payload)
        {
            try
            {
                //WebOrderFormReturnViewModel tangellapayload = new WebOrderFormReturnViewModel() {
                //    FurAnimalsIsOnSite = false,
                //    CustomerName = payload.name
                //};

                if (payload == null)
                {
                    throw new Exception("No Data");
                }
                if(payload.CustomerFK == 0)
                {
                    KsApiResultViewModel<KsCustomerEntity> result = await _customerManager.Create(payload.Customer);
                    if(!result.IsSuccess)
                    {
                        throw new Exception("Couldn't create customer");
                    }
                    else
                    {
                        payload.CustomerFK = result.Data.Id;
                    }
                    
                }
                await _context.AddAsync(payload);
                int dbChanges = await _context.SaveChangesAsync();
                if(dbChanges > 0)
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
                string messsage = ex.Message;
                return null;
            }
        }
    }
}
