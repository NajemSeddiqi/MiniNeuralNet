using MiniNeuralNet.Agents;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MiniNeuralNet.Helpers
{
    public static class ControlDeck
    {
        public static Dictionary<string, List<string>> PassedData { get; set; }
        public static List<DataTable> Sheets { get; set; }

        public static List<string> SelectedSheetNames { get; set; }

        

        static ControlDeck() { Sheets = new List<DataTable>(); SelectedSheetNames = new List<string>(); }
   

        public static void InitPlatform()
        {
            Container alphaContainer = new Container { Name = "Container_1" };          
            DataFormationAgent dfa = new DataFormationAgent { Name = "Victor", Residency = "Container_1" };
            Platform.InitPlatform(alphaContainer, dfa);
            dfa.ReceiveData(null);
        }

        public static Dictionary<string, List<string>> PresentData()
        {
            
            return PassedData;
        }
     
    }
}
