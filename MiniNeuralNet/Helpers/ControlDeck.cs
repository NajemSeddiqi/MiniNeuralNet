using MiniNeuralNet.Agents;
using System.Collections.Generic;
using System.Data;

namespace MiniNeuralNet.Helpers
{
    public static class ControlDeck
    {
        public static string FileName = string.Empty;
        public static string SafeFileName = string.Empty;
        public static List<DataTable> Sheets { get; set; }
        public static List<string> SelectedSheetNames { get; set; }
        private static readonly DataFormationAgent Dfa = new DataFormationAgent { Name = "Alpha", Residency = "Container_1" };

        static ControlDeck()
        {
            Sheets = new List<DataTable>();
            SelectedSheetNames = new List<string>();
        }

        public static void InitPlatform()
        {
            Container alphaContainer = new Container { Name = "Container_1" };
            Platform.InitPlatform(alphaContainer, Dfa);
            //first data reception will be null because data is initiated from the user and not an agent
            Dfa.ReceiveData(null);
        }

        public static List<Dictionary<string, List<string>>> PresentData()
        {
            //Do certain changes on the data here before returning
            return Dfa.SelectedSheets();
        }
    }
}