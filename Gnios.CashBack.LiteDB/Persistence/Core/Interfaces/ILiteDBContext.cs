using LiteDB;

namespace Gnios.CashBack.Api.Persistence.Repository.LiteDB
{
    /// <summary>
    /// Context of LiteDB
    /// </summary>
    public interface ILiteDBContext
    {
        LiteRepository Repository { get; set; }
    }
}
