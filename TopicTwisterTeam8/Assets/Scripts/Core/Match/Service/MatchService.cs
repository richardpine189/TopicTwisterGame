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

        public async Task UpdateMatch(MatchDTO match)
        {
            RoundDTO values = new RoundDTO();

            values.id = match.idMatch;
            values.categories = match.currentCategories;
            values.answers = match.currentAnswers;
            values.results = match.currentResults;
            values.letter = (char)match.currentLetter;
            values.timeLeft = match.roundTimeLeft;

            var content = JsonConvert.SerializeObject(values);

            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string subPath = "/updateMatch";

            var response = await _client.PostAsync(_apiPath + subPath, byteContent);

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