using System.Collections.Generic;
using System.Threading.Tasks;
using ConsoleGithubApp.DataAccess.Model;

namespace ConsoleGithubApp.DataAccess.Repository
{
    public interface ICommitRepository
    {
        Task Insert(IReadOnlyCollection<Commit> commits);

        Task Delete(string user, string repo);
    }
}
