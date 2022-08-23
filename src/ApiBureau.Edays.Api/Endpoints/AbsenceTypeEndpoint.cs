namespace ApiBureau.Edays.Api.Endpoints;

public class AbsenceTypeEndpoint
{
    private readonly ApiConnection _client;

    public AbsenceTypeEndpoint(ApiConnection client) => _client = client;

    public Task<List<AbsenceTypeDto>> GetAsync() => _client.GetResultAsync<AbsenceTypeDto>("absencetypes");
}