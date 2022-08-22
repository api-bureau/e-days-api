using System.Text.Json.Serialization;

namespace Edays.Core;

public class EdaysHttpFacade
{
    private readonly HttpClient _client;
    private readonly ILogger<EdaysHttpFacade> _logger;
    private readonly EdaysSettings _settings;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private TokenResponse _tokenResponse = null!;

    public EdaysHttpFacade(HttpClient client, IOptions<EdaysSettings> settings, ILogger<EdaysHttpFacade> logger)
    {
        _client = client;
        _logger = logger;
        _settings = settings.Value;
        _jsonSerializerOptions = new JsonSerializerOptions
        {
            AllowTrailingCommas = true,
            //IgnoreNullValues = true,
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        CheckInitialisation();
    }

    private void CheckInitialisation()
    {
        if (string.IsNullOrEmpty(_settings.ClientSecret) || string.IsNullOrEmpty(_settings.ClientId) || _settings.TokenUri == null)
            _logger.LogError("EdaysSettings needs to be added and initialised Configuration.GetSection(nameof(EdaysSettings).");
    }

    public async Task ConnectAsync()
    {
        if (_tokenResponse != null) return;

        var tokenRequest = new ClientCredentialsTokenRequest
        {
            ClientId = _settings.ClientId,
            ClientSecret = _settings.ClientSecret,
            RequestUri = _settings.TokenUri
        };

        _tokenResponse = await _client.RequestClientCredentialsTokenAsync(tokenRequest);

        if (_tokenResponse.IsError)
        {
            _logger.LogError(_tokenResponse.ErrorDescription, _tokenResponse.Exception);
            throw new InvalidOperationException(_tokenResponse.ErrorDescription, _tokenResponse.Exception);
        }

        _client.SetBearerToken(_tokenResponse.AccessToken);
    }

    public async Task<List<T>> GetResultAsync<T>(string endpoint, int pageSize = 0)
    {
        await ConnectAsync();

        var response = await GetResponseAsync<T>(endpoint, 1, pageSize);

        if (!response.Pager.IsPager) return response.Data;

        var data = response.Data;

        for (var i = 2; i <= response.Pager.TotalPages; i++)
        {
            response = await GetResponseAsync<T>(endpoint, i, pageSize);

            if (response.Data.Count == 0) continue;

            data.AddRange(response.Data);
        }

        _logger.LogInformation($"Total {typeof(T).FullName} items: {data.Count}");

        return data;
    }

    public async Task<ResponseDto<T>> GetResponseAsync<T>(string query, int page = 1, int pageSize = 0)
    {
        if (pageSize > 0) query = $"{query}&page={page}&pagesize={pageSize}";

        using var response = await GetAsync(query);

        if (!response.IsSuccessStatusCode) return new ResponseDto<T>();

        var responseDto = new ResponseDto<T>(await DeserializeAsync<List<T>>(response))
        {
            Pager = new Pager(response.Headers)
        };

        _logger.LogInformation("Page: {0}/{1}", page,
            pageSize > 0 ?
                responseDto.Pager.TotalPages :
                responseDto.Data.Count > 0 ? 1 : 0);

        return responseDto;
    }

    public Task<HttpResponseMessage> GetAsync(string endPoint) => _client.GetAsync(BuildUri(endPoint));

    public Task<HttpResponseMessage> GetV1Async(string endPoint) => _client.GetAsync(BuildUriV1(endPoint));

    public async Task<T?> GetResponseAsync<T>(string query) where T : class
    {
        try
        {
            using var response = await GetAsync(query);

            if (!response.IsSuccessStatusCode) return null;

            var responseDto = await DeserializeAsync<T>(response);

            return responseDto;
        }
        catch (Exception e)
        {
            _logger.LogError(e, nameof(GetResponseAsync));

            return null;
        }
    }

    public async Task<T?> GetResponseV1Async<T>(string query) => await DeserializeAsync<T>(await GetV1Async(query));

    public async Task<T?> DeserializeAsync<T>(HttpResponseMessage response)
    {
        try
        {
            return await JsonSerializer.DeserializeAsync<T>(await response.Content.ReadAsStreamAsync(), _jsonSerializerOptions);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Deserialize Error at {uri}", response.RequestMessage?.RequestUri);
            throw;
        }
    }

    private Uri BuildUri(string url) => new Uri($"{_settings.BaseAddress}/{url}");

    private Uri BuildUriV1(string url) => new Uri($"{_settings.BaseAddressVersion1}/{url}&uid={_settings.ApiUserNameVersion1}&pak={_settings.ApiKeyVersion1}");
}