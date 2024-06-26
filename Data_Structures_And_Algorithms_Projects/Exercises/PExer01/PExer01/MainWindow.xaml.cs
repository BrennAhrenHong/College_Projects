using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PExer01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Person SelectedCharacterA;
        private Person SelectedCharacterB;
        public MainWindow()
        {
            InitializeComponent();

            //LvInventoryOne
            GridView gvInventory = new GridView();
            gvInventory.AllowsColumnReorder = true;
            LvInventoryOne.View = gvInventory;

            //LvInventoryOne Column 1
            GridViewColumn lvInventoryGridViewOne = new GridViewColumn();
            lvInventoryGridViewOne.DisplayMemberBinding = new Binding("Name");
            lvInventoryGridViewOne.Header = "Item Name";
            lvInventoryGridViewOne.Width = 90;

            //LvInventoryOne Column 2
            GridViewColumn lvInventoryGridViewTwo = new GridViewColumn();
            lvInventoryGridViewTwo.DisplayMemberBinding = new Binding("Value");
            lvInventoryGridViewTwo.Header = "Value";
            lvInventoryGridViewTwo.Width = 55;

            gvInventory.Columns.Add(lvInventoryGridViewOne);
            gvInventory.Columns.Add(lvInventoryGridViewTwo);


            //LvItemsToTradeOne
            var gvItemsToTrade = new GridView();
            gvItemsToTrade.AllowsColumnReorder = true;
            LvItemsToTradeOne.View = gvItemsToTrade;

            //LvItemsToTradeOne Column 1
            var lvItemsToTradeGridViewOne = new GridViewColumn();
            lvItemsToTradeGridViewOne.DisplayMemberBinding = new Binding("Name");
            lvItemsToTradeGridViewOne.Header = "Item Name";
            lvItemsToTradeGridViewOne.Width = 100;

            //LvItemsToTradeOne Column 2
            var lvItemsToTradeGridViewTwo = new GridViewColumn();
            lvItemsToTradeGridViewTwo.DisplayMemberBinding = new Binding("Value");
            lvItemsToTradeGridViewTwo.Header = "Value";
            lvItemsToTradeGridViewTwo.Width = 55;

            gvItemsToTrade.Columns.Add(lvItemsToTradeGridViewOne);
            gvItemsToTrade.Columns.Add(lvItemsToTradeGridViewTwo);

            //LvInventoryTwo
            GridView gvInventoryTwo = new GridView();
            gvInventoryTwo.AllowsColumnReorder = true;
            LvInventoryTwo.View = gvInventoryTwo;

            //LvInventoryOne Column 1
            GridViewColumn lvInventoryTwoGridViewOne = new GridViewColumn();
            lvInventoryTwoGridViewOne.DisplayMemberBinding = new Binding("Name");
            lvInventoryTwoGridViewOne.Header = "Item Name";
            lvInventoryTwoGridViewOne.Width = 90;

            //LvInventoryOne Column 2
            GridViewColumn lvInventoryTwoGridViewTwo = new GridViewColumn();
            lvInventoryTwoGridViewTwo.DisplayMemberBinding = new Binding("Value");
            lvInventoryTwoGridViewTwo.Header = "Value";
            lvInventoryTwoGridViewTwo.Width = 55;

            gvInventoryTwo.Columns.Add(lvInventoryTwoGridViewOne);
            gvInventoryTwo.Columns.Add(lvInventoryTwoGridViewTwo);


            //LvItemsToTradeOne
            var gvItemsToTradeTwo = new GridView();
            gvItemsToTradeTwo.AllowsColumnReorder = true;
            LvItemsToTradeTwo.View = gvItemsToTradeTwo;

            //LvItemsToTradeOne Column 1
            var lvItemsToTradeTwoGridViewOne= new GridViewColumn();
            lvItemsToTradeTwoGridViewOne.DisplayMemberBinding = new Binding("Name");
            lvItemsToTradeTwoGridViewOne.Header = "Item Name";
            lvItemsToTradeTwoGridViewOne.Width = 100;

            //LvItemsToTradeOne Column 2
            var lvItemsToTradeTwoGridViewTwo = new GridViewColumn();
            lvItemsToTradeTwoGridViewTwo.DisplayMemberBinding = new Binding("Value");
            lvItemsToTradeTwoGridViewTwo.Header = "Value";
            lvItemsToTradeTwoGridViewTwo.Width = 55;

            gvItemsToTradeTwo.Columns.Add(lvItemsToTradeTwoGridViewOne);
            gvItemsToTradeTwo.Columns.Add(lvItemsToTradeTwoGridViewTwo);

            CreateItems();
        }

        public void CreateItems()
        {
            var itemOne = new Item("CM Ice cream", "A chocolate mint flavored ice cream.", 200);
            var itemTwo = new Item("Phoenix Down", "Revives someone.", 150);
            var itemThree = new Item("Excalibur", "A bladed weapon.", 16000);
            var itemFour = new Item("Gold", "It's shiny.", 1000);
            var itemFive = new Item("Chocolate", "It is a plain chocolate bar.", 50);
            var itemSix = new Item("Soda Pop", "Refreshing carbonated beverage.", 80);
            var itemSeven = new Item("Bread", "Freshly baked!", 80);
            var itemEight = new Item("Sandwich", "Yummy.", 250);
            var itemNine = new Item("Calculator", "Can't bring it during a calculus exam!", 1250);
            var itemTen = new Item("Book", "A generic looking book.", 25);

            DataStorage.itemList.Add(itemOne);
            DataStorage.itemList.Add(itemTwo);
            DataStorage.itemList.Add(itemThree);
            DataStorage.itemList.Add(itemFour);
            DataStorage.itemList.Add(itemFive);
            DataStorage.itemList.Add(itemSix);
            DataStorage.itemList.Add(itemSeven);
            DataStorage.itemList.Add(itemEight);
            DataStorage.itemList.Add(itemNine);
            DataStorage.itemList.Add(itemTen);

            List<Item> firstItemList = new List<Item>();
            firstItemList.Add(itemTwo);
            firstItemList.Add(itemFour);
            firstItemList.Add(itemTen);

            List<Item> secondItemList = new List<Item>();
            secondItemList.Add(itemOne);
            secondItemList.Add(itemFive);
            secondItemList.Add(itemSix);

            List<Item> thirdItemList = new List<Item>();
            thirdItemList.Add(itemFive);
            thirdItemList.Add(itemThree);
            thirdItemList.Add(itemSeven);

            List<Item> fourthItemList = new List<Item>();
            fourthItemList.Add(itemSix);
            fourthItemList.Add(itemOne);

            DataStorage.personsList.Add(new Person("Doe", "John", 1250, DataStorage.itemList));
            DataStorage.personsList.Add(new Person("Fox", "Meghan", 5050, firstItemList));
            DataStorage.personsList.Add(new Person("Carter", "Frank", 8020, secondItemList));
            DataStorage.personsList.Add(new Person("Johnson", "Robert", 4000, thirdItemList));
            DataStorage.personsList.Add(new Person("Jenkins", "Leroy", 5000, fourthItemList));

            List<string> nameList = new List<string>();

            foreach (var person in DataStorage.personsList)
            {
                nameList.Add(person.FullName);
            }

            CmbCharacterA.ItemsSource = nameList;
            CmbCharacterB.ItemsSource = nameList;
        }

        public void CreateListViewItems()
        {
            // https://stackoverflow.com/questions/868204/adding-columns-programmatically-to-listview-in-wpf
        }

        private void CmbCharacterA_DropDownClosed(object sender, EventArgs e)
        {
            LvInventoryOne.Items.Clear();
            LvItemsToTradeOne.Items.Clear();
            TxtDescriptionOne.Clear();
            TxtTotalValueOne.Text = "0";
            if (CmbCharacterA.SelectedItem != null)
            {
                foreach (var person in DataStorage.personsList)
                {
                    if (person.FullName == CmbCharacterA.SelectedItem.ToString())
                    {
                        SelectedCharacterA = person;
                    }
                }

                //LvInventoryOne.ItemsSource = selectedPerson.ItemList;
                TbMoneyCharacterA.Text = SelectedCharacterA.Money.ToString();
                foreach (var item in SelectedCharacterA.ItemList)
                {
                    LvInventoryOne.Items.Add(item);
                }
            }
        }

        private void BtnAddItem_Click(object sender, RoutedEventArgs e)
        {
            if (LvInventoryTwo.SelectedIndex > -1)
            {
                TxtDescriptionTwo.Text = "";
                int totalValue = Convert.ToInt32(TxtTotalValueTwo.Text);
                foreach (var selectedItem in LvInventoryTwo.SelectedItems)
                {
                    LvItemsToTradeTwo.Items.Add(selectedItem);
                    var selectedItemValue = (Item)selectedItem;
                    totalValue += selectedItemValue.Value;
                }

                TxtTotalValueTwo.Text = totalValue.ToString();

                while (LvInventoryTwo.SelectedItems.Count > 0)
                {
                    LvInventoryTwo.Items.Remove(LvInventoryTwo.SelectedItems[0]);
                }
            }
        }

        private void BtnRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            int totalValue = Convert.ToInt32(TxtTotalValueOne.Text);
            foreach (var selectedItem in LvItemsToTradeOne.SelectedItems)
            {
                LvInventoryOne.Items.Add(selectedItem);
                var selectedItemValue = (Item)selectedItem;
                totalValue -= selectedItemValue.Value;
            }

            TxtTotalValueOne.Text = totalValue.ToString();
            while (LvItemsToTradeOne.SelectedItems.Count > 0)
            {
                LvItemsToTradeOne.Items.Remove(LvItemsToTradeOne.SelectedItems[0]);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int totalValue = Convert.ToInt32(TxtTotalValueOne.Text);
            foreach (var item in LvItemsToTradeOne.Items)
            {
                LvInventoryOne.Items.Add(item);
                var selectedItemValue = (Item)item;
                totalValue -= selectedItemValue.Value;
            }

            TxtTotalValueOne.Text = totalValue.ToString();
            while (LvItemsToTradeOne.Items.Count > 0)
            {
                LvItemsToTradeOne.Items.Remove(LvItemsToTradeOne.Items[0]);
            }
        }

        private void LvInventoryOne_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LvInventoryOne.SelectedItem != null)
            {
                var selectedItem = (Item)LvInventoryOne.SelectedItem;
                TxtDescriptionOne.Text = selectedItem.Description;
            }
        }
        //Trade Button
        private void BtnTrade_Click(object sender, RoutedEventArgs e)
        {
            var selectedCharacterIndexA = DataStorage.personsList.IndexOf(SelectedCharacterA);
            var selectedCharacterIndexB = DataStorage.personsList.IndexOf(SelectedCharacterB);
            bool duplicateItem = false;

            foreach (var item in LvItemsToTradeOne.Items)
            {
                if (DataStorage.personsList[selectedCharacterIndexB].ItemList.Contains(item))
                    duplicateItem = true;
            }

            foreach (var item in LvItemsToTradeTwo.Items)
            {
                if (DataStorage.personsList[selectedCharacterIndexA].ItemList.Contains(item))
                    duplicateItem = true;
            }

            if (duplicateItem)
                MessageBox.Show("Duplicate item detected");

            if (CmbCharacterA.SelectedIndex > -1 && CmbCharacterB.SelectedIndex > -1 && !duplicateItem)
            {
                if (LvItemsToTradeOne.Items.Count != 0 || LvItemsToTradeTwo.Items.Count != 0)
                {
                    LvInventoryOne.Items.Clear();
                    LvInventoryTwo.Items.Clear();
                    foreach (var item in LvItemsToTradeOne.Items)
                    {
                        DataStorage.personsList[selectedCharacterIndexA].GiveItem(DataStorage.personsList[selectedCharacterIndexB], (Item)item);
                    }

                    foreach (var item in LvItemsToTradeTwo.Items)
                    {
                        DataStorage.personsList[selectedCharacterIndexB].GiveItem(DataStorage.personsList[selectedCharacterIndexA], (Item)item);
                    }

                    foreach (var item in DataStorage.personsList[selectedCharacterIndexA].ItemList)
                    {
                        LvInventoryOne.Items.Add((Item)item);
                    }


                    foreach (var item in DataStorage.personsList[selectedCharacterIndexB].ItemList)
                    {
                        LvInventoryTwo.Items.Add((Item)item);
                    }
                    LvItemsToTradeOne.Items.Clear();
                    LvItemsToTradeTwo.Items.Clear();
                }

                if (Convert.ToInt32(TxtGiveMoneyCharacterA.Text) > 0 || Convert.ToInt32(TxtGiveMoneyCharacterB.Text) > 0)
                {
                    DataStorage.personsList[selectedCharacterIndexA].GiveMoney(DataStorage.personsList[selectedCharacterIndexB], Convert.ToInt32(TxtGiveMoneyCharacterA.Text));
                    DataStorage.personsList[selectedCharacterIndexB].GiveMoney(DataStorage.personsList[selectedCharacterIndexA], Convert.ToInt32(TxtGiveMoneyCharacterB.Text));
                    TbMoneyCharacterA.Text = DataStorage.personsList[selectedCharacterIndexA].Money.ToString();
                    TbMoneyCharacterB.Text = DataStorage.personsList[selectedCharacterIndexB].Money.ToString();
                    TxtGiveMoneyCharacterA.Text = "0";
                    TxtGiveMoneyCharacterB.Text = "0";
                    //var x = DataStorage.personsList.Where(c => c == SelectedCharacterA).ToList().First();
                    //DataStorage.personsList.Where(c => c == SelectedCharacterB);
                }
                TxtTotalValueOne.Text = "0";
                TxtTotalValueTwo.Text = "0";
            }


            

            if (LvInventoryOne.SelectedIndex > -1)
            {
                TxtDescriptionOne.Text = "";
                int totalValue = Convert.ToInt32(TxtTotalValueOne.Text);
                foreach (var selectedItem in LvInventoryOne.SelectedItems)
                {
                    LvItemsToTradeOne.Items.Add(selectedItem);
                    var selectedItemValue = (Item)selectedItem;
                    totalValue += selectedItemValue.Value;
                }

                TxtTotalValueOne.Text = totalValue.ToString();

                while (LvInventoryOne.SelectedItems.Count > 0)
                {
                    LvInventoryOne.Items.Remove(LvInventoryOne.SelectedItems[0]);
                }
            }
        }

        private void CmbCharacterB_DropDownClosed(object sender, EventArgs e)
        {
            LvItemsToTradeTwo.Items.Clear();
            TxtDescriptionTwo.Clear();
            TxtTotalValueTwo.Text = "0";
            LvInventoryTwo.Items.Clear();
            foreach (var person in DataStorage.personsList)
            {
                if (person.FullName == (string) CmbCharacterB.SelectedItem)
                    SelectedCharacterB = person;
            }

            if (CmbCharacterB.SelectedItem != null)
            {
                foreach (var person in DataStorage.personsList)
                {
                    if (person.FullName == CmbCharacterB.SelectedItem.ToString())
                    {
                        SelectedCharacterB = person;
                    }
                }

                //LvInventoryOne.ItemsSource = selectedPerson.ItemList;
                TbMoneyCharacterB.Text = SelectedCharacterB.Money.ToString();
                foreach (var item in SelectedCharacterB.ItemList)
                {
                    LvInventoryTwo.Items.Add(item);
                }
            }
        }

        private void LvItemsToTradeOne_LayoutUpdated(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(TxtGiveMoneyCharacterA.Text, out value) && int.TryParse(TxtGiveMoneyCharacterB.Text, out value))
            {
                if (LvItemsToTradeOne.Items.Count != 0 || Convert.ToInt32(TxtGiveMoneyCharacterA.Text) > 0 && Convert.ToInt32(TxtGiveMoneyCharacterA.Text) <= Convert.ToInt32(TbMoneyCharacterA.Text))
                {
                    BtnTrade.IsEnabled = true;
                }
                else if (LvItemsToTradeTwo.Items.Count != 0 || Convert.ToInt32(TxtGiveMoneyCharacterB.Text) > 0 && Convert.ToInt32(TxtGiveMoneyCharacterB.Text) <= Convert.ToInt32(TbMoneyCharacterB.Text))
                {
                    BtnTrade.IsEnabled = true;
                }
                else
                {
                    BtnTrade.IsEnabled = false;
                }
            }

        }

        private void LvInventoryTwo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LvInventoryTwo.SelectedItem != null)
            {
                var selectedItem = (Item)LvInventoryTwo.SelectedItem;
                TxtDescriptionTwo.Text = selectedItem.Description;
            }
        }

        private void BtnAddItemOne_Click(object sender, RoutedEventArgs e)
        {
            if (LvInventoryOne.SelectedIndex > -1)
            {
                TxtDescriptionOne.Text = "";
                int totalValue = Convert.ToInt32(TxtTotalValueOne.Text);
                foreach (var selectedItem in LvInventoryOne.SelectedItems)
                {
                    LvItemsToTradeOne.Items.Add(selectedItem);
                    var selectedItemValue = (Item)selectedItem;
                    totalValue += selectedItemValue.Value;
                }

                TxtTotalValueOne.Text = totalValue.ToString();

                while (LvInventoryOne.SelectedItems.Count > 0)
                {
                    LvInventoryOne.Items.Remove(LvInventoryOne.SelectedItems[0]);
                }
            }
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            int totalValue = Convert.ToInt32(TxtTotalValueTwo.Text);
            foreach (var item in LvItemsToTradeTwo.Items)
            {
                LvInventoryTwo.Items.Add(item);
                var selectedItemValue = (Item)item;
                totalValue -= selectedItemValue.Value;
            }

            TxtTotalValueTwo.Text = totalValue.ToString();
            while (LvItemsToTradeTwo.Items.Count > 0)
            {
                LvItemsToTradeTwo.Items.Remove(LvItemsToTradeTwo.Items[0]);
            }
        }

        private void LvItemsToTradeTwo_LayoutUpdated(object sender, EventArgs e)
        {

        }

        private void TxtGiveMoneyCharacterA_TextChanged(object sender, TextChangedEventArgs e)
        {
            //int value;
            //if (int.TryParse(TxtGiveMoneyCharacterA.Text, out value))
            //{
            //    TxtTotalValueOne.Text = (Convert.ToInt32(TxtGiveMoneyCharacterA.Text) + Convert.ToInt32(TxtTotalValueOne.Text)).ToString();
            //}
        }

        private void TxtGiveMoneyCharacterB_TextChanged(object sender, TextChangedEventArgs e)
        {
            //int value;
            //if (int.TryParse(TxtGiveMoneyCharacterB.Text, out value))
            //{
            //    TxtTotalValueTwo.Text = (Convert.ToInt32(TxtGiveMoneyCharacterB.Text) + Convert.ToInt32(TxtTotalValueTwo.Text)).ToString();
            //}
        }

        private void BtnRemoveItemTwo_Click(object sender, RoutedEventArgs e)
        {
            int totalValue = Convert.ToInt32(TxtTotalValueTwo.Text);
            foreach (var selectedItem in LvItemsToTradeTwo.SelectedItems)
            {
                LvInventoryTwo.Items.Add(selectedItem);
                var selectedItemValue = (Item)selectedItem;
                totalValue -= selectedItemValue.Value;
            }

            TxtTotalValueTwo.Text = totalValue.ToString();
            while (LvItemsToTradeTwo.SelectedItems.Count > 0)
            {
                LvItemsToTradeTwo.Items.Remove(LvItemsToTradeTwo.SelectedItems[0]);
            }
        }
    }
}
