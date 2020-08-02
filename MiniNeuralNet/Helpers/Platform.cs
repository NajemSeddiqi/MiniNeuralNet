using MiniNeuralNet.Models;
using System;
using System.Collections.Generic;

namespace MiniNeuralNet.Helpers
{
    public static class Platform
    {
        private static List<Container> ContainerList { get; set; }

        public static void InitPlatform(Container firstContainer, Agent firstAgent)
        {
            ContainerList = new List<Container>();
            AddContainer(firstContainer);
            AddAgent(firstAgent);
        }

        public static bool AddContainer(Container container)
        {
            container.AgentList = new List<Agent>();
            foreach (var c in ContainerList)
            {
                if (container.Name.Equals(c.Name)) return false;
                else
                {
                    ContainerList.Add(container);
                }
            }
            return true;
        }

        public static bool AddAgent(Agent agent)
        {
            foreach (var c in ContainerList)
            {
                if (agent.Residency.Equals(c.Name))
                {
                    if (c.AgentList.Count == 0)
                    {
                        c.AgentList.Add(agent);
                    }
                    else
                    {
                        foreach (var a in c.AgentList.ToArray())
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