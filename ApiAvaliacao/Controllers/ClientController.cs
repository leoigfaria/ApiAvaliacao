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
    public class ClientController : ControllerBase
    {
        private readonly Context context;

        public ClientController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> Get()
        {
            return await context.Clients.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> Get(int id)
        {
            if (id < 1)
                return BadRequest();

            Client client = await context.Clients.FindAsync(id);

            if (client == null)
                return NotFound();

            return client;
        }

        [HttpPost]
        public async Task<ActionResult<Client>> Post(Client client)
        {
            if (client == null)
                return BadRequest();

            context.Clients.Add(client);
            await context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = client.Id }, client);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Client client)
        {
            if (id != client.Id)
                return BadRequest();

            Client clientBd = await context.Clients.FindAsync(id);

            if (clientBd == null)
                return NotFound();

            clientBd.Name = client.Name;
            clientBd.Cpf = client.Cpf;
            clientBd.Cep = client.Cep;

            await context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id < 1)
                return BadRequest();

            Client client = await context.Clients.FindAsync(id);
            if (client == null)
                return NotFound();

            context.Clients.Remove(client);
            await context.SaveChangesAsync();

            return Ok("Cliente removido com sucesso");
        }
    }
}
