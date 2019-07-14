using System;

namespace Gnios.CashBack.Api.GenericControllers
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class FeatureAttribute : Attribute
    {
        public FeatureAttribute(string route)
        {
            Route = route;
        }

        public string Route { get; set; }
    }
}
