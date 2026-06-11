using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.Pets
{
    public record PetId
    {
        public PetId(Guid value)
        {
            Value = value;
        }

        public Guid Value { get;}

        public static PetId NewId() =>new(Guid.NewGuid());
        

        public static PetId Empty() => new(Guid.Empty);

    }
}
