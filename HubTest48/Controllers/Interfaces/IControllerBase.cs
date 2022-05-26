using System.Threading.Tasks;

namespace HubTest48.Controllers
{
    internal interface IControllerBase
    {
        Task CloseConnection();
        Task InitializeConnection();
    }
}