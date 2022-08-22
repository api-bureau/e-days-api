namespace ApiBureau.Edays.Api;

public class AbsenceTypeEndpoint
{
    private readonly EdaysHttpFacade _client;

    public AbsenceTypeEndpoint(EdaysHttpFacade client) => _client = client;

    public Task<List<AbsenceTypeDto>> GetAsync() => _client.GetResultAsync<AbsenceTypeDto>("absencetypes");
}