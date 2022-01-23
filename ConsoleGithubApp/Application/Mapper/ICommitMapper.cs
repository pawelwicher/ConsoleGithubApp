using ConsoleGithubApp.Application.Model;
using ConsoleGithubApp.DataAccess.Model;

namespace ConsoleGithubApp.Application.Mapper
{
    public interface ICommitMapper
    {
        Commit Map(CommitDto dto, string user, string repo);
    }
}
