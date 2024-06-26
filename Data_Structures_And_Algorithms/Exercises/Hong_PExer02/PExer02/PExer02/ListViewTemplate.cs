using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PExer02
{
    public class ListViewTemplate
    {
        public ListViewTemplate(string name, string description, float value, int quantity)
        {
            Name = name;
            Description = description;
            Value = value;
            Quantity = quantity;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public float Value { get; private set; }
        public int Quantity { get; set; }
    }
}
