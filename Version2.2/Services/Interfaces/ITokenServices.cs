using System.Threading.Tasks;

namespace Version2.Services
{
    public interface ITokenServices
    {
        Task<string> ProvideAccessToken();
    }
}