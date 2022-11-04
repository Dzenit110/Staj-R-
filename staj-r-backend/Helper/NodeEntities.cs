using System;
using System.Collections.Generic;

namespace staj_r_backend.Helper
{
    public class NodeEntities
    {
        public NodeEntities(Neo4j.Driver.INode node)
        {
            this.Id = Convert.ToInt64(node.ElementId);
            Labels = new List<string>();
            foreach (var j in node.Labels)
            {
                Labels.Add(j);
            }
            Properties = new Dictionary<string, object>();
            foreach (var i in node.Properties)
            {
                Properties.Add(i.Key, i.Value);
            }
        }
        public NodeEntities() { }
        public long Id { get; set; }
        public List<string> Labels { get; set; }
        public IDictionary<string, object> Properties { get; set; }
    }
}
