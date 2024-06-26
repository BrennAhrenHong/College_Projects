using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Text.RegularExpressions;
using System.Threading;

namespace FExer01_A
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StackPanel StartingPeg { get; set; }
        private StackPanel AuxiliaryPeg { get; set; }
        private StackPanel EndingPeg { get; set; }

        private int ListBoxInstructionsLineNumber { get; set; } = 1;
        private int ListBoxInstructionsIndex { get; set; } = 0;

        private int VisibleDiskCount { get; set; }
        private Rectangle[] _disksToBeUsed = new Rectangle[12];

        public MainWindow()
        {
            InitializeComponent();
        }

        public void AddDisksToPeg()
        {
            Disks addDisk = new Disks();

            StackPanelLeftPeg.Children.Clear();
            StackPanelMiddlePeg.Children.Clear();
            StackPanelRightPeg.Children.Clear();


            _disksToBeUsed = addDisk.CreateDisks(VisibleDiskCount);

            for (int i = _disksToBeUsed.Length - 1; i > -1; i--)
            {
                StartingPeg.Children.Add(_disksToBeUsed[i]);
            }
        }

        public void InstructionsGenerationLogic(int moves, StackPanel startPeg, StackPanel endPeg, StackPanel auxPeg)
        {
            if (moves > 0)
            {
                InstructionsGenerationLogic(moves - 1, startPeg, auxPeg, endPeg);
                ListBoxInstructions.Items.Add($"{ListBoxInstructionsLineNumber}. Move Disk {moves} from " + startPeg.Name + " To " + endPeg.Name);
                ListBoxInstructionsLineNumber++;
                InstructionsGenerationLogic(moves - 1, auxPeg, endPeg, startPeg);
            }
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            //0 < 7
            if (ListBoxInstructionsIndex < ListBoxInstructionsLineNumber - 1)
            {
                //moves,startpeg,endpeg
                //3,5,7
                BtnPrevious.IsEnabled = true;
                var tmpArray = ListBoxInstructions.Items[ListBoxInstructionsIndex].ToString().Split(' ');

                StackPanel[] utilizedPegs = { StartingPeg, AuxiliaryPeg, EndingPeg };

                for (int i = 0; i < 3; i++)
                {
                    if (tmpArray[5] == utilizedPegs[i].Name)
                    {
                        var tmp = utilizedPegs[i].Children[0];
                        utilizedPegs[i].Children.Remove(tmp);

                        for (int j = 0; j < 3; j++)
                        {
                            if (tmpArray[7] == utilizedPegs[j].Name)
                                utilizedPegs[j].Children.Insert(0, tmp);
                        }

                        break;
                    }
                }
                ListBoxInstructionsIndex++;
                if (ListBoxInstructionsIndex == ListBoxInstructionsLineNumber - 1)
                {
                    BtnNext.IsEnabled = false;
                }

                if (ListBoxInstructions.SelectedIndex == ListBoxInstructions.Items.Count - 1)
                {
                    BtnNext.IsEnabled = false;
                }

                if (ListBoxInstructions.SelectedIndex != ListBoxInstructions.Items.Count - 1)
                {
                    TextBlockExecutedInstruction.Text = ListBoxInstructions.SelectedItem.ToString();
                    ListBoxInstructions.SelectedIndex++;
                }
                else
                {
                    TextBlockExecutedInstruction.Text = ListBoxInstructions.SelectedItem.ToString();
                    ListBoxInstructions.SelectedIndex = -1;
                }


                ListBoxInstructions.ScrollIntoView(ListBoxInstructions.SelectedItem);
            }
            else
            {
                BtnNext.IsEnabled = false;
            }
        }

        private void BtnPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxInstructionsIndex > 0)
            {
                //moves,startpeg,endpeg
                //3,5,7
                BtnNext.IsEnabled = true;
                //redvelvet04
                ListBoxInstructionsIndex--; //Index minimum is 1
                
                var tmpArray = ListBoxInstructions.Items[ListBoxInstructionsIndex].ToString().Split(' ');

                StackPanel[] utilizedPegs = { StartingPeg, AuxiliaryPeg, EndingPeg };

                for (int i = 0; i < 3; i++)
                {
                    if (tmpArray[7] == utilizedPegs[i].Name)
                    {
                        var tmp = utilizedPegs[i].Children[0];
                        utilizedPegs[i].Children.Remove(tmp);

                        for (int j = 0; j < 3; j++)
                        {
                            if (tmpArray[5] == utilizedPegs[j].Name)
                                utilizedPegs[j].Children.Insert(0, tmp);
                        }
                        break;
                    }
                }

                if (ListBoxInstructionsIndex == 0)
                    BtnPrevious.IsEnabled = false;

                if (ListBoxInstructions.SelectedIndex == 1)
                {
                    BtnPrevious.IsEnabled = false;
                    TextBlockExecutedInstruction.Text = String.Empty;
                    ListBoxInstructions.SelectedIndex--;
                }

                if (ListBoxInstructions.SelectedIndex > 1 && ListBoxInstructions.SelectedIndex != -1)
                {
                    ListBoxInstructions.SelectedIndex = ListBoxInstructions.SelectedIndex - 1;
                    ListBoxInstructions.SelectedIndex = ListBoxInstructions.SelectedIndex - 1;
                    TextBlockExecutedInstruction.Text = ListBoxInstructions.SelectedItem.ToString();
                    ListBoxInstructions.SelectedIndex = ListBoxInstructions.SelectedIndex + 1;
                }
                else if(ListBoxInstructions.SelectedIndex == -1)
                {
                    ListBoxInstructions.SelectedIndex = ListBoxInstructions.Items.Count - 1;
                    ListBoxInstructions.SelectedIndex--;
                    TextBlockExecutedInstruction.Text = ListBoxInstructions.SelectedItem.ToString();
                    ListBoxInstructions.SelectedIndex++;
                }


                //TextBlockExecutedInstruction.Text = ListBoxInstructions.Items[ListBoxInstructions.SelectedIndex].ToString();
                //if (ListBoxInstructionsIndex > 0)
                //    ListBoxInstructions.SelectedIndex = ListBoxInstructionsIndex;
                //else if (ListBoxInstructionsIndex == 0)
                //{
                //    TextBlockExecutedInstruction.Text = "";
                //    ListBoxInstructions.SelectedIndex = ListBoxInstructionsIndex;
                //}


                ListBoxInstructions.ScrollIntoView(ListBoxInstructions.SelectedItem);

            }
            else
            {
                BtnPrevious.IsEnabled = false;
            }
        }

        public void ResetPegs()
        {
            StackPanelLeftPeg.Children.Clear();
            StackPanelMiddlePeg.Children.Clear();
            StackPanelRightPeg.Children.Clear();
            DiskSlider.Value = 0;
            CmbStartPeg.SelectedItem = null;
            CmbEndPeg.SelectedItem = null;
            StartingPeg = null;
            AuxiliaryPeg = null;
            EndingPeg = null;
            ListBoxInstructions.Items.Clear();
            ListBoxInstructionsLineNumber = 1;
            ListBoxInstructionsIndex = 0;
            BtnNext.IsEnabled = false;
            BtnPrevious.IsEnabled = false;
            BtnSolve.IsEnabled = true;
            DiskSlider.IsEnabled = true;
            TxtbNumberOfDisks.IsEnabled = true;
            CmbStartPeg.IsEnabled = true;
            CmbEndPeg.IsEnabled = true;
            TxtbLeftPeg.IsEnabled = true;
            TxtbMidPeg.IsEnabled = true;
            TxtbRightPeg.IsEnabled = true;
            TextBlockExecutedInstruction.Text = "";
        }

        // solves the tower of hanoi
        private void BtnSolve_Click(object sender, RoutedEventArgs e)
        {
            if (TxtbLeftPeg.Text != " " && TxtbMidPeg.Text != " " && TxtbRightPeg.Text != " " && CmbStartPeg.SelectedItem != null  && CmbEndPeg.SelectedItem != null)
            {
                InstructionsGenerationLogic(VisibleDiskCount, StartingPeg, EndingPeg, AuxiliaryPeg);
                if (ListBoxInstructionsIndex < VisibleDiskCount)
                    BtnNext.IsEnabled = true;
                BtnSolve.IsEnabled = false;
                DiskSlider.IsEnabled = false;
                TxtbNumberOfDisks.IsEnabled = false;
                CmbStartPeg.IsEnabled = false;
                CmbEndPeg.IsEnabled = false;
                TxtbLeftPeg.IsEnabled = false;
                TxtbMidPeg.IsEnabled = false;
                TxtbRightPeg.IsEnabled = false;

                ListBoxInstructions.SelectedIndex = ListBoxInstructionsIndex;
            }
            else
            {
                MessageBox.Show("Error, please fill out the name of the pegs and select a start peg and end peg.",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public void AuxiliaryPegIdentifier() //Identifies the auxiliary peg
        {
            StackPanel[] utilizedPegs = {StackPanelLeftPeg, StackPanelMiddlePeg, StackPanelRightPeg};
            string[] pegNames = {TxtbLeftPeg.Text, TxtbMidPeg.Text, TxtbRightPeg.Text};

            if (CmbStartPeg.SelectedItem != null && CmbEndPeg.SelectedItem != null)
            {
                for (int i = 0 ; i < 3 ; i++)
                {
                    if (StartingPeg == utilizedPegs[i])
                    {
                        utilizedPegs[i] = null;
                        continue;
                    }

                    if (EndingPeg == utilizedPegs[i])
                    {
                        utilizedPegs[i] = null;
                        continue;
                    }

                    AuxiliaryPeg = utilizedPegs[i];
                    AuxiliaryPeg.Name = pegNames[i];
                    break;
                }
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (CmbStartPeg.SelectedItem != null && CmbEndPeg.SelectedItem != null && StartingPeg != null)
            {
                TxtbNumberOfDisks.Text = DiskSlider.Value.ToString();
                VisibleDiskCount = Convert.ToInt32(DiskSlider.Value);
                AddDisksToPeg();

                for (int j = 0; j < DiskSlider.Value; j++)
                {
                    StartingPeg.Children[j].Visibility = Visibility.Visible;
                }
            }
            else
            {
                DiskSlider.Value = 0;
            }
            
        }

        private void TxtbNumberOfDisks_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(Regex.IsMatch(e.ToString(),"[0-9]"))
            {
                //if (Convert.ToInt32(TxtbNumberOfDisks.Text) > 12)
                //        TxtbNumberOfDisks.Text = "12";
                //if (Convert.ToInt32(TxtbNumberOfDisks.Text) < 0)
                //        TxtbNumberOfDisks.Text = "0";
            }
            else
            {
                TxtbNumberOfDisks.Text = DiskSlider.Value.ToString();
            }
        }

        private void CmbStartPeg_DropDownOpened(object sender, EventArgs e)
        {
            CmbStartPeg.Items.Clear();

            if (!CmbEndPeg.Text.Contains(TxtbLeftPeg.Text))
                CmbStartPeg.Items.Add(TxtbLeftPeg.Text);

            if (!CmbEndPeg.Text.Contains(TxtbMidPeg.Text))
                CmbStartPeg.Items.Add(TxtbMidPeg.Text);

            if (!CmbEndPeg.Text.Contains(TxtbRightPeg.Text))
                CmbStartPeg.Items.Add(TxtbRightPeg.Text);
        }

        private void CmbEndPeg_DropDownOpened(object sender, EventArgs e)
        {
            CmbEndPeg.Items.Clear();
            if (!CmbStartPeg.Text.Contains(TxtbLeftPeg.Text))
                CmbEndPeg.Items.Add(TxtbLeftPeg.Text);

            if (!CmbStartPeg.Text.Contains(TxtbMidPeg.Text))
                CmbEndPeg.Items.Add(TxtbMidPeg.Text);

            if (!CmbStartPeg.Text.Contains(TxtbRightPeg.Text))
                CmbEndPeg.Items.Add(TxtbRightPeg.Text);
        }

        private void CmbStartPeg_DropDownClosed(object sender, EventArgs e)
        {
            if (CmbStartPeg.SelectedItem != null)
            {
                string selectedPeg = CmbStartPeg.SelectedItem.ToString();
                DiskSlider.Value = 0;
                if (selectedPeg == TxtbLeftPeg.Text)
                {
                    StartingPeg = StackPanelLeftPeg;
                    StartingPeg.Name = TxtbLeftPeg.Text;
                }

                if (selectedPeg == TxtbMidPeg.Text)
                {
                    StartingPeg = StackPanelMiddlePeg;
                    StartingPeg.Name = TxtbMidPeg.Text;
                }


                if (selectedPeg == TxtbRightPeg.Text)
                {
                    StartingPeg = StackPanelRightPeg;
                    StartingPeg.Name = TxtbRightPeg.Text;
                }

                AuxiliaryPegIdentifier();
            }
        }

        private void CmbEndPeg_DropDownClosed(object sender, EventArgs e)
        {
            if (CmbEndPeg.SelectedItem != null)
            {
                string selectedPeg = CmbEndPeg.SelectedItem.ToString();
                if (selectedPeg == TxtbLeftPeg.Text)
                {
                    EndingPeg = StackPanelLeftPeg;
                    EndingPeg.Name = TxtbLeftPeg.Text;
                }

                if (selectedPeg == TxtbMidPeg.Text)
                {
                    EndingPeg = StackPanelMiddlePeg;
                    EndingPeg.Name = TxtbMidPeg.Text;
                }


                if (selectedPeg == TxtbRightPeg.Text)
                {
                    EndingPeg = StackPanelRightPeg;
                    EndingPeg.Name = TxtbRightPeg.Text;
                }

                AuxiliaryPegIdentifier();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ResetPegs();
        }

        private void RadioManual_Checked(object sender, RoutedEventArgs e)
        {
            //if (RadioAutomatic.IsChecked == false)
            //    BtnNext.IsEnabled = false;
            //BtnPrevious.IsEnabled = true;
        }

        private async void RadioAutomatic_Checked(object sender, RoutedEventArgs e)
        {
            for(int counter = ListBoxInstructions.Items.Count; counter != 0; counter--)
            {
                await Task.Delay(150);
                //0 < 7
                if (ListBoxInstructionsIndex < ListBoxInstructionsLineNumber - 1)
                {
                    //moves,startpeg,endpeg
                    //3,5,7
                    BtnPrevious.IsEnabled = true;
                    var tmpArray = ListBoxInstructions.Items[ListBoxInstructionsIndex].ToString().Split(' ');

                    StackPanel[] utilizedPegs = { StartingPeg, AuxiliaryPeg, EndingPeg };

                    for (int i = 0; i < 3; i++)
                    {
                        if (tmpArray[5] == utilizedPegs[i].Name)
                        {
                            var tmp = utilizedPegs[i].Children[0];
                            utilizedPegs[i].Children.Remove(tmp);

                            for (int j = 0; j < 3; j++)
                            {
                                if (tmpArray[7] == utilizedPegs[j].Name)
                                    utilizedPegs[j].Children.Insert(0, tmp);
                            }

                            break;
                        }
                    }
                    ListBoxInstructionsIndex++;
                    if (ListBoxInstructionsIndex == ListBoxInstructionsLineNumber - 1)
                    {
                        BtnNext.IsEnabled = false;
                    }

                    //TextBlockExecutedInstruction.Text = ListBoxInstructions.Items[ListBoxInstructions.SelectedIndex].ToString();
                    //if (ListBoxInstructionsIndex < ListBoxInstructions.Items.Count)
                    //    ListBoxInstructions.SelectedIndex = ListBoxInstructionsIndex;
                    //else
                    //    ListBoxInstructions.SelectedIndex = 0;

                    if (ListBoxInstructions.SelectedIndex == ListBoxInstructions.Items.Count - 1)
                    {
                        BtnNext.IsEnabled = false;
                    }

                    if (ListBoxInstructions.SelectedIndex != ListBoxInstructions.Items.Count - 1)
                    {
                        TextBlockExecutedInstruction.Text = ListBoxInstructions.SelectedItem.ToString();
                        ListBoxInstructions.SelectedIndex++;
                    }
                    else
                    {
                        TextBlockExecutedInstruction.Text = ListBoxInstructions.SelectedItem.ToString();
                        ListBoxInstructions.SelectedIndex = -1;
                    }


                    ListBoxInstructions.ScrollIntoView(ListBoxInstructions.SelectedItem);
                }
                else
                {
                    BtnNext.IsEnabled = false;
                }
            }
            
        }

        private void TxtbLeftPeg_TextInput(object sender, TextCompositionEventArgs e)
        {
            CmbStartPeg.Items.Clear();
            CmbEndPeg.Items.Clear();
        }



        private void TxtbLeftPeg_LostFocus(object sender, RoutedEventArgs e)
        {
            CmbStartPeg.SelectedItem = null;
            CmbEndPeg.SelectedItem = null;
            if (TxtbLeftPeg.Text == TxtbMidPeg.Text || TxtbLeftPeg.Text == TxtbRightPeg.Text)
            {
                TxtbLeftPeg.Text = "";
                MessageBox.Show("Error you cannot have duplicate names", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TxtbMidPeg_LostFocus(object sender, RoutedEventArgs e)
        {
            CmbStartPeg.SelectedItem = null;
            CmbEndPeg.SelectedItem = null;
            if (TxtbMidPeg.Text == TxtbLeftPeg.Text || TxtbMidPeg.Text == TxtbRightPeg.Text)
            {
                TxtbMidPeg.Text = "";
                MessageBox.Show("Error you cannot have duplicate names", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TxtbRightPeg_LostFocus(object sender, RoutedEventArgs e)
        {
            CmbStartPeg.SelectedItem = null;
            CmbEndPeg.SelectedItem = null;
            if (TxtbRightPeg.Text == TxtbLeftPeg.Text || TxtbRightPeg.Text == TxtbMidPeg.Text)
            {
                TxtbRightPeg.Text = "";
                MessageBox.Show("Error you cannot have duplicate names", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
