using Edays.Converters;
using System.Text.Json.Serialization;

namespace Edays.Dtos;

public class AbsencePublicHolidayDto : IEntityIdDto<(DateTime date, string holidayGroup)>
{
    public (DateTime date, string holidayGroup) Id => (Date, HolidayGroup);

    [JsonConverter(typeof(DateConverter))]
    public DateTime Date { get; set; }

    public string HolidayGroup { get; set; } = default!;

    public int Year { get; set; }
}

