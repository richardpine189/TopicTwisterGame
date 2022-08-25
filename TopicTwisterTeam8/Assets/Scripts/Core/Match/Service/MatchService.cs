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
            UnityEngine.Debug.Log(_apiPath + subPath + $"{challenger}");
            var response = await _client.GetAsync(_apiPath + subPath + $"{challenger}");

            return await InterpretateResponse(response);
        }

        public async Task<MatchDTO> GetOnGoingMatch(int matchId)
        {
            string subPath = "/GetMatchById";
            var response = await _client.GetAsync(_apiPath + subPath + $"/{matchId}");

            return await InterpretateResponse(response);
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