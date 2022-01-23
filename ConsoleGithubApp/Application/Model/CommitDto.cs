namespace ConsoleGithubApp.Application.Model
{
    public class CommitDto
    {
        public string Sha { get; set; }

        public CommitInfoDto Commit { get; set; }
    }
}
