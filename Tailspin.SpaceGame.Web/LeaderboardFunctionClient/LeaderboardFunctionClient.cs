using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TailSpin.SpaceGame.Web
{
    public class LeaderboardFunctionClient : ILeaderboardServiceClient
    {
        private string _functionUrl;

        public LeaderboardFunctionClient(string functionUrl)
        {
            this._functionUrl = functionUrl;
        }

        async public Task<LeaderboardResponse> GetLeaderboard(int page, int pageSize, string mode, string region)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string json = await httpClient.GetStringAsync($"{this._functionUrl}?page={page}&pageSize={pageSize}&mode={mode}&region={region}");
                return JsonSerializer.Deserialize<LeaderboardResponse>(json, new JsonSerializerOptions 
                {
                    IncludeFields = true, 
                    PropertyNameCaseInsensitive = true 
                });
            }
        }
    }
}
