using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIAulas.Data;
using APIAulas.Models;

namespace APIAulas.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {

        private DataContext dc;

        public PessoaController(DataContext context)
        {
            this.dc = context;
        }

        [HttpPost("api")]
        public async Task<ActionResult> Cadastrar([FromBody] Pessoa p)
        {
            dc.pessoa.Add(p);
            await dc.SaveChangesAsync();

            return Created("Objeto pessoa", p);
        }

        [HttpGet("api")]
        public async Task<ActionResult> Listar()
        {
            var dados = await dc.pessoa.ToListAsync();
            return Ok(dados);
        }

        [HttpGet("api/{id}")]
        public Pessoa filtrar(int id)
        {
            Pessoa p = dc.pessoa.Find(id);
            return p;
        }

        [HttpPut("api")]
        public async Task<ActionResult> Editar([FromBody] Pessoa p)
        {
            dc.pessoa.Update(p);
            await dc.SaveChangesAsync();
            return Ok(p);
        }

        [HttpDelete("api/{id}")]
        public async Task<ActionResult> Remover(int id)
        {
            Pessoa p = filtrar(id);

            if(p == null)
            {
                return NotFound();
            }
            else
            {
                dc.pessoa.Remove(p);
                await dc.SaveChangesAsync();
                return Ok(p);
            }
        }

        [HttpGet("oi")]
        public string oi()
        {
            return "Hello World!";
        }
    }
}
