namespace ApiBureau.Edays.Api.Endpoints;

public class RotaV1Endpoint : BaseEndpoint
{
    public RotaV1Endpoint(ApiConnection apiConnection) : base(apiConnection) { }

    public async Task<List<AbsencePublicHolidayDto>> GetPublicHolidaysAsync(DateTime start, DateTime end)
    {
        var result = await ApiConnection.GetResponseV1Async<PublicHolidaysWrapperDto>($"/rota/publicHolidays?start={start:yyyy-MM-dd}&end={end:yyyy-MM-dd}");

        return result?.PublicHolidays ?? new();
    }
}