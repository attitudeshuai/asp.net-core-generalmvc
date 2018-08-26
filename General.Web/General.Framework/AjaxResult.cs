using System;
using System.Collections.Generic;
using System.Text;

namespace General.Framework
{
    public class AjaxResult 
    {
        public bool status { get; set; }

        public string message { get; set; }

        public int code { get; set; }

        public object data { get; set; }
    }
}
