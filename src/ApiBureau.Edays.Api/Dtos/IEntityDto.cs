namespace Edays.Dtos;

public interface IEntityIdDto<out TKey> where TKey : IEquatable<TKey>
{
    public TKey Id { get; }
}
