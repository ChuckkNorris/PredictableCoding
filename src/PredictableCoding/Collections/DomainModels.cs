using System;
using System.Collections.Generic;

namespace PredictableCoding.Collections
{
    public class BadOrderModel 
    {
        // this is a "promiscuous" object :)
        // not only do you get a List, which is an implementation detail, 
        // but you also allow consumers to replace the entire list by setting the property
        public List<string> Items { get; set; }
        
        public void AddItemToOrder(string itemName)
        {
            // this will throw a NullReferenceException on Items if not set by consumer
            // so there's an implicit order of how a consumer must use this type (ctor --> setter --> method)
            Items.Add(itemName);
        }
    }
    
    public class GoodOrderModel
    {
        // the private setter prevents consumers from replacing entire collection
        public ICollection<string> Items { get; private set; }

        public GoodOrderModel()
        {
            // initializing the collection prevents consumers from getting null references
            Items = new List<string>();
        }
        
        public void AddItemToOrder(string itemName)
        {
            // this will not throw a NullReferenceException on Items
            Items.Add(itemName);
        }
    }

    public class BetterOrderModel
    {
        // now a readonly auto-property with an initializer
        // intializing to empty collection is known as the "Null Object" design pattern
        public ICollection<string> Items { get; } = new List<string>();
        
        public void AddItemToOrder(string itemName)
        {
            Items.Add(itemName);
        }

        // there's still one problem with this...
    }

    public class BestOrderModel
    {
        public Guid OrderId { get; } = Guid.NewGuid();

        // use an internal field to encapsulate the collection, and initialize to empty
        private List<string> _items = new List<string>();

        // expose a readonly, forward-only wrapper for the internal collection
        public IEnumerable<string> Items => _items.AsReadOnly();

        public void AddItemToOrder(string itemName)
        {
            // do some validation of itemName here

            _items.Add(itemName);

            // raise a domain event here: "OrderItemAdded"
        }
    }
}