namespace ApiBureau.Edays.Api;

public class AbsenceEndpoint
{
    private readonly EdaysHttpFacade _client;

    public AbsenceEndpoint(EdaysHttpFacade client) => _client = client;

    public Task<List<AbsenceDto>> GetAsync(DateTime start, DateTime end, int pageSize = 10)
        => _client.GetResultAsync<AbsenceDto>($"absences?datestart={start:yyyyMMdd}&dateend={end:yyyyMMdd}", pageSize);
}