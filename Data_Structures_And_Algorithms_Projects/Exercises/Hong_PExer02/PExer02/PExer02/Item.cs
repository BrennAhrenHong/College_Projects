    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PExer02
{
    public class Item
    {
        public Item(string name, string description, float value)
        {
            Name = name;
            Description = description;
            Value = value;
        }


        public string Name { get; set; }
        public string Description { get; set; }
        public float Value { get; set; }
    }

    public class ItemQuantity
    {
        public ItemQuantity(Item attachedItem, int quantity)
        {
            AttachedItem = attachedItem;
            Quantity = quantity;
        }

        public Item AttachedItem { get; private set; }
        public int Quantity { get; set; }
    }
}
