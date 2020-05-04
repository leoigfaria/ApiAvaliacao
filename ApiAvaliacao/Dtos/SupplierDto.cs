using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAvaliacao.Dtos
{
    public class SupplierDto
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Cnpj { get; set; }
        public String Cep { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
