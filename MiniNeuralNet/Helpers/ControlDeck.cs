using MiniNeuralNet.Agents;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MiniNeuralNet.Helpers
{
    public static class ControlDeck
    {
        public static List<DataTable> Sheets { get; set; }
        public static List<string> SelectedSheetNames { get; set; }
        private static readonly DataFormationAgent Dfa = new DataFormationAgent { Name = "Alpha", Residency = "Container_1" };

        

        static ControlDeck() { Sheets = new List<DataTable>(); SelectedSheetNames = new List<string>(); }
   

        public static void InitPlatform()
        {
            Container alphaContainer = new Container { Name = "Container_1" };          
            Platform.InitPlatform(alphaContainer, Dfa);
            Dfa.ReceiveData(null);
        }

        public static List<Dictionary<string, List<string>>> PresentData()
        {
            List<Dictionary<string, List<string>>> lst = new List<Dictionary<string, List<string>>>();
            lst = Dfa.SelectSheet();
            Debug.WriteLine(lst.Count);
            return null;
        }
     
    }
}
