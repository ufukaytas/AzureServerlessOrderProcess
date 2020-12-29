using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderProcess.Function.Models
{
    public class Order : TableEntity
    {
        public Order()
        {
            this.RowKey = Guid.NewGuid().ToString("N"); // Unique bir değer olmalı.
        }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int CustomerId { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; } 
        
    }
}
