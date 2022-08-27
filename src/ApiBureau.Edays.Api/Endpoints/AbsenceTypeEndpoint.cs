namespace ApiBureau.Edays.Api.Endpoints;

public class AbsenceTypeEndpoint : BaseEndpoint
{
    public AbsenceTypeEndpoint(ApiConnection apiConnection) : base(apiConnection) { }

    public Task<List<AbsenceTypeDto>> GetAsync()
        => ApiConnection.GetResultAsync<AbsenceTypeDto>("absencetypes");
}