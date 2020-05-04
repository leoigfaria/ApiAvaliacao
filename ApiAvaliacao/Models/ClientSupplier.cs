﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAvaliacao.Models
{
    public class ClientSupplier
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
