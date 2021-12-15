using System;
using System.Collections.Generic;
using System.Linq;
using PackIT.Domain.Events;
using PackIT.Domain.Exceptions;
using PackIT.Domain.ValueObjects;
using PackIT.Shared.Abstractions.Domain;

namespace PackIT.Domain.Entities
{
    public class PackingList : AggregateRoot<Guid>
    {
        public PackingListId Id { get; private set; }

        private PackingListName _name;
        private Localization _localization;

        private readonly LinkedList<PackingItem> _items = new();

        private PackingList(PackingListId id, PackingListName name, Localization localization,
            LinkedList<PackingItem> items)
        :this(id, name, localization)
        {
            _items = items;
        }
        
        internal PackingList(PackingListId id, PackingListName name, Localization localization)
        {
            Id = id;
            _name = name;
            _localization = localization;
        }

        public void AddItem(PackingItem item)
        {
            var itemAlreadyExists = _items.Any(i => i.Name == item.Name);
            if (itemAlreadyExists)
            {
                throw new PackingItemAlreadyExistsException(_name.Value, item.Name);
            }

            _items.AddLast(item);
            AddEvent(new PackingItemAdded(this, item));
        }

        public void AddItems(IEnumerable<PackingItem> items)
        {
            foreach (var packingItem in items)
            {
                AddItem(packingItem);
            }
        }

        public void PackItem(string itemName)
        {
            var item = GetItem(itemName);
            var packedItem = item with {IsPacked = true};
            _items.Find(item).Value = packedItem;
            AddEvent(new PackingItemPacked(this,item));
        }

        public void RemoveItem(string itemName)
        {
            var item = GetItem(itemName);
            _items.Remove(item);
            AddEvent(new PackingItemRemoved(this, item));
        }

        private PackingItem GetItem(string itemName)
        {
            var item = _items.FirstOrDefault(item => item.Name == itemName);
            if (item is null)
            {
                throw new PackingItemNotFoundException(itemName);
            }

            return item;
        }
    }
}