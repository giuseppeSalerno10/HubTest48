using System.Threading.Tasks;

namespace HubTest48.Controllers
{
    internal interface ICommandsController : IControllerBase
    {
        Task SendInfoToApp();
    }
}