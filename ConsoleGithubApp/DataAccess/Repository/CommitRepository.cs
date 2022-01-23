using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleGithubApp.DataAccess.Model;

namespace ConsoleGithubApp.DataAccess.Repository
{
    public class CommitRepository : ICommitRepository
    {
        private readonly CommitDbContext _commitDbContext;

        public CommitRepository(
            CommitDbContext commitDbContext)
        {
            _commitDbContext = commitDbContext;
        }

        public async Task Insert(IReadOnlyCollection<Commit> commits)
        {
            _commitDbContext.Commits
                .AddRange(commits);

            await _commitDbContext
                .SaveChangesAsync();
        }

        public async Task Delete(string user, string repo)
        {
            var commits = _commitDbContext.Commits
                .Where(c => c.User == user && c.Repo == repo);

            _commitDbContext.Commits
                .RemoveRange(commits);

            await _commitDbContext
                .SaveChangesAsync();
        }
    }
}
