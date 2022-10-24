using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staj_r_backend.Helper
{
    public class Basic
    {
        public List<string> ConvertToStringList(List<object> list)
        {
            List<string> res = new List<string>();
            foreach(object obj in list)
            {
                res.Add((string)obj);
            }
            return res;
        }
        public List<int> ConvertToIntList(List<object> list)
        {
            List<int> res = new List<int>();
            foreach (object obj in list)
            {
                res.Add((int)obj);
            }
            return res;
        }
    }
}
