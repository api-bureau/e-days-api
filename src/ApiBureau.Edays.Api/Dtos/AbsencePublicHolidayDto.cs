using ApiBureau.Edays.Api.Converters;
using System.Text.Json.Serialization;

namespace ApiBureau.Edays.Api.Dtos;

public class AbsencePublicHolidayDto : IEntityIdDto<(DateTime date, string holidayGroup)>
{
    public (DateTime date, string holidayGroup) Id => (Date, HolidayGroup);

    [JsonConverter(typeof(DateConverter))]
    public DateTime Date { get; set; }

    public string HolidayGroup { get; set; } = default!;

    public int Year { get; set; }
}

