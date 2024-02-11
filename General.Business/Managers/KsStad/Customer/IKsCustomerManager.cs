using General.Domain.ViewModels.KsStad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace General.Business.Managers.KsStad.Customer
{
    public interface IKsCustomerManager
    {
        Task<KsApiResultViewModel<KsCustomerEntity>> Create(KsCustomerEntity payload);
        Task<KsApiResultViewModel<KsCustomerEntity>> Update(KsCustomerEntity payload);
        Task<bool> Delete(int id);
        Task<IEnumerable<KsCustomerEntity>> GetAll();
        Task<KsCustomerEntity> GetById(int id);
    }
}
