namespace Gnios.CashBack.Api.GenericControllers
{
    class QueryFilter
    {
        public QueryFilter(string propertyName, string value, string @operator)
        {
            PropertyName = propertyName;
            Value = value;
            Operator = @operator;
        }

        public string PropertyName { get; set; }
        public string Value { get; set; }
        public string Operator { get; set; }
    }
}
