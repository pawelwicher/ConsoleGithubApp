using System;
using System.CommandLine;
using System.Linq;
using System.Threading.Tasks;
using ConsoleGithubApp.Application.Api;
using ConsoleGithubApp.Application.Mapper;
using ConsoleGithubApp.DataAccess.Repository;

namespace ConsoleGithubApp.Application.Service
{
    public class AppService : IAppService
    {
        private readonly IGithubApiService _githubApiService;
        private readonly ICommitRepository _commitRepository;
        private readonly ICommitMapper _commitMapper;

        public AppService(
            IGithubApiService githubApiService,
            ICommitRepository commitRepository,
            ICommitMapper commitMapper)
        {
            _githubApiService = githubApiService;
            _commitRepository = commitRepository;
            _commitMapper = commitMapper;
        }

        public async Task Run(string[] args)
        {
            await GetRootCommand()
                .InvokeAsync(args);
        }

        private async Task DoWork(string user, string repo)
        {
            try
            {
                var commits = await _githubApiService
                    .GetCommits(user, repo);

                await _commitRepository
                    .Delete(user, repo);

                var models = commits
                    .Select(c => _commitMapper.Map(c, user, repo))
                    .ToArray();

                await _commitRepository.Insert(
                    models);

                foreach (var model in models)
                {
                    Console.WriteLine($"[{repo}]/[{model.Sha}]: {model.Message} [{model.Committer}]");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private RootCommand GetRootCommand()
        {
            var userOption = new Option<string>(
                name: "--user",
                description: "Github user parameter")
            {
                IsRequired = true
            };

            var repoOption = new Option<string>(
                    name: "--repo",
                    description: "Github repository parameter")
            {
                IsRequired = true
            };

            var rootCommand = new RootCommand()
            {
                userOption,
                repoOption
            };

            rootCommand.Description = "Get all commits for specified Github user and repository";

            rootCommand.SetHandler(
                async (string user, string repo) => await DoWork(user, repo),
                userOption,
                repoOption);

            return rootCommand;
        }
    }
}
