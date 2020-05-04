using ApiAvaliacao.Data;
using ApiAvaliacao.Dtos;
using ApiAvaliacao.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAvaliacao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientSupplierController : ControllerBase
    {
        private readonly Context context;

        public ClientSupplierController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientSupplierDto>>> Get()
        {
            //if (context.ClientSuppliers.FindAsync() == null)
             //   return NotFound();

            return await (from cs in context.ClientSuppliers
                          join c in context.Clients on cs.ClientId equals c.Id
                          join s in context.Suppliers on cs.SupplierId equals s.Id
                          select new ClientSupplierDto
                          {
                              Id = cs.Id,
                              ClientId = cs.ClientId,
                              ClientName = c.Name,
                              ClientCpf = c.Cpf,
                              SupplierId = cs.SupplierId,
                              SupplierName = s.Name,
                              SupplierCnpj = s.Cnpj
                          }).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ClientSupplierDto>>> Get(int id)
        {
            if (id < 1)
                return BadRequest();

            if (await context.ClientSuppliers.FindAsync(id) == null)
                return NotFound();

            return await (from cs in context.ClientSuppliers
                          join c in context.Clients on cs.ClientId equals c.Id
                          join s in context.Suppliers on cs.SupplierId equals s.Id
                         where cs.Id == id
                          select new ClientSupplierDto
                          {
                              Id = cs.Id,
                              ClientId = cs.ClientId,
                              ClientName = c.Name,
                              ClientCpf = c.Cpf,
                              SupplierId = cs.SupplierId,
                              SupplierName = s.Name,
                              SupplierCnpj = s.Cnpj
                          }).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<ClientSupplier>> Post(ClientSupplierDto clientSupplierdto)
        {
            if (clientSupplierdto == null)
                return BadRequest();

            var clientSupplier = new ClientSupplier();
            
            var client = from c in context.Clients
                            where c.Cpf == clientSupplierdto.ClientCpf
                            select new ClientDto
                            {
                                Id = c.Id,
                                Name = c.Name,
                                Cpf = c.Cpf,
                                Cep = c.Cep,
                                CreationDate = c.CreationDate
                            };

            clientSupplier.ClientId = client.First().Id;

            var supplier = from s in context.Suppliers
                         where s.Cnpj == clientSupplierdto.SupplierCnpj
                         select new SupplierDto
                         {
                             Id = s.Id,
                             Name = s.Name,
                             Cnpj = s.Cnpj,
                             Cep = s.Cep,
                             CreationDate = s.CreationDate
                         };

            clientSupplier.SupplierId = supplier.First().Id;

            context.ClientSuppliers.Add(clientSupplier);
            await context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = clientSupplier.Id }, clientSupplier);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id < 1)
                return BadRequest();

            ClientSupplier clientSupplier = await context.ClientSuppliers.FindAsync(id);
            if (clientSupplier == null)
                return NotFound();

            context.ClientSuppliers.Remove(clientSupplier);
            await context.SaveChangesAsync();

            return Ok("Registro removido com sucesso");
        }
    }
}
