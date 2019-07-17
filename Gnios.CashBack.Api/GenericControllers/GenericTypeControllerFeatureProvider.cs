using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Gnios.CashBack.Api.GenericControllers
{
    public class GenericTypeControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            foreach (var dtoType in IncludedEntities.Types)
            {
                var typeName = dtoType.Name + "Controller";
                FeatureAttribute featureAttribute = (FeatureAttribute)Attribute.GetCustomAttribute(dtoType, typeof(FeatureAttribute));

                if (!feature.Controllers.Any(t => t.Name == typeName))
                {
                    var controllerType = typeof(CrudController<,>).MakeGenericType(featureAttribute.EntityType, dtoType.AsType()).GetTypeInfo();
                    feature.Controllers.Add(controllerType);
                }
            }
        }
    }
}
