using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

/*
public class CategoryService : ICategoryService
{
    private HttpClient _client;
    private string _baseURL;

    public CategoryService()
    {
        _client = new HttpClient();
        _baseURL = "http://localhost:8080/Categories";
    }
    public async Task<string[]> GetCategoriesNames(int amount)
    {
        var response = await _client.GetAsync(_baseURL + $"/{amount}");

        if (response.StatusCode == HttpStatusCode.InternalServerError)
        {
            throw new HttpRequestException("There is not connection");
        }

        var responseArray = await response.Content.ReadAsStringAsync();

        var deserializeResponse = JsonConvert.DeserializeObject<string[]>(responseArray);

        return deserializeResponse;
    }

    public async Task<bool[]> GetWordCorrection()
    {
        throw new NotImplementedException();
    }
}
*/