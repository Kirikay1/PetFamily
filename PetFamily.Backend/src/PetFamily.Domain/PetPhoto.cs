using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain
{
    public class PetPhoto
    {
        public Guid Id { get; set; }

        public string Path { get; set; } = default!;

        public bool IsMainPhoto { get; set; } = default;
    }
}
