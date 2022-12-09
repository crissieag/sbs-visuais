using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using IMCApi.Models;

namespace IMCApi.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _context;

        public UsuariosController(DataContext context) => _context = context;

        //GET: /api/usuarios/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            return Ok(_context.Usuarios.ToList());
        }

        //GET: /api/usuarios/buscar/{id}
        [HttpGet]
        [Route("listar/{id:int}")]
        public IActionResult BuscarPorId([FromRoute] int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(usuarioCadastrado => usuarioCadastrado.Id.Equals(id));
            if (usuario == null) return NotFound("Usuario não cadastrado no sistema!");

            return Ok(usuario);
        }

        // POST: /api/usuarios/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return Created("", usuario);
        }

        //Delete: /api/usuarios/deletar/{id}
        [HttpDelete]
        [Route("deletar/{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            Usuario usuario = _context.Usuarios.FirstOrDefault(usuarioCadastrado => usuarioCadastrado.Id.Equals(id));

            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
                return Ok();
            }

            return NotFound("Usuario não cadastrado no sistema!");
        }

        //Patch: /api/usuarios/editar/1
        [HttpPatch]
        [Route("editar/{id}")]
        public IActionResult Editar([FromRoute] int id, [FromBody] Usuario usuario)
        {
            var customer = _context.Usuarios.AsNoTracking().FirstOrDefault(usuarioCadastrado => usuarioCadastrado.Id == id);
            if (customer == null) return BadRequest("Usuario não encontrado!");

            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
            return Ok(usuario);
        }
    }
}
