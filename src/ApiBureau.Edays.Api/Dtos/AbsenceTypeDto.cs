namespace Edays.Dtos;

public class AbsenceTypeDto : IEntityIdDto<int>
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public bool CanViewInCalendarOwn { get; set; }
    public bool CanViewInCalendarReportees { get; set; }
    public bool CanViewInCalendarOthers { get; set; }
    public int RecordTypeDiscriminator { get; set; }
    public bool CanBookOwn { get; set; }
    public bool CanBookReportees { get; set; }
    public bool CanBookOthers { get; set; }
}