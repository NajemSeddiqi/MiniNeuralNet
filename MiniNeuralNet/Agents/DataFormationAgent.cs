using ExcelDataReader;
using MiniNeuralNet.Helpers;
using MiniNeuralNet.Models;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace MiniNeuralNet.Agents
{
    internal class DataFormationAgent : Agent
    {
        private DataSet Result;
        public static List<Dictionary<string, List<string>>> PassedData { get; set; }

        public DataFormationAgent()
        {
            Result = new DataSet();
            PassedData = new List<Dictionary<string, List<string>>>();
        }

        //TODO: infer whether the sheet is appropriate for data formation
        public override void ReceiveData(List<object> receivedData)
        {
            using (var stream = File.Open(ControlDeck.FileName, FileMode.Open, FileAccess.Read))
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
            foreach (var i in Result.Tables)
            {
                ControlDeck.Sheets.Add((DataTable)i);
            }
        }

        public List<Dictionary<string, List<string>>> SelectedSheets()
        {
            List<XlsToObject> toObjectList = new List<XlsToObject>();

            for (int i = 0; i < Result.Tables.Count; i++)
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