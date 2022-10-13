using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Zenject;

public class UserGateway : IUsersService
{
    // This should be in a general config file for the whole project
    private readonly HttpClient _client = new HttpClient();

    // Development URL
    private readonly string _baseURL;
    
    public UserGateway(string _path)
    {
        _baseURL = _path;
    }

    public async Task<string> RequestLogin(string username)
    {
        string _subPath = "/logIn";
        var values = new Dictionary<string, string>
        {
            { "userName", username }
        };

        var content = new FormUrlEncodedContent(values);

        var response = await _client.PostAsync(_baseURL + _subPath, content);

        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            throw new HttpRequestException("User not found in databse");
        }

        var responseString = await response.Content.ReadAsStringAsync();

        return responseString;
    }

    public async Task<string> RequestSignIn(string username, string email)
    {
        string _subPath = "/createUser";
        var values = new Dictionary<string, string>
        {
            { "userName", username },
            { "email", email }
        };

        var content = new FormUrlEncodedContent(values);

        var response = await _client.PostAsync(_baseURL + _subPath, content);

        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            throw new HttpRequestException("User not found in databse");
        }

        var responseString = await response.Content.ReadAsStringAsync();

        return responseString;
    }
}
