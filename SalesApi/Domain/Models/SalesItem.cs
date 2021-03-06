﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApi.Domain.Models
{
    public class SalesItem
    {
        public int Id { get; set; }
        public int SalesId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public string Name { get; set; }
    }
}
