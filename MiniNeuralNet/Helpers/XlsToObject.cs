using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace MiniNeuralNet.Helpers
{
    public class XlsToObject
    {
        public DataTable Sheet { get; set; }

        private readonly Dictionary<string, List<string>> sheetDataDictionary;


        public XlsToObject()
        {
            sheetDataDictionary = new Dictionary<string, List<string>>();
        }

        public Dictionary<string, List<string>> GetDataDictionary()
        {
            foreach (DataColumn col in Sheet.Columns)
            {
                string key = Sheet.Rows[0][col.ColumnName].ToString();
                sheetDataDictionary.Add(key, PopulateList(col));
            }

            //Remember to remove this
            foreach (KeyValuePair<string, List<string>> k in sheetDataDictionary)
            {
                Debug.WriteLine(string.Format("Key = {0}, Value = {1}", k.Key, k.Value[0]));
            }

            return sheetDataDictionary;
        }

        private List<string> PopulateList(DataColumn col)
        {
            List<string> rowValues = new List<string>();
            for (int i = 1; i < Sheet.Rows.Count; i++)
            {
                string val = Sheet.Rows[i][col.ColumnName].ToString();
                rowValues.Add(val);
            }

            return rowValues;
        }

    }
}