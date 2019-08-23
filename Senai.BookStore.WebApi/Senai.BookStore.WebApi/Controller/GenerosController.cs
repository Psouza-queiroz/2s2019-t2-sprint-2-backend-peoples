using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.BookStore.WebApi.Domains;
using Senai.BookStore.WebApi.Repository;

namespace Senai.BookStore.WebApi.Controller
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        GeneroRepository GeneroRepository = new GeneroRepository();

        [HttpGet]
        public IEnumerable<GenerosDomain> Listar()
        {
            return GeneroRepository.Listar();
        }
        public IActionResult Cadastrar(GenerosDomain generos)
        {
            GeneroRepository.Cadastrar(generos);
            return Ok();
        }
    }
}