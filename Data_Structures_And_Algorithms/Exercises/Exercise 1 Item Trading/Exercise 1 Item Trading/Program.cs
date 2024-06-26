using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1_Item_Trading
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> firstPersonItems = new List<Item>();
            List<Item> secondPersonItems = new List<Item>();
            Item itemOne = new Item("CM Ice cream", "A chocolate mint flavored ice cream.", 200);
            Item itemTwo = new Item("Phoenix Down", "Revives someone.", 150);
            Item itemThree = new Item("Masamune", "A bladed weapon.", 16000);
            Item itemFour = new Item("Gold", "It's shiny.", 1000);
            Item itemFive = new Item("Chocolate", "It is a plain chocolate bar.", 50);
            Item itemSix = new Item("Soda Pop", "Refreshing carbonated beverage.", 80);

            firstPersonItems.Add(itemOne);
            firstPersonItems.Add(itemTwo);
            firstPersonItems.Add(itemThree);
            firstPersonItems.Add(itemSix);

            secondPersonItems.Add(itemOne);
            secondPersonItems.Add(itemFour);
            secondPersonItems.Add(itemFive);
            secondPersonItems.Add(itemSix);

            

            var firstPerson = new Person("Banico", "Samuel", 10, firstPersonItems);
            var secondPerson = new Person("Batao", "Rogene", 20, secondPersonItems);

            try
            {
                firstPerson.GiveMoney(secondPerson, 10);
                secondPerson.GiveMoney(secondPerson, 1);
                Console.WriteLine("HEllo");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }

    public class Person
    {
        public Person(string lastName, string firstName, int money, List<Item> itemList)
        {
            LastName = lastName;
            FirstName = firstName;
            Money = money;
            ItemList = itemList;
        }

        public void GiveMoney(Person targetPerson, int amount)
        {
            if (amount < 0 || Money < 0)
                throw new InvalidOperationException("Amount should be a positive value.");

            Money -= amount;
            targetPerson.Money += amount;
        }

        public void TradeItemWithItem(Person targetPerson, Item itemToBeGiven, Item itemToBeReceived)
        {
            if (targetPerson.ItemList.Contains(itemToBeGiven) || ItemList.Contains(itemToBeReceived))
                throw new InvalidOperationException("One of the items to be traded already exists in a person's inventory.");

            ItemList.Remove(itemToBeGiven);
            targetPerson.ItemList.Add(itemToBeGiven);
        }

        public void TradeItemWithMoney(Person targetPerson, int money, Item itemToBeReceived)
        {
            if(ItemList.Contains(itemToBeReceived))
                throw  new InvalidOperationException("Item already exists in inventory.");
            if(targetPerson.Money < 0)
                throw new InvalidOperationException("Amount should be a positive value.");
        }


        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Money { get; private set; } = 0;

        public Person Friend { get; set; }
        public Person Friend2 { get; set; }
        public List<Item> ItemList { get; set; }
    }

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

