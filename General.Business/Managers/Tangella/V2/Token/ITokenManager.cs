using System.Threading.Tasks;

namespace General.Business.Managers.Tangella.V2.Token
{
    public interface ITokenManager
    {
        Task<string> GetToken();
    }
}
