using System.Collections.Generic;
using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Policies.Universal
{
    internal class BasicPolicy : IPackingItemsPolicy
    {
        public bool IsApplicable(PolicyData data)
            => true;

        public IEnumerable<PackingItem> GenerateItems(PolicyData data)
            => new List<PackingItem>
            {
                new("socks", 10),
                new("beer", 10)
            };
    }
}