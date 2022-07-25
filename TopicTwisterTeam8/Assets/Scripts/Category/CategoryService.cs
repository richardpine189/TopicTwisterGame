using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;


public class CategoryService : ICategoryService
{
    private HttpClient _client;
    private string _baseURL;

    public CategoryService()
    {
        _client = new HttpClient();
        _baseURL = "http://localhost:8080";
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
        var queryParameters = new Dictionary<string, string[]>()
        {
            ["Categories"] = roundCategories,
            ["words"] = answers,
        };

        // https://makolyte.com/csharp-sending-query-strings-with-httpclient/

        var query = QueryHelpers.AddQueryString(_baseURL + "/isValid", queryParameters);

        var response = await _client.GetAsync(_baseURL + "/isValid");

        if (response.StatusCode == HttpStatusCode.InternalServerError)
        {
            throw new HttpRequestException("There is not connection");
        }

        var responseArray = await response.Content.ReadAsStringAsync();

        var deserializeResponse = JsonConvert.DeserializeObject<string[]>(responseArray);

        return deserializeResponse;
    }
}
