using MiniNeuralNet.Helpers;
using System;
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
using System.Windows.Shapes;

namespace MiniNeuralNet
{
    /// <summary>
    /// Interaction logic for SheetSpecifierWindow.xaml
    /// </summary>
    public partial class SheetSpecifierWindow : Window
    {
        private List<string> SheetNames { get; set; }
        public SheetSpecifierWindow()
        {           
            InitializeComponent();
            ControlDeck.InitPlatform();
            InitListView();
        }

        void InitListView()
        {
            SheetWindowFileName.Content = MainWindow.SafeFileName;
            SheetWindowList.ItemsSource = ControlDeck.Sheets;
            SheetNames = new List<string>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ResetListView();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ControlDeck.SelectedSheetNames = SheetNames;
            ControlDeck.PresentData();
            ResetListView();
            this.Close();
        }  

        private void SheetWindowList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var i in e.AddedItems)
            {             
                if (!SheetNames.Contains(i.ToString())) SheetNames.Add(i.ToString());
            }
            foreach(var i in e.RemovedItems)
            {
                if (SheetNames.Contains(i.ToString())) SheetNames.Remove(i.ToString());
            }       
        }
        
        public void ResetListView()
        {
            foreach (var i in ControlDeck.Sheets.ToArray())
            {
                ControlDeck.Sheets.Remove(i);
            }
        }
    }
}
