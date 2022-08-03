using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

public class LoginService : ILoginService
{
    // This should be in a general config file for the whole project
    private readonly HttpClient _client = new HttpClient();

    // Development URL
    private readonly string _baseURL = @"http://localhost:8080";

    public async Task<string> RequestLogin(string username)
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
}