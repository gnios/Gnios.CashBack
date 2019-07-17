namespace Gnios.CashBack.Api.Persistence
{
    public interface IEntity
    {
        int Id { get; set; }
        string VersionObject { get; }
    }
}
