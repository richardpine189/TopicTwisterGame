using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Match.Interface;
using Unity.Plastic.Newtonsoft.Json;

namespace Core.Match.Service
{
    public class MatchService : IGetMatchService, IUpdateMatchService
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly string _apiPath;

        public MatchService(string path)
        {
            _apiPath = path;
        }

        public async Task<MatchDTO> GetNewMatch(string challenger)
        {
            string subPath = "/newMatch/";
            var response = await _client.GetAsync(_apiPath + subPath + $"{challenger}");

            return await InterpretateResponse(response);
        }

        public async Task<MatchDTO> GetOnGoingMatch(int matchId)
        {
            string subPath = "/GetMatchById";
            var response = await _client.GetAsync(_apiPath + subPath + $"/{matchId}");

            return await InterpretateResponse(response);
        }

        public async void UpdateMatch(MatchDTO match)
        {
            var values = new Dictionary<string, string>
            {
                { "id", match.idMatch.ToString()},
                { "categories", "[" + string.Join(",", match.currentCategories) + "]" },
                { "answers", "[" + string.Join(",", match.currentAnswers) + "]" },
                { "results",  "[" + string.Join(",", match.currentResults.ToString()) + "]" },
                { "letter", match.currentLetter.ToString() },
                { "timeLeft", match.roundTimeLeft.ToString() }
            };

            var content = new FormUrlEncodedContent(values);

            string subPath = "/updateMatch";

            var response = await _client.PostAsync(_apiPath + subPath, content);

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new HttpRequestException("Error");
            }

            var responseString = await response.Content.ReadAsStringAsync();
        }

        private async Task<MatchDTO> InterpretateResponse(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                throw new HttpRequestException("There is not connection");
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            var deserializeMatchDto = JsonConvert.DeserializeObject<MatchDTO>(responseBody);
            return deserializeMatchDto;
        }
    }
}