using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PExer01
{
    public class Person
    {
        public Person(string lastName, string firstName, int money, List<Item> itemList)
        {
            LastName = lastName;
            FirstName = firstName;
            Money = money;
            ItemList = itemList;
            FullName = firstName + " " + lastName;
        }

        public void GiveMoney(Person targetPerson, int amount)
        {
            if (amount < 0 || Money < 0)
                throw new InvalidOperationException("Amount should be a positive value.");

            Money -= amount;
            targetPerson.Money += amount;
        }

        public void GiveItem(Person targetPerson, Item itemToBeGiven)
        {
            if (targetPerson.ItemList.Contains(itemToBeGiven))
                throw new InvalidOperationException("One of the items to be traded already exists in a person's inventory.");

            ItemList.Remove(itemToBeGiven);
            targetPerson.ItemList.Add(itemToBeGiven);
        }


        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public int Money { get; set; }
        public List<Item> ItemList { get; set; }
    }
}
