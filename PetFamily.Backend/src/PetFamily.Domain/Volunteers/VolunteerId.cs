using PetFamily.Domain.Pets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.Volunteers
{
    public record VolunteerId
    {
        public VolunteerId(Guid value)
        {
            Value = value;
        }

        public Guid Value { get; }

        public static VolunteerId NewId() => new(Guid.NewGuid());


        public static VolunteerId Empty() => new(Guid.Empty);
    }
}
