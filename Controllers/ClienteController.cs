using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PrimeiroEF.Dados;
using PrimeiroEF.Models;

namespace PrimeiroEF.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        Cliente cliente = new Cliente();

        readonly ClienteContexto contexto;

        public ClienteController(ClienteContexto contexto)
        {
            this.contexto = contexto;
        }

        [HttpGet]
        public IEnumerable<Cliente> Listar(){
            return contexto.DbClientes.ToList();
        }

        [HttpGet("{id}")]
        public Cliente Listar(int id){
            return contexto.DbClientes.Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpPost]
        public IActionResult Cadastro([FromBody] Cliente cliente){
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            cliente.DataCadastro = DateTime.Now;
            
            contexto.DbClientes.Add(cliente);
            
            int s = contexto.SaveChanges();

            if(s > 0)
                return Ok();
            else    
                return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] Cliente cliente){
            
            if(cliente == null || cliente.Id != id)
                return BadRequest();
            
            var cli = contexto.DbClientes.FirstOrDefault(x => x.Id == id);

            if(cli == null)
                return NotFound();
            
            cli.Id = cliente.Id;
            cli.Nome = cliente.Nome;
            cli.Email = cliente.Email;
            cli.Idade = cliente.Idade;
            cli.DataCadastro = cliente.DataCadastro;

            contexto.DbClientes.Update(cli);

            int s = contexto.SaveChanges();

            if(s > 0)
                return Ok();
            else
                return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Apagar(int id){
            var cliente = contexto.DbClientes.FirstOrDefault(x => x.Id == id);
            
            if(cliente == null)
                return NotFound();
            
            contexto.DbClientes.Remove(cliente);

            int s = contexto.SaveChanges();

            if(s > 0)
                return Ok();
            else    
                return BadRequest();
        }
    }
}