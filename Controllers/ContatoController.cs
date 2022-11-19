using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModuloAPI_Dio.Context;
using ModuloAPI_Dio.Models;

namespace ModuloAPI_Dio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly AppAgendaDbContext _context;
        public ContatoController(AppAgendaDbContext context)
        {
            _context = context;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll() => Ok(await _context.Contatos.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contato = await _context.Contatos.FirstOrDefaultAsync(x => x.Id == id);

             if(contato == null)
                return NotFound();

            return Ok(contato);
        }

        [HttpGet("nome")]
        public async Task<IActionResult> GetByName(string nome)
        {
            var contatos = _context.Contatos.Where(x => x.Nome.Contains(nome));

            if(contatos is null)
                return NoContent();

            return Ok(contatos);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Contato contato)
        {
            if(contato is null)
                return BadRequest();

            await _context.AddAsync(contato);
            await _context.SaveChangesAsync();

            //createdataction retorna a url do local que o contato foi criado.
            //ex: http:localhost:8590/Contato/6
            return CreatedAtAction(nameof(GetById), new {id = contato.Id}, contato);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,Contato contatoModel)
        {
            var contato = await _context.Contatos.FirstOrDefaultAsync(x => x.Id == id);

            if(contato == null)
                return NotFound();

            contato.Nome = contatoModel.Nome;
            contato.Telefone = contatoModel.Telefone;
            contato.Ativo = contatoModel.Ativo;

            _context.Contatos.Update(contato);

            await _context.SaveChangesAsync();

            return Ok(contato);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var contato = await _context.Contatos.FirstOrDefaultAsync(x => x.Id == id);

            if(contato == null)
                return NotFound();
            
            _context.Contatos.Remove(contato);
            await _context.SaveChangesAsync();

            return Ok(contato);
            
        }
    }
}