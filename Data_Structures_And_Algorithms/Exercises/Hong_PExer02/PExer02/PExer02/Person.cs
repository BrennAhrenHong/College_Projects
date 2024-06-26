using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PExer02
{
    public class Person
    {
        public Person(string lastName, string firstName, int money)
        {
            LastName = lastName;
            FirstName = firstName;
            Money = money;
            FullName = firstName + " " + lastName;
        }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public List<ItemQuantity> ItemsOwned { get; private set; } = new List<ItemQuantity>();
        public float Money { get; private set; }

        public void GiveMoney(Person personToReceive, float moneyToGive)
        {
            if (moneyToGive < 0 || Money < 0)
                throw new InvalidOperationException("Amount should be a positive value.");

            Money -= moneyToGive;
            personToReceive.Money += moneyToGive;
        }

        public void GiveItem(Person personToReceive, ItemQuantity itemToGive, int quantity)
        {
            if (personToReceive == this) throw new Exception("You cannot send to your self");
            if (!ItemsOwned.Contains(itemToGive)) throw new Exception("You can only send your own items.");
            int itemIndex = ItemsOwned.IndexOf(itemToGive);

            bool itemExists = false;

            foreach (var itemQuantity in personToReceive.ItemsOwned)
            {
                if (itemQuantity.AttachedItem == itemToGive.AttachedItem)
                {
                    itemQuantity.Quantity += quantity;
                    itemExists = true;
                    break;
                }
            }

            if (!itemExists) 
            {
                ItemQuantity modifiedItemToGive = new ItemQuantity(itemToGive.AttachedItem, quantity);
                personToReceive.ItemsOwned.Add(modifiedItemToGive);
            }

            ItemsOwned[itemIndex].Quantity = ItemsOwned[itemIndex].Quantity - quantity;
            if (ItemsOwned[itemIndex].Quantity == 0)
            {
                ItemsOwned.Remove(itemToGive);
            }   
        }

        public void PrintItemCount()
        {
            Console.WriteLine($"{LastName} has {ItemsOwned.Count} items.");
        }

        public void PrintItems()
        {
            foreach (var item in ItemsOwned)
            {
                Console.Write($"{item.AttachedItem.Name}");
            }

            Console.WriteLine();
        }
    }
}
