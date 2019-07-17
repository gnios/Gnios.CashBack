namespace Gnios.CashBack.Api.GenericControllers.Filters
{
    public interface IComparison
    {

        bool LessThan(string leftData, string rightData);

        bool GreaterThan(string leftData, string rightData);

        bool Equals(string leftData, string rightData);
    }
}
