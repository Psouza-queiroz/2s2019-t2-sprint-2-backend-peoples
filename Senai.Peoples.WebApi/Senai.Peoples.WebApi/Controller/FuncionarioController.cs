using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Repository;

namespace Senai.Peoples.WebApi.Controller
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        FuncionarioRepository FunciarioRepository = new FuncionarioRepository();



        [HttpGet]
        public IEnumerable<FuncionarioDomain> ListarTodos()
        {
            return FunciarioRepository.Listar();
        }

        [HttpGet ("{Id}")]

        public IActionResult BuscarPorId(int Id)
        {
            FuncionarioDomain funcionarioDomain = FunciarioRepository.BuscarPorId(Id);
            if (funcionarioDomain == null)
                return NotFound();
            return Ok(funcionarioDomain);
        }

//        [HttpGet ("{Nome}")]
//       public IActionResult BuscarPorNome(string Nome)
//        {
//            FuncionarioDomain funcionarioDomain = FunciarioRepository.BuscarPorNome(Nome);
//            if (funcionarioDomain == null)
//                return NotFound();
//            return Ok(funcionarioDomain);
//        }

        [HttpPost]
        public IActionResult Cadastrar(FuncionarioDomain funcionarioDomain)
        {
            FunciarioRepository.Cadastrar(funcionarioDomain);
            return Ok();
        }

        public IActionResult Atualizar(FuncionarioDomain funcionarioDomain)
        {
            FunciarioRepository.Atualizar(funcionarioDomain);
                return Ok();
        }
        [HttpDelete("{Id}")]
        public IActionResult Deletar (int Id)
        {
            FunciarioRepository.Deletar(Id);
            return Ok();
        }
    }
}