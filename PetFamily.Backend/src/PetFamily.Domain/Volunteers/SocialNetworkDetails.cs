using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.Volunteers
{
    public record SocialNetworkDetails
    {
        private readonly List<SocialNetwork> _socialNetworks = [];
        public IReadOnlyList<SocialNetwork> SocialNetworks => _socialNetworks;

    }
}
