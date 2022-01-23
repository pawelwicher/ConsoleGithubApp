using ConsoleGithubApp.Application.Model;
using ConsoleGithubApp.DataAccess.Model;

namespace ConsoleGithubApp.Application.Mapper
{
    public class CommitMapper : ICommitMapper
    {
        public Commit Map(CommitDto dto, string user, string repo) => new Commit()
        {
            Sha = dto.Sha,
            User = user,
            Repo = repo,
            Message = dto.Commit.Message,
            Committer = dto.Commit.Committer.Name
        };
        
    }
}
