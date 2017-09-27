using System.Collections.Generic;

namespace PredictableCoding.Collections
{
    public class BadOrderModel 
    {
        public ICollection<string> Items { get; set; }
        
        public void AddItemToOrder(string itemName)
        {
            // this will throw a NullReferenceException on Items if not set by consumer
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
        public ICollection<string> Items { get; } = new List<string>();
        
        public void AddItemToOrder(string itemName)
        {
            Items.Add(itemName);
        }
    }
}