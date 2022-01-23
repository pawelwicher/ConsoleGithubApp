using Microsoft.EntityFrameworkCore;
using ConsoleGithubApp.DataAccess.Model;

namespace ConsoleGithubApp.DataAccess.Repository
{
    public class CommitDbContext : DbContext
    {
        public CommitDbContext(DbContextOptions<CommitDbContext> options)
            : base(options)
        {
        }

        public DbSet<Commit> Commits { get; set; }
    }
}
