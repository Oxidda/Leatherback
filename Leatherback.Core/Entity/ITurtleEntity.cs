using System;
using System.ComponentModel.DataAnnotations;

namespace Leatherback.Core.Entity
{
    public interface ILeatherbackEntity
    {
        [Key]
        public Guid Id  { get; set; }
    }
}
