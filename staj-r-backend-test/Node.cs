using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staj_r_backend_test
{
    public class Node
    {
        public long Id { get; set; }
        public string ElementId { get; set; }
        public List<string> Labels { get; set; }
        public IDictionary<string,object> Properties { get; set; }
    }
}
