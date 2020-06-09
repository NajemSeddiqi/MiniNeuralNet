using MiniNeuralNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniNeuralNet.Helpers
{
    public class Container
    {
        public string Name { get; set; }
        public List<Agent> AgentList { get; set; }

        public Container()
        {

        }
    }
}
