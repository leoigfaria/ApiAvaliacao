using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAvaliacao.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Cnpj { get; set; }
        public String Cep { get; set; }
        public DateTime? CreationDate { get; set; }
        public List<ClientSupplier> Clients { get; set; }

        public Supplier(int id, String name, String cnpj, String cep)
        {
            Id = id;
            Name = name;
            Cnpj = cnpj;
            Cep = cep;
            CreationDate = DateTime.Now;
        }
    }
}
