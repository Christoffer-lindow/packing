using PackIT.Shared.Abstractions.Exceptions;

namespace PackIT.Domain.Exceptions
{
    public class PackingItemNotFoundException : PackItException
    {
        public string ItemName { get;  }
        public PackingItemNotFoundException(string itemName): base($"Could not find Packing Item with name {itemName}")
            => ItemName = itemName;
    }
}