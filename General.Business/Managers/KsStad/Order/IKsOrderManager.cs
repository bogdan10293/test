using General.Domain.ViewModels.KsStad;
using System.Threading.Tasks;

namespace General.Business.Managers.KsStad.Order
{
    public interface IKsOrderManager
    {
        Task<KsOrderEntity> Create(KsOrderEntity payload);
    }
}
