using ApiAvaliacao.Data;
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
    public class SupplierController : ControllerBase
    {
        private readonly Context context;

        public SupplierController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> Get()
        {
            return await context.Suppliers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> Get(int id)
        {
            if (id < 1)
                return BadRequest();

            Supplier provider = await context.Suppliers.FindAsync(id);

            if (provider == null)
                return NotFound();

            return provider;
        }

        [HttpPost]
        public async Task<ActionResult<Supplier>> Post(Supplier provider)
        {
            if (provider == null)
                return BadRequest();

            context.Suppliers.Add(provider);
            await context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = provider.Id }, provider);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Supplier provider)
        {
            if (id != provider.Id)
                return BadRequest();

            Supplier providerBd = await context.Suppliers.FindAsync(id);

            if (providerBd == null)
                return NotFound();

            providerBd.Name = provider.Name;
            providerBd.Cnpj = provider.Cnpj;
            providerBd.Cep = provider.Cep;

            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id < 1)
                return BadRequest();

            Supplier provider = await context.Suppliers.FindAsync(id);
            if (provider == null)
                return NotFound();

            context.Suppliers.Remove(provider);
            await context.SaveChangesAsync();

            return Ok("Cliente removido com sucesso");
        }
    }
}
