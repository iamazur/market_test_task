using System;
using System.Collections.Generic;
using System.Text;

namespace MarketTest.DAL.Entites
{
    public class ProductEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
    }
}
