using System.Collections.Generic;
using System.Threading.Tasks;
using ConsoleGithubApp.Application.Model;

namespace ConsoleGithubApp.Application.Api
{
    public interface IGithubApiService
    {
        Task<IReadOnlyCollection<CommitDto>> GetCommits(string user, string repo);
    }
}
