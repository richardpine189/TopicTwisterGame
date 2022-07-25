using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.LoginScene
{
    class LoginAction : ILoginGetUserAction
    {
        // This should be in a general config file for the whole project
        private readonly HttpClient _client = new HttpClient();

        // Development URL
        private readonly string _baseURL = @"http://localhost:8080";

        public async Task<string> Invoke(string username)
        {
            var values = new Dictionary<string, string>
            {
                { "userName", username }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await _client.PostAsync(_baseURL + "/user/logIn", content);

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new HttpRequestException("User not found in databse");
            }

            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }

        public UserDTO UserJsonToDTO(string userJson)
        {
            return JsonConvert.DeserializeObject<UserDTO>(userJson);
        }
    }

    public interface ILoginGetUserAction
    {
        Task<string> Invoke(string username);
        UserDTO UserJsonToDTO(string userJson);
    }
}
