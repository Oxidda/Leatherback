using System.Linq;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Reflection;
using Leatherback.Core.Attributes;

namespace Leatherback.Service.Extensions
{

    ///source : https://www.strathweb.com/2018/04/generic-and-dynamically-generated-controllers-in-asp-net-core-mvc/
    public class GenericControllerRouteConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            var result = controller.Selectors.First();
            if (controller.ControllerType.IsGenericType)
            {
                var genericType = controller.ControllerType.GenericTypeArguments[0];
                var customNameAttribute = genericType.GetCustomAttribute<LeatherbackControllerAttribute>();

                if (customNameAttribute?.Route != null)
                {
                    AttributeRouteModel routeModel = new AttributeRouteModel();
                    routeModel.Template = customNameAttribute.Route;

                    controller.Selectors.First().AttributeRouteModel = routeModel;
                }
            }
        }
    }
}
