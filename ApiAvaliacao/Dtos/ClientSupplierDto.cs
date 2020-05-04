using ApiAvaliacao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAvaliacao.Dtos
{
    public class ClientSupplierDto
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int SupplierId { get; set; }
        public String ClientName { get; set; }
        public String SupplierName { get; set; }
        public String ClientCpf { get; set; }
        public String SupplierCnpj { get; set; }
    }
}
