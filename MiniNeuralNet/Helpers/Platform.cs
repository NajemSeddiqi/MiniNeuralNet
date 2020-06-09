using MiniNeuralNet.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniNeuralNet.Models;
using System.Diagnostics;

namespace MiniNeuralNet.Helpers
{
    public static class Platform
    {
        static List<Container> ContainerList { get; set; }
              
        public static void InitPlatform(Container firstContainer, Agent firstAgent)
        {
            ContainerList = new List<Container>();
            AddContainer(firstContainer);
            AddAgent(firstAgent);
        }

        public static Boolean AddContainer(Container container)
        {
            container.AgentList = new List<Agent>();
            foreach(Container c in ContainerList)
            {
                if (container.Name.Equals(c.Name)) return false;
                else
                {
                    ContainerList.Add(container);
                }
            }
            return true;
        }

    
        public static Boolean AddAgent(Agent agent)
        {
            foreach(Container c in ContainerList)
            {
                if (agent.Residency.Equals(c.Name))
                {
                    if (c.AgentList.Count == 0)
                    {
                        c.AgentList.Add(agent);
                    }
                    else
                    {
                        foreach (Agent a in c.AgentList.ToArray())
                        {
                            if (a.Name.Equals(agent.Name)) return false;
                            else
                            {
                                c.AgentList.Add(agent);
                            }
                        }
                    }
                }
            }
            return true;
        } 
           
    }
}
