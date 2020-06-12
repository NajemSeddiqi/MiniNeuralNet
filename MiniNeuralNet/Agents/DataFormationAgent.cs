using MiniNeuralNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniNeuralNet;
using System.IO;
using ExcelDataReader;
using System.Diagnostics;
using System.Data;
using MiniNeuralNet.Helpers;
using System.Dynamic;

namespace MiniNeuralNet.Agents
{
    class DataFormationAgent : Agent
    {
        private DataSet Result;
        public static List<Dictionary<string, List<string>>> PassedData { get; set; }
        public DataFormationAgent()
        {
            Result = new DataSet();
            PassedData = new List<Dictionary<string, List<string>>>();
        }
        
        //TODO: Use conditional operator ? to infer whether the sheet is appropriate for data formation
        public override void ReceiveData(List<object> receivedData)
        {
            using (var stream = File.Open(MainWindow.FileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    do
                    {
                        while (reader.Read())
                        {
                            
                        }
                    } while (reader.NextResult());
                    
                    Result = reader.AsDataSet();
                }
            }        
            SendData(null);
        }

        public override void SendData(List<object> readyData)
        {          
            foreach (DataTable i in Result.Tables)
            {
                ControlDeck.Sheets.Add(i);
            }                                                                       
        }

        public List<Dictionary<string, List<string>>> SelectSheet()      
        {
            List<XlsToObject> toObjectList = new List<XlsToObject>();
            
            for(int i = 0; i < Result.Tables.Count; i++)
            {
                if (ControlDeck.SelectedSheetNames.Contains(Result.Tables[i].TableName))
                {
                    toObjectList.Add(new XlsToObject { Sheet = Result.Tables[i] });
                }
            }

            for (int i = 0; i < toObjectList.Count; i++)
            {
                PassedData.Add(toObjectList[i].GetDataDic());
            }
            return PassedData;
        }
    }
}
