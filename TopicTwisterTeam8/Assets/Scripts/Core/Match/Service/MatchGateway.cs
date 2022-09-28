using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Core.Match.Interface;
using Models.DTO;
using Newtonsoft.Json;

namespace Core.Match.Service
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

        public async Task<bool> UpdateMatch(Models.Match match)  // Ver despues de assebly
        {
            RoundDTO values = new RoundDTO();

            values.id = match.idMatch;
            values.categories = match.round.CurrentCategories;
            values.answers = match.round.CurrentAnswers;
            values.results = match.round.CurrentResults;
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

        public async Task<MatchResultsDTO> GetRoundResults(int matchId, int roundIndex)
        {
            var path = _apiPath + $"/RoundResults?matchId={matchId}&round={roundIndex}";
            /*ar builder = new UriBuilder(_apiPath + "/RoundResults");
            builder.Port = 8080;
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["matchId"] = matchId.ToString();
            query["round"] = roundIndex.ToString();
            builder.Query = query.ToString();
            */
            //var response = await _client.GetAsync(builder.ToString());
            var response = await _client.GetAsync(path);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new HttpRequestException("There is not connection");
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            var deserializeMatchDto = JsonConvert.DeserializeObject<MatchResultsDTO>(responseBody);
            return deserializeMatchDto;
        }
    }

    
}
