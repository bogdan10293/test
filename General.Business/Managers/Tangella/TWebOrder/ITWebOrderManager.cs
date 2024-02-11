using General.Domain.ViewModels.Tangella;
using System.Threading.Tasks;

namespace General.Business.Managers.Tangella.TWebOrder
{
    public interface ITWebOrderManager
    {
        Task<string> TestApiGetWebOrderFormsAsync(string zipCode);
        Task<int> TestApiAddWebOrderAsync(WebOrderFormReturnViewModel payload);
    }
}
