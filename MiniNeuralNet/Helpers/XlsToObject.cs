using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace MiniNeuralNet.Helpers
{
    public class XlsToObject
    {
        public DataTable Sheet { get; set; }
        private string Data { get; set; }

        private Dictionary<string, List<string>> MyDic;

        private List<string> lst;

        public XlsToObject()
        {
            MyDic = new Dictionary<string, List<string>>();
        }

        private List<string> PopulateList(List<string> list, string colName, DataColumn col)
        {

            for (int i = 1; i < Sheet.Rows.Count; i++)
            {
                string val = Sheet.Rows[i][col.ColumnName].ToString();
                list.Add(val);
            }

            return list;
        }


        public Dictionary<string, List<string>> GetDataDic()
        {

            foreach (DataColumn col in Sheet.Columns)
            {
                string key = Sheet.Rows[0][col.ColumnName].ToString();
                lst = new List<string>();
                MyDic.Add(key, PopulateList(lst, key, col));
            }


            foreach (KeyValuePair<string, List<string>> k in MyDic)
            {
                Debug.WriteLine(string.Format("Key = {0}, Value = {1}", k.Key, k.Value[5]));
            }

            return MyDic;
        }
    }
}
