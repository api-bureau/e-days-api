namespace Edays.Dtos;

public class UserDto : IEntityIdDto<Guid>
{
    public Guid Id => EdaysId;
    public Guid EdaysId { get; set; }
    public string? PartnerId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string EmployeeNumber { get; set; } = null!;
    public bool IsLeaver { get; set; }
}
