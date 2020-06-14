namespace PingDong.Entity
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
