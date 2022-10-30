using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staj_r_backend.Models.Entities
{
    public struct Result<T>
    {
        public Result(bool isSuccess, T value)
        {
            this.isSuccess = isSuccess;
            this.value = value;
        }
        public Result(bool isFalse)
        {
            isSuccess = false;
            value = default(T);
        }
        public bool isSuccess { get; set; }
        public T? value { get; set; }
    }
}
