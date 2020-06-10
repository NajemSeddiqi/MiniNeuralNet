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
            List<XlsToObject> toObjectList = new List<XlsToObject>();
            //foreach (DataTable i in Result.Tables)
            //{
            //    ControlDeck.Sheets.Add(i);
                
            //}

             for(int i = 0; i < Result.Tables.Count; i++)
            {
                ControlDeck.Sheets.Add(Result.Tables[i]);
                if (!ControlDeck.SelectedSheetNames.Contains(Result.Tables[i].TableName)) return;
                toObjectList.Add(new XlsToObject  { Sheet = (DataTable) from sheet in ControlDeck.SelectedSheetNames where sheet.Equals(Result.Tables[i].TableName) select Result.Tables[i]});
            }

             for(int i = 0; i < toObjectList.Count; i++)
            {
                ControlDeck.PassedData = toObjectList[i].GetDataDic();
            }                                      
                      
        }
    }
}
