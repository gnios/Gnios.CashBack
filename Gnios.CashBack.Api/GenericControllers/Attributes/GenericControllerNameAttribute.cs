using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;

namespace Gnios.CashBack.Api.GenericControllers
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class GenericControllerNameAttribute : Attribute, IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (controller.ControllerType.GetGenericTypeDefinition() == typeof(CrudController<,>))
            {

                var entityType = controller.ControllerType.GenericTypeArguments[0];
                var dtoType = controller.ControllerType.GenericTypeArguments[1];
                FeatureAttribute featureAttribute = (FeatureAttribute)Attribute.GetCustomAttribute(dtoType, typeof(FeatureAttribute));
                controller.ControllerName = string.IsNullOrEmpty(featureAttribute.Name) ? dtoType.Name : featureAttribute.Name;
            }
        }
    }
}
