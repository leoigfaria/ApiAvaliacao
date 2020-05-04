using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAvaliacao.Models
{
    public class Client
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Cpf { get; set; }
        public String Cep { get; set; }
        public DateTime? CreationDate { get; set; }
        public List<ClientSupplier> Suppliers { get; set; }

        public Client(int id, String name, String cpf, String cep)
        {
            Id = id;
            Name = name;
            Cpf = cpf;
            Cep = cep;
            CreationDate = DateTime.Now;
        }
    }
}
