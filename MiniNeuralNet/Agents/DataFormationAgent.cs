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
        public DataFormationAgent()
        {
            Result = new DataSet();
        }
        
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
            XlsToObject toObject = new XlsToObject { Sheet = Result.Tables[1] };
            string[] testList = new string[10];
            toObject.GetDataDic();                
            //ControlDeck.PassedData = data.ToString();         
        }
    }
}
