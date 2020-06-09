using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniNeuralNet.Models
{
    public abstract class Agent
    {
        public string Name { get; set; }
        public string Residency { get; set; }
        public abstract void SendData(List<object> readyData);
        public abstract void ReceiveData(List<object> receivedData);
    }
}
