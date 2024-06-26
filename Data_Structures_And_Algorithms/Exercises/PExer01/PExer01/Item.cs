using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PExer01
{
    public class Item
    {
        public Item(string name, string description, int value)
        {
            Name = name;
            Description = description;
            Value = value;
        }


        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
    }
}
