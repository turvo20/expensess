using System;
using System.Collections.Generic;
using System.Text;

namespace expensess.MODEL
{
    public class GeneralResponse
    {
        public Boolean ok { get; set; }
        public int status { get; set; }
        public object data { get; set; }
    }
}
