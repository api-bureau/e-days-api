namespace ApiBureau.Edays.Api.Endpoints;

public class AbsenceEndpoint
{
    private readonly ApiConnection _client;

    public AbsenceEndpoint(ApiConnection client) => _client = client;

    public Task<List<AbsenceDto>> GetAsync(DateTime start, DateTime end, int pageSize = 10)
        => _client.GetResultAsync<AbsenceDto>($"absences?datestart={start:yyyyMMdd}&dateend={end:yyyyMMdd}", pageSize);
}