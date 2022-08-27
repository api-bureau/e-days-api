namespace ApiBureau.Edays.Api.Dtos;

public class ResponseDto<T>
{
    public List<T> Data { get; set; }

    public Pager Pager { get; set; } = new Pager();

    public bool IsPager => Pager != null && Pager.IsPager;

    public ResponseDto(List<T>? data = null) => Data = data ?? new List<T>();
}
