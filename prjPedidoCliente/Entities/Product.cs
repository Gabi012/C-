using System;
using System.Collections.Generic;
using System.Text;

namespace prjPedidoCliente.Entities
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product()
        {
        }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Name);
            sb.AppendLine(Price.ToString());
            return sb.ToString();

        }
    }
}
