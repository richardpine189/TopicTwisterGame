
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Unity.Plastic.Newtonsoft.Json;


public class CategoryService : ICategoryService
{
    private HttpClient _client = new HttpClient();
    private string _baseURL;

    public CategoryService(string path)
    {
        _baseURL = path;
    }

    public async Task<string[]> GetCategoriesNames(int amount)
    {
        var response = await _client.GetAsync(_baseURL + "/Categories/" + amount);

        if (response.StatusCode == HttpStatusCode.InternalServerError)
        {
            throw new HttpRequestException("There is not connection");
        }

        var responseArray = await response.Content.ReadAsStringAsync();

        var deserializeResponse = JsonConvert.DeserializeObject<string[]>(responseArray);

        return deserializeResponse;
    }

    public async Task<bool[]> GetWordsCorrection(string[] roundCategories, string[] answers, char letter)
    {
        /*
        var queryParameters = new Dictionary<string, string[]>()
        {
            ["Categories"] = roundCategories,
            ["words"] = answers,
        };

        // https://makolyte.com/csharp-sending-query-strings-with-httpclient/

        var query = QueryHelpers.AddQueryString(_baseURL + "/isValid", queryParameters);
        */
        string finalURL = _baseURL + "/isValid?";
        for (int i = 0; i < answers.Length; i++)
        {
            finalURL += $"word[{i}]={answers[i]}&";
            
        }
        for (int i = 0; i < roundCategories.Length; i++)
        {
            finalURL += $"category[{i}]={roundCategories[i]}&";
            
        }
        finalURL += $"letter={letter}";
        
        
        var response = await _client.GetAsync(finalURL);

        if (response.StatusCode == HttpStatusCode.InternalServerError)
        {
            throw new HttpRequestException("There is not connection");
        }

        var responseArray = await response.Content.ReadAsStringAsync();
        
        var deserializeResponse = JsonConvert.DeserializeObject<bool[]>(responseArray);
        
        return deserializeResponse;
    }
}
