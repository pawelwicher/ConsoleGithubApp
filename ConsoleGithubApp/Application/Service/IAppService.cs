using System.Threading.Tasks;

namespace ConsoleGithubApp.Application.Service
{
    public interface IAppService
    {
        Task Run(string[] args);
    }
}
