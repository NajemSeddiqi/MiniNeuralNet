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
        public static string FileName = string.Empty;
        public static string SafeFileName = string.Empty;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {          
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Open Excel File";
            dialog.Filter = "Excel Worksheets | *.xls;*.xlsx;*.csv;*.xlsm";
            Nullable<bool> result = dialog.ShowDialog();

            if (result == true)
            {
                FileName = dialog.FileName;
                SafeFileName = dialog.SafeFileName;
                Debug.WriteLine(FileName);              
                SheetSpecifierWindow sheetSpecifierWindow = new SheetSpecifierWindow();
                sheetSpecifierWindow.Show();              
            }
            else
            {
                return;
            }
            
        }
    }
}
