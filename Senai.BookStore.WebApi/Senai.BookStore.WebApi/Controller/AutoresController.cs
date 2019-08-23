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
    public class AutoresController : ControllerBase
    {
        AutoresRepository autoresRepository = new AutoresRepository();

        [HttpGet]
        public IEnumerable<AutoresDomain> Listar()
        {
            return autoresRepository.Listar();
        }

        [HttpPost]
        public IActionResult Cadastrar (AutoresDomain autoresDomain)
        {
            autoresRepository.Cadastrar(autoresDomain);
            return Ok();
        }
    }
}