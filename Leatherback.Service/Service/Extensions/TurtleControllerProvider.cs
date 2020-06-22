using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Leatherback.Core.Attributes;
using Turtle.Service.Controllers;

namespace Leatherback.Service.Extensions
{
    public class TurtleControllerProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public TurtleControllerProvider(IServiceCollection services)
        {
            Services = services;
        }

        public IServiceCollection Services { get; }

        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var currentAssembly in assemblies)
            {
                var candidates = currentAssembly.GetExportedTypes()
                    .Where(x => x.GetCustomAttributes<LeatherbackControllerAttribute>().Any());
                
                foreach (var candidate in candidates)
                {
                    var attribute = (LeatherbackControllerAttribute)Attribute.GetCustomAttribute(candidate, typeof(LeatherbackControllerAttribute));
                    var searchcriteria = candidate;
                    if (attribute.SearchCriteria != null)
                    {
                        searchcriteria = attribute.SearchCriteria;
                    }
                    feature.Controllers.Add(
                        typeof(LeatherbackApiController<,>).MakeGenericType(candidate,searchcriteria).GetTypeInfo()
                    );
                 
                }
            }

        }
    }
}
