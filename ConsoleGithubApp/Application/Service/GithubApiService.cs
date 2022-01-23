using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;
using ConsoleGithubApp.Application.Model;

namespace ConsoleGithubApp.Application.Api
{
    public class GithubApiService : IGithubApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GithubApiService(
            IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IReadOnlyCollection<CommitDto>> GetCommits(string user, string repo)
        {
            using var httpClient = _httpClientFactory.CreateClient();

            httpClient.BaseAddress = new Uri("http://api.github.com/");

            httpClient.DefaultRequestHeaders.Add(
                HeaderNames.Accept,
                "application/vnd.github.v3+json");

            httpClient.DefaultRequestHeaders.Add(
                HeaderNames.UserAgent,
                "ConsoleGithubApp");

            var commits = new List<CommitDto>();

            var page = 0;

            while (true)
            {
                var result = await httpClient.GetFromJsonAsync<IReadOnlyCollection<CommitDto>>(
                    $"repos/{user}/{repo}/commits?per_page=10&page={++page}");

                if (result.Count == 0)
                {
                    break;
                }

                commits.AddRange(result);
            }

            return commits
                .ToArray();
        }
    }
}
