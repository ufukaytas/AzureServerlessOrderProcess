using System;
using System.Collections.Generic;
using System.Text;

namespace OrderProcess.Function.Dto
{
    public class OrderRequest
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }
    }
}
