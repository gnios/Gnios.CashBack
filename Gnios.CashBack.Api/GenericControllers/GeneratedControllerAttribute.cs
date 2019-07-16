using System;

namespace Gnios.CashBack.Api.GenericControllers
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class FeatureAttribute : Attribute
    {
        public FeatureAttribute()
        {
        }
    }
}
