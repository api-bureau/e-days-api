namespace ApiBureau.Edays.Api.Endpoints;

public class AbsenceEndpoint : BaseEndpoint
{
    public AbsenceEndpoint(ApiConnection apiConnection) : base(apiConnection) { }

    public Task<List<AbsenceDto>> GetAsync(DateTime start, DateTime end, int pageSize = 10)
        => ApiConnection.GetResultAsync<AbsenceDto>($"absences?datestart={start:yyyyMMdd}&dateend={end:yyyyMMdd}", pageSize);
}