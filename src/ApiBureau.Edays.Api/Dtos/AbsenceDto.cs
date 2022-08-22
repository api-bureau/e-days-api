namespace ApiBureau.Edays.Api.Dtos;

public class AbsenceDto : IEntityIdDto<Guid>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public int AbsenceTypeId { get; set; }
    public string? Details { get; set; }
    public string Status { get; set; } = null!;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public float DurationInDays { get; set; }
    public float DurationInMinutes { get; set; }
    public DateTime DateCreated { get; set; }
    public bool IsOpen { get; set; }
}