using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Threading;

namespace PExer02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Person _selectedCharacterA;
        private Person _selectedCharacterB;


        public MainWindow()
        {
            InitializeComponent();

            #region ListView Creation

            //LvInventoryOne
            GridView gvInventory = new GridView();
            gvInventory.AllowsColumnReorder = true;
            LvInventoryOne.View = gvInventory;

            //LvInventoryOne Column 1
            GridViewColumn lvInventoryGridViewOne = new GridViewColumn();
            lvInventoryGridViewOne.DisplayMemberBinding = new Binding("AttachedItem.Name");
            lvInventoryGridViewOne.Header = "Item Name";
            lvInventoryGridViewOne.Width = 90;

            //LvInventoryOne Column 2
            GridViewColumn lvInventoryGridViewTwo = new GridViewColumn();
            lvInventoryGridViewTwo.DisplayMemberBinding = new Binding("AttachedItem.Value");
            lvInventoryGridViewTwo.Header = "Value";
            lvInventoryGridViewTwo.Width = 50;

            //LvInventoryOne Column 2
            GridViewColumn lvInventoryGridViewThree = new GridViewColumn();
            lvInventoryGridViewThree.DisplayMemberBinding = new Binding("Quantity");
            lvInventoryGridViewThree.Header = "Amnt.";
            lvInventoryGridViewThree.Width = 50;

            gvInventory.Columns.Add(lvInventoryGridViewOne);
            gvInventory.Columns.Add(lvInventoryGridViewTwo);
            gvInventory.Columns.Add(lvInventoryGridViewThree);


            //LvItemsToTradeOne
            var gvItemsToTrade = new GridView();
            gvItemsToTrade.AllowsColumnReorder = true;
            LvItemsToTradeOne.View = gvItemsToTrade;

            //LvItemsToTradeOne Column 1
            var lvItemsToTradeGridViewOne = new GridViewColumn();
            lvItemsToTradeGridViewOne.DisplayMemberBinding = new Binding("AttachedItem.Name");
            lvItemsToTradeGridViewOne.Header = "Item Name";
            lvItemsToTradeGridViewOne.Width = 100;

            //LvItemsToTradeOne Column 2
            var lvItemsToTradeGridViewTwo = new GridViewColumn();
            lvItemsToTradeGridViewTwo.DisplayMemberBinding = new Binding("AttachedItem.Value");
            lvItemsToTradeGridViewTwo.Header = "Value";
            lvItemsToTradeGridViewTwo.Width = 50;

            //LvItemsToTradeOne Column 3
            var lvItemsToTradeGridViewThree = new GridViewColumn();
            lvItemsToTradeGridViewThree.DisplayMemberBinding = new Binding("Quantity");
            lvItemsToTradeGridViewThree.Header = "Quantity";
            lvItemsToTradeGridViewThree.Width = 50;

            gvItemsToTrade.Columns.Add(lvItemsToTradeGridViewOne);
            gvItemsToTrade.Columns.Add(lvItemsToTradeGridViewTwo);
            gvItemsToTrade.Columns.Add(lvItemsToTradeGridViewThree);

            //LvInventoryTwo
            GridView gvInventoryTwo = new GridView();
            gvInventoryTwo.AllowsColumnReorder = true;
            LvInventoryTwo.View = gvInventoryTwo;

            //LvInventoryOne Column 1
            GridViewColumn lvInventoryTwoGridViewOne = new GridViewColumn();
            lvInventoryTwoGridViewOne.DisplayMemberBinding = new Binding("AttachedItem.Name");
            lvInventoryTwoGridViewOne.Header = "Item Name";
            lvInventoryTwoGridViewOne.Width = 90;

            //LvInventoryOne Column 2
            GridViewColumn lvInventoryTwoGridViewTwo = new GridViewColumn();
            lvInventoryTwoGridViewTwo.DisplayMemberBinding = new Binding("AttachedItem.Value");
            lvInventoryTwoGridViewTwo.Header = "Value";
            lvInventoryTwoGridViewTwo.Width = 50;

            GridViewColumn lvInventoryTwoGridViewThree = new GridViewColumn();
            lvInventoryTwoGridViewThree.DisplayMemberBinding = new Binding("Quantity");
            lvInventoryTwoGridViewThree.Header = "Amnt.";
            lvInventoryTwoGridViewThree.Width = 50;

            gvInventoryTwo.Columns.Add(lvInventoryTwoGridViewOne);
            gvInventoryTwo.Columns.Add(lvInventoryTwoGridViewTwo);
            gvInventoryTwo.Columns.Add(lvInventoryTwoGridViewThree);


            //LvItemsToTradeTwo
            var gvItemsToTradeTwo = new GridView();
            gvItemsToTradeTwo.AllowsColumnReorder = true;
            LvItemsToTradeTwo.View = gvItemsToTradeTwo;

            //LvItemsToTradeTwo Column 1
            var lvItemsToTradeTwoGridViewOne = new GridViewColumn();
            lvItemsToTradeTwoGridViewOne.DisplayMemberBinding = new Binding("AttachedItem.Name");
            lvItemsToTradeTwoGridViewOne.Header = "Item Name";
            lvItemsToTradeTwoGridViewOne.Width = 100;

            //LvItemsToTradeTwo Column 2
            var lvItemsToTradeTwoGridViewTwo = new GridViewColumn();
            lvItemsToTradeTwoGridViewTwo.DisplayMemberBinding = new Binding("AttachedItem.Value");
            lvItemsToTradeTwoGridViewTwo.Header = "Value";
            lvItemsToTradeTwoGridViewTwo.Width = 55;

            //LvItemsToTradeTwo Column 3
            var lvItemsToTradeTwoGridViewThree = new GridViewColumn();
            lvItemsToTradeTwoGridViewThree.DisplayMemberBinding = new Binding("Quantity");
            lvItemsToTradeTwoGridViewThree.Header = "Quantity";
            lvItemsToTradeTwoGridViewThree.Width = 55;

            gvItemsToTradeTwo.Columns.Add(lvItemsToTradeTwoGridViewOne);
            gvItemsToTradeTwo.Columns.Add(lvItemsToTradeTwoGridViewTwo);
            gvItemsToTradeTwo.Columns.Add(lvItemsToTradeTwoGridViewThree);

            #endregion
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

            var itemQuantityOne = new ItemQuantity(itemOne,5); 
            var itemQuantityTwo = new ItemQuantity(itemTwo,3); 
            var itemQuantityThree = new ItemQuantity(itemThree,1); 
            var itemQuantityFour = new ItemQuantity(itemFour,10); 
            var itemQuantityFive = new ItemQuantity(itemFive,8); 
            var itemQuantitySix = new ItemQuantity(itemSix,4); 
            var itemQuantitySeven = new ItemQuantity(itemSeven,7); 
            var itemQuantityEight = new ItemQuantity(itemEight,12); 
            var itemQuantityNine = new ItemQuantity(itemNine,4); 
            var itemQuantityTen = new ItemQuantity(itemTen,9); 
            var itemQuantityEleven = new ItemQuantity(itemOne,5); 
            var itemQuantityTwelve = new ItemQuantity(itemTwo,4); 
            var itemQuantityThirteen = new ItemQuantity(itemThree,2); 
            var itemQuantityFourteen = new ItemQuantity(itemFour,3); 
            var itemQuantityFifteen = new ItemQuantity(itemFive,6); 

            DataStorage.ItemList.Add(itemQuantityOne);
            DataStorage.ItemList.Add(itemQuantityTwo);
            DataStorage.ItemList.Add(itemQuantityThree);
            DataStorage.ItemList.Add(itemQuantityFour);
            DataStorage.ItemList.Add(itemQuantityFive);
            DataStorage.ItemList.Add(itemQuantitySix);
            DataStorage.ItemList.Add(itemQuantitySeven);
            DataStorage.ItemList.Add(itemQuantityEight);
            DataStorage.ItemList.Add(itemQuantityNine);
            DataStorage.ItemList.Add(itemQuantityTen);

            //List<Item> firstItemList = new List<Item>();
            //firstItemList.Add(itemTwo);
            //firstItemList.Add(itemFour);
            //firstItemList.Add(itemTen);

            //List<Item> secondItemList = new List<Item>();
            //secondItemList.Add(itemOne);
            //secondItemList.Add(itemFive);
            //secondItemList.Add(itemSix);

            //List<Item> thirdItemList = new List<Item>();
            //thirdItemList.Add(itemFive);
            //thirdItemList.Add(itemThree);
            //thirdItemList.Add(itemSeven);

            //List<Item> fourthItemList = new List<Item>();
            //fourthItemList.Add(itemSix);
            //fourthItemList.Add(itemOne);

            DataStorage.PersonsList.Add(new Person("Doe", "John", 1250));
            DataStorage.PersonsList.Add(new Person("Fox", "Meghan", 5050));
            DataStorage.PersonsList.Add(new Person("Carter", "Frank", 8020));
            DataStorage.PersonsList.Add(new Person("Johnson", "Robert", 4000));
            DataStorage.PersonsList.Add(new Person("Jenkins", "Leroy", 5000));

            DataStorage.PersonsList[0].ItemsOwned.Add(itemQuantityOne);
            DataStorage.PersonsList[0].ItemsOwned.Add(itemQuantityThree);
            DataStorage.PersonsList[0].ItemsOwned.Add(itemQuantityFour);
            DataStorage.PersonsList[1].ItemsOwned.Add(itemQuantityTwo);
            DataStorage.PersonsList[1].ItemsOwned.Add(itemQuantityFourteen);
            DataStorage.PersonsList[1].ItemsOwned.Add(itemQuantityFifteen);
            DataStorage.PersonsList[2].ItemsOwned.Add(itemQuantityEleven);
            DataStorage.PersonsList[2].ItemsOwned.Add(itemQuantitySix);
            DataStorage.PersonsList[2].ItemsOwned.Add(itemQuantitySeven);
            DataStorage.PersonsList[2].ItemsOwned.Add(itemQuantityEight);
            DataStorage.PersonsList[3].ItemsOwned.Add(itemQuantityNine);
            DataStorage.PersonsList[3].ItemsOwned.Add(itemQuantityThirteen);
            DataStorage.PersonsList[3].ItemsOwned.Add(itemQuantityFifteen);
            DataStorage.PersonsList[4].ItemsOwned.Add(itemQuantityTen);
            DataStorage.PersonsList[4].ItemsOwned.Add(itemQuantityFive);
            DataStorage.PersonsList[4].ItemsOwned.Add(itemQuantityTwelve);

            List<string> nameList = new List<string>();

            foreach (var person in DataStorage.PersonsList)
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

        //Loading of items into ListView\
        public void LoadCmbCharacterA()
        {
            LvInventoryOne.Items.Clear();
            LvItemsToTradeOne.Items.Clear();
            TxtDescriptionOne.Clear();
            TxtTotalValueOne.Text = "0";
            if (CmbCharacterA.SelectedItem != null)
            {
                foreach (var person in DataStorage.PersonsList)
                {
                    if (person.FullName == CmbCharacterA.SelectedItem.ToString())
                    {
                        _selectedCharacterA = person;
                    }
                }

                TbMoneyCharacterA.Text = _selectedCharacterA.Money.ToString();
                foreach (var item in _selectedCharacterA.ItemsOwned)
                {
                    var listViewItems = new ItemQuantity(item.AttachedItem, item.Quantity);
                    DataStorage.ListViewCharacterAInventory.Add(listViewItems);
                    LvInventoryOne.Items.Add(listViewItems);
                }
            }
        }

        private void CmbCharacterA_DropDownClosed(object sender, EventArgs e)
        {
           LoadCmbCharacterA();
        }

        //TO BE CONTINUED
        private void BtnAddItemOne_Click(object sender, RoutedEventArgs e)
        {
            foreach (var selectedItem in LvInventoryOne.SelectedItems)
            {
                var itemExists = false;
                foreach (var itemToTrade in LvItemsToTradeOne.Items)
                {
                    if (((ItemQuantity)itemToTrade).AttachedItem == ((ItemQuantity)selectedItem).AttachedItem)
                    {
                        itemExists = true;
                    }

                    if (itemExists && ((ItemQuantity)selectedItem).Quantity > 0)
                    {
                        ((ItemQuantity)selectedItem).Quantity -= 1;
                        ((ItemQuantity)itemToTrade).Quantity += 1;

                        LvItemsToTradeOne.Items.Refresh();
                    }
                }

                if (!itemExists && ((ItemQuantity)selectedItem).Quantity > 0)
                {
                    var prepItem = new ItemQuantity(((ItemQuantity)selectedItem).AttachedItem,1);
                    ((ItemQuantity)selectedItem).Quantity -= 1;

                    LvItemsToTradeOne.Items.Add(prepItem);
                }
            }

            float totalValue = 0;
            foreach (var itemToTrade in LvItemsToTradeOne.Items)
            {
                totalValue += ((ItemQuantity) itemToTrade).AttachedItem.Value * ((ItemQuantity) itemToTrade).Quantity;

                TxtTotalValueOne.Text = (totalValue).ToString();
            }

            LvInventoryOne.Items.Refresh();
        }

        private void BtnAddItemTwo_Click(object sender, RoutedEventArgs e)
        {
            foreach (var selectedItem in LvInventoryTwo.SelectedItems)
            {
                var itemExists = false;
                foreach (var itemToTrade in LvItemsToTradeTwo.Items)
                {
                    if (((ItemQuantity)itemToTrade).AttachedItem == ((ItemQuantity)selectedItem).AttachedItem)
                    {
                        itemExists = true;
                    }

                    if (itemExists && ((ItemQuantity)selectedItem).Quantity > 0)
                    {
                        ((ItemQuantity)selectedItem).Quantity -= 1;
                        ((ItemQuantity)itemToTrade).Quantity += 1;

                        LvItemsToTradeTwo.Items.Refresh();
                    }
                }

                if (!itemExists && ((ItemQuantity)selectedItem).Quantity > 0)
                {
                    var prepItem = new ItemQuantity(((ItemQuantity)selectedItem).AttachedItem, 1);
                    ((ItemQuantity)selectedItem).Quantity -= 1;

                    LvItemsToTradeTwo.Items.Add(prepItem);
                }
            }

            float totalValue = 0;
            foreach (var itemToTrade in LvItemsToTradeTwo.Items)
            {
                totalValue += ((ItemQuantity)itemToTrade).AttachedItem.Value * ((ItemQuantity)itemToTrade).Quantity;

                TxtTotalValueTwo.Text = (totalValue).ToString();
            }

            LvInventoryTwo.Items.Refresh();
        }

        private void BtnRemoveItemOne_Click(object sender, RoutedEventArgs e)
        {
            foreach (var selectedItem in LvItemsToTradeOne.SelectedItems)
            {
                if (((ItemQuantity) selectedItem).Quantity > 0)
                {
                    foreach (var item in LvInventoryOne.Items)
                    {
                        if (((ItemQuantity) selectedItem).AttachedItem == ((ItemQuantity) item).AttachedItem)
                        {
                            ((ItemQuantity) item).Quantity += 1;
                        }
                    }
                    ((ItemQuantity)selectedItem).Quantity--;
                }

                if (((ItemQuantity)selectedItem).Quantity == 0)
                    LvItemsToTradeOne.Items.Remove(selectedItem);

                if (LvItemsToTradeOne.Items.Count == 0)
                    break;
            }

            float totalValue = 0;
            foreach (var itemToTrade in LvItemsToTradeOne.Items)
            {
                totalValue += ((ItemQuantity)itemToTrade).AttachedItem.Value * ((ItemQuantity)itemToTrade).Quantity;

                TxtTotalValueOne.Text = (totalValue).ToString();
            }

            LvInventoryOne.Items.Refresh();
            LvItemsToTradeOne.Items.Refresh();
        }

        private void ButtonCharacterA_ClearItemsToTrade(object sender, RoutedEventArgs e)
        {
            float totalValue = float.Parse(TxtTotalValueOne.Text);
            foreach (var tradeItem in LvItemsToTradeOne.Items)
            {
                foreach (var inventoryItem in LvInventoryOne.Items)
                {
                    if (((ItemQuantity) tradeItem).AttachedItem == ((ItemQuantity) inventoryItem).AttachedItem)
                    {
                        while (((ItemQuantity) tradeItem).Quantity > 0)
                        {
                            ++((ItemQuantity) inventoryItem).Quantity;
                            --((ItemQuantity) tradeItem).Quantity;
                            totalValue = totalValue - ((ItemQuantity) inventoryItem).AttachedItem.Value;
                        }
                    }
                }
            }

            TxtTotalValueOne.Text = totalValue.ToString();
            LvItemsToTradeOne.Items.Clear();
            LvInventoryOne.Items.Refresh();
            LvItemsToTradeOne.Items.Refresh();
            //TxtTotalValueOne.Text = totalValue.ToString();
            //while (LvItemsToTradeOne.Items.Count > 0)
            //{
            //    LvItemsToTradeOne.Items.Remove(LvItemsToTradeOne.Items[0]);
            //}
        }

        private void LvInventoryOne_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LvInventoryOne.SelectedItem != null)
            {
                var selectedItem = (ItemQuantity)LvInventoryOne.SelectedItem;
                TxtDescriptionOne.Text = selectedItem.AttachedItem.Description;
                BtnAddItemOne.Visibility = Visibility.Visible;
            }
            else
            {
                BtnAddItemOne.Visibility = Visibility.Hidden;
            }
        }
        //Trade Button
        private void BtnTrade_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedCharacterA == _selectedCharacterB)
            {
                MessageBox.Show("Can't trade items with yourself!", "Error", MessageBoxButton.OK, MessageBoxImage.Hand);
                return;
            }

            if (float.Parse(TxtGiveMoneyCharacterA.Text) > 0)
            {
                _selectedCharacterA.GiveMoney(_selectedCharacterB, float.Parse(TxtGiveMoneyCharacterA.Text));
            }

            if (float.Parse(TxtGiveMoneyCharacterB.Text) > 0)
                _selectedCharacterB.GiveMoney(_selectedCharacterA, float.Parse(TxtGiveMoneyCharacterB.Text));

            if (LvItemsToTradeOne.Items.Count != 0)
            {
                foreach (var itemToTrade in LvItemsToTradeOne.Items)
                {
                    foreach (var itemQuantity in _selectedCharacterA.ItemsOwned)
                    {
                        if (itemQuantity.AttachedItem == ((ItemQuantity)itemToTrade).AttachedItem)
                        {
                            _selectedCharacterA.GiveItem(_selectedCharacterB, itemQuantity, ((ItemQuantity)itemToTrade).Quantity);
                            break;
                        }
                    }
                }
            }

            if (LvItemsToTradeTwo.Items.Count != 0)
            {
                foreach (var itemToTrade in LvItemsToTradeTwo.Items)
                {
                    foreach (var itemQuantity in _selectedCharacterB.ItemsOwned)
                    {
                        if (itemQuantity.AttachedItem == ((ItemQuantity)itemToTrade).AttachedItem)
                        {
                            _selectedCharacterB.GiveItem(_selectedCharacterA, itemQuantity, ((ItemQuantity)itemToTrade).Quantity);
                            break;
                        }
                    }
                }
            }

            TxtGiveMoneyCharacterA.Text = "0";
            TxtGiveMoneyCharacterB.Text = "0";
            LoadCmbCharacterA();
            LoadCmbCharacterB();
            #region OLD CODE
            //var selectedCharacterIndexA = DataStorage.PersonsList.IndexOf(_selectedCharacterA);
            //var selectedCharacterIndexB = DataStorage.PersonsList.IndexOf(_selectedCharacterB);
            //bool duplicateItem = false;

            //foreach (var item in LvItemsToTradeOne.Items)
            //{
            //    if (DataStorage.PersonsList[selectedCharacterIndexB].ItemsOwned.Contains(item))
            //        duplicateItem = true;
            //}

            //foreach (var item in LvItemsToTradeTwo.Items)
            //{
            //    if (DataStorage.PersonsList[selectedCharacterIndexA].ItemsOwned.Contains(item))
            //        duplicateItem = true;
            //}

            //if (duplicateItem)
            //    MessageBox.Show("Duplicate item detected");

            //if (CmbCharacterA.SelectedIndex > -1 && CmbCharacterB.SelectedIndex > -1 && !duplicateItem)
            //{
            //    if (LvItemsToTradeOne.Items.Count != 0 || LvItemsToTradeTwo.Items.Count != 0)
            //    {
            //        LvInventoryOne.Items.Clear();
            //        LvInventoryTwo.Items.Clear();
            //        foreach (var item in LvItemsToTradeOne.Items)
            //        {
            //            foreach (var itemQuantity in DataStorage.PersonsList[selectedCharacterIndexA].ItemsOwned)
            //            {
            //                if (itemQuantity.AttachedItem == item)
            //                {
            //                    DataStorage.PersonsList[selectedCharacterIndexA].GiveItem(DataStorage.PersonsList[selectedCharacterIndexB], itemQuantity, 1);
            //                    break;
            //                }
            //            }

            //        }

            //        foreach (var item in LvItemsToTradeTwo.Items)
            //        {
            //            foreach (var itemQuantity in DataStorage.PersonsList[selectedCharacterIndexB].ItemsOwned)
            //            {
            //                if (itemQuantity.AttachedItem == item)
            //                {
            //                    DataStorage.PersonsList[selectedCharacterIndexB].GiveItem(DataStorage.PersonsList[selectedCharacterIndexA], itemQuantity, 1);
            //                    break;
            //                }
            //            }
            //        }

            //        foreach (var item in DataStorage.PersonsList[selectedCharacterIndexA].ItemsOwned)
            //        {
            //            LvInventoryOne.Items.Add((Item)item.AttachedItem);
            //        }


            //        foreach (var item in DataStorage.PersonsList[selectedCharacterIndexB].ItemsOwned)
            //        {
            //            LvInventoryTwo.Items.Add(item.AttachedItem);
            //            LvInventoryTwo.Items.Add(item);
            //        }
            //        LvItemsToTradeOne.Items.Clear();
            //        LvItemsToTradeTwo.Items.Clear();
            //    }

            //    if (Convert.ToInt32(TxtGiveMoneyCharacterA.Text) > 0 || Convert.ToInt32(TxtGiveMoneyCharacterB.Text) > 0)
            //    {
            //        DataStorage.PersonsList[selectedCharacterIndexA].GiveMoney(DataStorage.PersonsList[selectedCharacterIndexB], Convert.ToInt32(TxtGiveMoneyCharacterA.Text));
            //        DataStorage.PersonsList[selectedCharacterIndexB].GiveMoney(DataStorage.PersonsList[selectedCharacterIndexA], Convert.ToInt32(TxtGiveMoneyCharacterB.Text));
            //        TbMoneyCharacterA.Text = DataStorage.PersonsList[selectedCharacterIndexA].Money.ToString();
            //        TbMoneyCharacterB.Text = DataStorage.PersonsList[selectedCharacterIndexB].Money.ToString();
            //        TxtGiveMoneyCharacterA.Text = "0";
            //        TxtGiveMoneyCharacterB.Text = "0";
            //        //var x = DataStorage.PersonsList.Where(c => c == _selectedCharacterA).ToList().First();
            //        //DataStorage.PersonsList.Where(c => c == _selectedCharacterB);
            //    }
            //    TxtTotalValueOne.Text = "0";
            //    TxtTotalValueTwo.Text = "0";
            //}




            //if (LvInventoryOne.SelectedIndex > -1)
            //{
            //    TxtDescriptionOne.Text = "";
            //    float totalValue = Convert.ToInt32(TxtTotalValueOne.Text);
            //    foreach (var selectedItem in LvInventoryOne.SelectedItems)
            //    {
            //        LvItemsToTradeOne.Items.Add(selectedItem);
            //        var selectedItemValue = (Item)selectedItem;
            //        totalValue += selectedItemValue.Value;
            //    }

            //    TxtTotalValueOne.Text = totalValue.ToString();

            //    while (LvInventoryOne.SelectedItems.Count > 0)
            //    {
            //        LvInventoryOne.Items.Remove(LvInventoryOne.SelectedItems[0]);
            //    }
            //}
            #endregion
        }

        public void LoadCmbCharacterB()
        {
            LvInventoryTwo.Items.Clear();
            LvItemsToTradeTwo.Items.Clear();
            TxtDescriptionTwo.Clear();
            TxtTotalValueTwo.Text = "0";
            if (CmbCharacterB.SelectedItem != null)
            {
                foreach (var person in DataStorage.PersonsList)
                {
                    if (person.FullName == CmbCharacterB.SelectedItem.ToString())
                    {
                        _selectedCharacterB = person;
                    }
                }

                TbMoneyCharacterB.Text = _selectedCharacterB.Money.ToString();
                foreach (var item in _selectedCharacterB.ItemsOwned)
                {
                    var listViewItems = new ItemQuantity(item.AttachedItem, item.Quantity);
                    DataStorage.ListViewCharacterBInventory.Add(listViewItems);
                    LvInventoryTwo.Items.Add(listViewItems);
                }
            }
        }

        private void CmbCharacterB_DropDownClosed(object sender, EventArgs e)
        {
            LoadCmbCharacterB();
        }

        private void LvItemsToTradeOne_LayoutUpdated(object sender, EventArgs e)
        {
            if (!LvItemsToTradeOne.Items.IsEmpty)
                BtnRemoveAllItemsOne.Visibility = Visibility.Visible;
            else
                BtnRemoveAllItemsOne.Visibility = Visibility.Hidden;
            
            if (CmbCharacterA.Text == "" || CmbCharacterB.Text == "")
                return;

            float value;
            string txtCharacterMoneyA = TxtGiveMoneyCharacterA.Text;
            string txtCharacterMoneyB = TxtGiveMoneyCharacterB.Text;

            if (TxtGiveMoneyCharacterA.Text == "")
                txtCharacterMoneyA = "0";
            if (TxtGiveMoneyCharacterB.Text == "")
                txtCharacterMoneyB = "0";


            if (float.TryParse(txtCharacterMoneyA, out value) || float.TryParse(txtCharacterMoneyB, out value))
            {
                if (float.Parse(txtCharacterMoneyA) <= float.Parse(TbMoneyCharacterA.Text) && float.Parse(txtCharacterMoneyB) <= float.Parse(TbMoneyCharacterB.Text))
                {
                    BtnTrade.IsEnabled = true;
                }
                else
                {
                    BtnTrade.IsEnabled = false;
                    return;
                }

                if (LvItemsToTradeOne.Items.Count != 0 || LvItemsToTradeTwo.Items.Count != 0)
                {
                    BtnTrade.IsEnabled = true;
                }
                else if(txtCharacterMoneyA == "0" && txtCharacterMoneyB == "0")
                {
                    BtnTrade.IsEnabled = false;
                }
            }

        }

        private void LvInventoryTwo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LvInventoryTwo.SelectedItem != null)
            {
                var selectedItem = (ItemQuantity)LvInventoryTwo.SelectedItem;
                TxtDescriptionTwo.Text = selectedItem.AttachedItem.Description;
                BtnAddItemTwo.Visibility = Visibility.Visible;
            }
            else
                BtnAddItemTwo.Visibility = Visibility.Hidden;
        }


        private void ButtonCharacterB_ClearItemsToTrade(object sender, RoutedEventArgs e)
        {
            float totalValue = float.Parse(TxtTotalValueTwo.Text);

            foreach (var tradeItem in LvItemsToTradeTwo.Items)
            {
                foreach (var inventoryItem in LvInventoryTwo.Items)
                {
                    if (((ItemQuantity)tradeItem).AttachedItem == ((ItemQuantity)inventoryItem).AttachedItem)
                    {
                        while (((ItemQuantity)tradeItem).Quantity > 0)
                        {
                            ++((ItemQuantity)inventoryItem).Quantity;
                            --((ItemQuantity)tradeItem).Quantity;
                            totalValue = totalValue - ((ItemQuantity)inventoryItem).AttachedItem.Value;
                        }
                    }
                }
            }

            TxtTotalValueTwo.Text = totalValue.ToString();
            LvItemsToTradeTwo.Items.Clear();
            LvInventoryTwo.Items.Refresh();
            LvItemsToTradeTwo.Items.Refresh();

            #region OldCode

            //float totalValue = Convert.ToInt32(TxtTotalValueTwo.Text);
            //foreach (var item in LvItemsToTradeTwo.Items)
            //{
            //    LvInventoryTwo.Items.Add(item);
            //    var selectedItemValue = (ListViewTemplate)item;
            //    totalValue -= selectedItemValue.Value;
            //}

            //TxtTotalValueTwo.Text = totalValue.ToString();
            //while (LvItemsToTradeTwo.Items.Count > 0)
            //{
            //    LvItemsToTradeTwo.Items.Remove(LvItemsToTradeTwo.Items[0]);
            //}

            #endregion

        }

        private void LvItemsToTradeTwo_LayoutUpdated(object sender, EventArgs e)
        {
            if (!LvItemsToTradeTwo.Items.IsEmpty)
                BtnRemoveAllItemsTwo.Visibility = Visibility.Visible;
            else
            {
                BtnRemoveAllItemsTwo.Visibility = Visibility.Hidden;
            }
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

            foreach (var selectedItem in LvItemsToTradeTwo.SelectedItems)
            {
                if (((ItemQuantity) selectedItem).Quantity > 0)
                {
                    foreach (var item in LvInventoryTwo.Items)
                    {
                        if (((ItemQuantity) selectedItem).AttachedItem == ((ItemQuantity) item).AttachedItem)
                        {
                            ((ItemQuantity) item).Quantity += 1;
                        }
                    }

                    ((ItemQuantity) selectedItem).Quantity--;
                }

                if (((ItemQuantity) selectedItem).Quantity == 0)
                    LvItemsToTradeTwo.Items.Remove(selectedItem);

                if (LvItemsToTradeTwo.Items.Count == 0)
                    break;
            }

            LvInventoryTwo.Items.Refresh();
            LvItemsToTradeTwo.Items.Refresh();

            #region OldRegion

                //float totalValue = Convert.ToInt32(TxtTotalValueTwo.Text);
                //foreach (var selectedItem in LvItemsToTradeTwo.SelectedItems)
                //{
                //    LvInventoryTwo.Items.Add(selectedItem);
                //    var selectedItemValue = (ListViewTemplate)selectedItem;
                //    totalValue -= selectedItemValue.Value;
                //}

                //TxtTotalValueTwo.Text = totalValue.ToString();
                //while (LvItemsToTradeTwo.SelectedItems.Count > 0)
                //{
                //    LvItemsToTradeTwo.Items.Remove(LvItemsToTradeTwo.SelectedItems[0]);
                //}

                #endregion

        }

        private void TxtGiveMoneyCharacterA_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private void TxtGiveMoneyCharacterA_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TxtGiveMoneyCharacterA.Text == "")
                TxtGiveMoneyCharacterA.Text = "0";
        }

        private void TxtGiveMoneyCharacterB_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TxtGiveMoneyCharacterB.Text == "")
                TxtGiveMoneyCharacterB.Text = "0";
        }

        private void LvItemsToTradeOne_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LvItemsToTradeOne.SelectedItem != null)
            {
                BtnRemoveItemOne.Visibility = Visibility.Visible;
            }
            else
            {
                BtnRemoveItemOne.Visibility = Visibility.Hidden;
            }
        }

        private void LvItemsToTradeTwo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LvItemsToTradeTwo.SelectedItem != null)
            {
                BtnRemoveItemTwo.Visibility = Visibility.Visible;
            }
            else
            {
                BtnRemoveItemTwo.Visibility = Visibility.Hidden;
            }
        }
    }
}
