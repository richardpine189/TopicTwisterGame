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
    class LoginAction
    {
        // This should be in a general config file for the whole project
        private static readonly HttpClient client = new HttpClient();

        // Development URL
        private static readonly string baseURL = @"http://localhost:8080";

        public async Task<string> Invoke(string username)
        {
            var values = new Dictionary<string, string>
            {
                { "userName", username }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync(baseURL + "/user/logIn", content);

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
}
