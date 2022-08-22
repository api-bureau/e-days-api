namespace ApiBureau.Edays.Api;

public class RotaV1Endpoint
{
    private readonly EdaysHttpFacade _client;

    public RotaV1Endpoint(EdaysHttpFacade client) => _client = client;

    public async Task<List<AbsencePublicHolidayDto>> GetPublicHolidaysAsync(DateTime start, DateTime end)
    {
        var result = await _client.GetResponseV1Async<PublicHolidaysWrapperDto>($"/rota/publicHolidays?start={start:yyyy-MM-dd}&end={end:yyyy-MM-dd}");

        return result?.PublicHolidays ?? new();
    }
}