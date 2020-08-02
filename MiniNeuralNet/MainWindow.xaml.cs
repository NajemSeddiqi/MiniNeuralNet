using Microsoft.Win32;
using MiniNeuralNet.Helpers;
using System;
using System.Diagnostics;
using System.Windows;

namespace MiniNeuralNet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Title = "Open Excel File",
                Filter = "Excel Worksheets | *.xls;*.xlsx;*.csv;*.xlsm"
            };
            bool? result = dialog.ShowDialog();

            if (result != true)
            {
                return;
            }
            else
            {
                ControlDeck.FileName = dialog.FileName;
                ControlDeck.SafeFileName = dialog.SafeFileName;
                Debug.WriteLine(ControlDeck.FileName);
                SheetSpecifierWindow sheetSpecifierWindow = new SheetSpecifierWindow();
                sheetSpecifierWindow.Show();
            }

        }
    }
}
