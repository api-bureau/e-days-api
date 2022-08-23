namespace ApiBureau.Edays.Api.Endpoints;

public class RotaV1Endpoint
{
    private readonly ApiConnection _client;

    public RotaV1Endpoint(ApiConnection client) => _client = client;

    public async Task<List<AbsencePublicHolidayDto>> GetPublicHolidaysAsync(DateTime start, DateTime end)
    {
        var result = await _client.GetResponseV1Async<PublicHolidaysWrapperDto>($"/rota/publicHolidays?start={start:yyyy-MM-dd}&end={end:yyyy-MM-dd}");

        return result?.PublicHolidays ?? new();
    }
}