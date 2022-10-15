using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Architecture.Match.Domain.DTO;
using Architecture.Match.Gateway.Interfaces;
using Newtonsoft.Json;

namespace Architecture.Match.Gateway
{
    public class MatchGateway : IGetMatchGateway, IUpdateMatchGateway, IGetMatchesGateway, IGetRoundResultGateway
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly string _apiPath;

        public MatchGateway(string path)
        {
            _apiPath = path;
        }

        public async Task<List<MatchDTO>> GetMatchesDTOByName(string userName)
        {
            string subPath = "/getMatches?userName=";
            var response = await _client.GetAsync(_apiPath + subPath + userName);

            var responseString = await response.Content.ReadAsStringAsync();
            //var list = JsonUtility.FromJson<ListMatchDTO>(responseString);
            var list = JsonConvert.DeserializeObject<List<MatchDTO>>(responseString);
            
            return list;
        }

        public async Task<MatchDTO> GetNewMatch(string challenger)
        {
            string subPath = "/newMatch?challengerUserName=";
            
            var response = await _client.GetAsync(_apiPath + subPath + challenger);

            return await InterpretateResponse(response);
        }

        public async Task<ActiveMatchDTO> GetActiveMatch(int matchId)
        {
            string subPath = "/GetMatchById/";
            var response = await _client.GetAsync(_apiPath + subPath + matchId);
            
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new HttpRequestException("There is not connection");
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            var deserializeMatchDto = JsonConvert.DeserializeObject<ActiveMatchDTO>(responseBody);
            return deserializeMatchDto;
        }

        public async Task<bool> UpdateMatch(Domain.Match match)  // Ver despues de assebly
        {
            RoundDTO values = new RoundDTO();

            values.idMatch = match.idMatch;
            values.categories = match.round.CurrentCategories.ToList();
            values.answers = match.round.CurrentAnswers.ToList();
            values.results = match.round.CurrentResults.ToList();
            values.letter = (char)match.round.CurrentLetter;
            values.timeLeft = match.round.RoundTimeLeft;

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

            return JsonConvert.DeserializeObject<bool>(responseString);
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

        public async Task<RoundResultsDTO> GetRoundResults(int matchId)
        {
            var path = _apiPath + $"/RoundResults?matchId={matchId}";
            
            var response = await _client.GetAsync(path);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new HttpRequestException("There is not connection");
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            var deserializeMatchDto = JsonConvert.DeserializeObject<RoundResultsDTO>(responseBody);
            return deserializeMatchDto;
        }
    }

    
}
