using System;
using Leatherback.Core.Attributes;
using Leatherback.Core.Entity;

namespace Leatherback.Example.Models
{
    [LeatherbackController("api/person")]
    public class Person : ILeatherbackEntity
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public EmploymentStatus EmploymentStatus { get; set; }
        public Guid Id { get; set; }
    }
}