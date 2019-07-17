using System;

namespace Gnios.CashBack.Api.GenericControllers
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class FeatureAttribute : Attribute
    {
        public FeatureAttribute(Type entityType)
        {
            EntityType = entityType;
        }

        public FeatureAttribute(string name, Type entityType) : this(entityType)
        {
            Name = name;
        }

        public string Name { get; }

        public Type EntityType { get; }
    }
}
