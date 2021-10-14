using System;
using System.Collections.Generic;
using System.Text;

namespace prjPedidoCliente.Entities
{
    class Client
    {
        public string Name { get; set; }
        public string Email{ get; set; }
        public DateTime  BirthDate { get; set; }

        public Client()
        {
        }

        public Client(string name, string email, DateTime bithDate)
        {
            Name = name;
            Email = email;
            BirthDate = bithDate;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Name);
            sb.AppendLine(Email);
            sb.AppendLine(BirthDate.ToString("dd/MM/yyyy"));
            return sb.ToString();
        }
    }
}
