namespace ApiBureau.Edays.Api;

public class UserEndpoint
{
    private readonly EdaysHttpFacade _client;

    public UserEndpoint(EdaysHttpFacade client) => _client = client;

    public Task<List<UserDto>> GetAsync() => _client.GetResultAsync<UserDto>("users");

    public async Task<List<(Guid UserId, int TypeId)>> GetUserTypesAsync(List<(Guid UserId, string PartnerId)> users)
    {
        var items = new List<(Guid, int)>();

        foreach (var user in users)
        {
            var response = await _client.GetResponseAsync<List<PatternDto>>($"users/{user.PartnerId}/publicholidays");

            if (response == null) continue;

            items.AddRange(response.Select(s => (user.UserId, s.Pattern)));
        }

        return items.Distinct().ToList();
    }
}
