using MiniNeuralNet.Agents;
using System;
using System.Collections.Generic;
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
   

        public static void InitPlatform()
        {
            Container alphaContainer = new Container { Name = "Container_1" };          
            DataFormationAgent dfa = new DataFormationAgent { Name = "Victor", Residency = "Container_1" };
            Platform.InitPlatform(alphaContainer, dfa);
            dfa.ReceiveData(null);
        }

        public static Dictionary<string, List<string>> PresentData()
        {
            foreach(var i in PassedData)
            {
                
            }
            return PassedData;
        }
     
    }
}
