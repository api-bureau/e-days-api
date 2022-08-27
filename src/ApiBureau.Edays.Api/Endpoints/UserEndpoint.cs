namespace ApiBureau.Edays.Api.Endpoints;

public class UserEndpoint : BaseEndpoint
{
    public UserEndpoint(ApiConnection apiConnection) : base(apiConnection) { }

    public Task<List<UserDto>> GetAsync() => ApiConnection.GetResultAsync<UserDto>("users");

    public async Task<List<(Guid UserId, int TypeId)>> GetUserTypesAsync(List<(Guid UserId, string PartnerId)> users)
    {
        var items = new List<(Guid, int)>();

        foreach (var user in users)
        {
            var response = await ApiConnection.GetResponseAsync<List<PatternDto>>($"users/{user.PartnerId}/publicholidays");

            if (response == null) continue;

            items.AddRange(response.Select(s => (user.UserId, s.Pattern)));
        }

        return items.Distinct().ToList();
    }
}
