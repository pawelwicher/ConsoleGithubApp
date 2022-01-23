using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ConsoleGithubApp.DataAccess.Repository;
using ConsoleGithubApp.Application.Service;
using ConsoleGithubApp.Application.Mapper;
using ConsoleGithubApp.Application.Api;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) => services
        .AddHttpClient()
        .AddDbContext<CommitDbContext>(options => options
            .UseSqlServer(hostContext.Configuration.GetConnectionString("CommitDbContext")))
        .AddTransient<IGithubApiService, GithubApiService>()
        .AddTransient<ICommitRepository, CommitRepository>()
        .AddTransient<ICommitMapper, CommitMapper>()
        .AddTransient<IAppService, AppService>())
    .Build();

await host.Services
    .GetService<IAppService>()
    .Run(args);
