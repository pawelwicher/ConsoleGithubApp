using System.ComponentModel.DataAnnotations;

namespace ConsoleGithubApp.DataAccess.Model
{
    public class Commit
    {
        [Key]
        public string Sha { get; set; }

        public string User { get; set; }

        public string Repo { get; set; }

        public string Message { get; set; }

        public string Committer { get; set; }

    }
}
