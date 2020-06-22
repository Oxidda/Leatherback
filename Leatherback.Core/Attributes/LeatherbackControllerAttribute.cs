using System;

namespace Leatherback.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class LeatherbackControllerAttribute : Attribute
    {
        public LeatherbackControllerAttribute(string route)
        {
            Route = route;
        }

        public string Route { get; set; }

        public Type SearchCriteria { get; set; }
    }
}
