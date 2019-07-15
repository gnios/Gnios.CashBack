namespace Gnios.CashBack.Api.Persistence
{
    public interface IEntity<TIdentifier> where TIdentifier : struct
    {
        TIdentifier Id { get; set; }
        string VersionObject { get; }
    }
}
