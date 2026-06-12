using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.Pets
{
    public record PetPhotoDetails
    {
        private readonly List<PetPhoto> _photos = [];

        public IReadOnlyList<PetPhoto> Photos => _photos;
    }
}
