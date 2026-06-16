using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.Shared
{
    public record RequisitesDetails
    {
        private readonly List<Requisites> _requisites = [];

        public IReadOnlyList<Requisites> Requisites => _requisites;
    }
}
