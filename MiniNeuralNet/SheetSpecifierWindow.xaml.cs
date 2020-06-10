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
            SheetWindowFileName.Content = MainWindow.SafeFileName;
            InitListView();         
        }

        void InitListView()
        {
            SheetWindowList.ItemsSource = ControlDeck.Sheets;
            SheetNames = new List<string>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ControlDeck.SelectedSheetNames = SheetNames;
            ControlDeck.InitPlatform();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SheetNames = (List<string>) e.AddedItems;
        }
    }
}
