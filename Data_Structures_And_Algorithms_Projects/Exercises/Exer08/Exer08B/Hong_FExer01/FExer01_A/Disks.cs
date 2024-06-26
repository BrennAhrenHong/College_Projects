using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FExer01_A
{
    public class Disks
    {

        public int DiskCount { get; protected set; }


        public Rectangle[] CreateDisks(int NumberOfDisks)
        {
            DiskCount = 0;
            SolidColorBrush[] diskColors = {Brushes.DarkRed, Brushes.DarkOrange, Brushes.DarkGoldenrod, Brushes.DarkGreen, Brushes.DarkBlue, Brushes.Indigo,
                Brushes.DarkViolet, Brushes.DarkMagenta,Brushes.DarkSlateBlue, Brushes.DarkOliveGreen, Brushes.DarkKhaki, Brushes.DarkSalmon};
            
            Rectangle[] diskArray = new Rectangle[NumberOfDisks];

            for (int i = 0; i < NumberOfDisks; i++)
            {
                Rectangle rectangleDisk = new Rectangle();
                rectangleDisk.Visibility = Visibility.Collapsed;
                rectangleDisk.Fill = diskColors[i];
                rectangleDisk.Stroke = Brushes.Black;
                rectangleDisk.Width = 300 - (25 * i);
                rectangleDisk.Height = 20;
                rectangleDisk.RadiusX = 2;
                rectangleDisk.RadiusY = 2;
                DiskCount++;

                diskArray[i] = rectangleDisk;
            }

            return diskArray;
        }

        /*
         *  <Rectangle Name="TwelfthDisk" Visibility="Collapsed" Fill="DarkSalmon" Stroke="Black" Width="25" Height="20" RadiusX="2" RadiusY="2"></Rectangle>
            <Rectangle Name="EleventhDisk" Visibility="Collapsed" Fill="DarkKhaki" Stroke="Black" Width="50" Height="20" RadiusX="2" RadiusY="2"></Rectangle>
            <Rectangle Name="TenthDisk" Visibility="Collapsed" Fill="DarkOliveGreen" Stroke="Black" Width="75" Height="20" RadiusX="2" RadiusY="2"></Rectangle>
            <Rectangle Name="NinthDisk" Visibility="Collapsed" Fill="DarkSlateBlue" Stroke="Black" Width="100" Height="20" RadiusX="2" RadiusY="2"></Rectangle>
            <Rectangle Name="EighthDisk" Visibility="Collapsed" Fill="DarkMagenta" Stroke="Black" Width="125" Height="20" RadiusX="2" RadiusY="2"></Rectangle>
            <Rectangle Name="SeventhDisk" Visibility="Collapsed" Fill="DarkViolet" Stroke="Black" Width="150" Height="20" RadiusX="2" RadiusY="2"></Rectangle>
            <Rectangle Name="SixthDisk" Visibility="Collapsed" Fill="Indigo" Stroke="Black" Width="175" Height="20" RadiusX="2" RadiusY="2"></Rectangle>
            <Rectangle Name="FifthDisk" Visibility="Collapsed" Fill="DarkBlue" Stroke="Black" Width="200" Height="20" RadiusX="2" RadiusY="2"></Rectangle>
            <Rectangle Name="FourthDisk" Visibility="Collapsed" Fill="DarkGreen" Stroke="Black" Width="225" Height="20" RadiusX="2" RadiusY="2"></Rectangle>
            <Rectangle Name="ThirdDisk" Visibility="Collapsed" Fill="DarkGoldenrod" Stroke="Black" Width="250" Height="20" RadiusX="2" RadiusY="2"></Rectangle>
            <Rectangle Name="SecondDisk" Visibility="Collapsed" Fill="DarkOrange" Stroke="Black" Width="275" Height="20" RadiusX="2" RadiusY="2"></Rectangle>
            <Rectangle Name="FirstDisk" Visibility="Collapsed" Fill="DarkRed" Stroke="Black" Width="300" Height="20" RadiusX="2" RadiusY="2"></Rectangle>
         */

    }
}
