using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using IMCApi.Models;
using IMCApi.Utils;

namespace IMCApi.Controllers
{
    [ApiController]
    [Route("api/imc")]
    public class IMCController : ControllerBase
    {
        private readonly DataContext _context;

        public IMCController(DataContext context) => _context = context;

        //GET: /api/imc/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            return Ok(_context.IMCs.AsNoTracking().Include(l => l.Usuario).Select(b => new
            {
                Id = b.Id,
                Nome = b.Usuario.Nome,
                Nascimento = b.Usuario.Nascimento,
                Peso = b.Peso,
                Altura = b.Altura,
                ImcUsuario = b.ImcUsuario,
                Classificacao = b.Classificacao,
                UsuarioId = b.UsuarioId,
                Usuario = b.Usuario,
                DataCriacao = b.DataCriacao,
                classificacaoFormatada = b.ClassificacaoFormatada
            }));

        }

        //GET: /api/imc/buscar/{id}
        [HttpGet]
        [Route("listar/{id:int}")]
        public IActionResult BuscarPorId([FromRoute] int id)
        {
            var imc = _context.IMCs.FirstOrDefault(imcCadastrado => imcCadastrado.Id.Equals(id));
            if (imc == null) return NotFound("IMC não cadastrado no sistema!");

            return Ok(imc);
        }

        // POST: /api/imc/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] IMC imc)
        {

            imc.ImcUsuario = Calculo.CalcularIMC(imc.Peso, imc.Altura);
            imc.Classificacao = Calculo.ClassificaIMC(imc.ImcUsuario);
            imc.ClassificacaoFormatada = ConverteIMC.Converter(imc.Classificacao);
            _context.IMCs.Add(imc);
            _context.SaveChanges();
            return Created("", imc);
        }

        //Patch: /api/imc/editar/1
        [HttpPatch]
        [Route("editar/{id}")]
        public IActionResult Editar([FromRoute] int id, [FromBody] IMC imc)
        {
            var customer = _context.IMCs.AsNoTracking().FirstOrDefault(imcCadastrado => imcCadastrado.Id == id);
            if (customer == null) return BadRequest("Imc não encontrado!");

            _context.IMCs.Update(imc);
            _context.SaveChanges();
            return Ok(imc);
        }
    }
}
