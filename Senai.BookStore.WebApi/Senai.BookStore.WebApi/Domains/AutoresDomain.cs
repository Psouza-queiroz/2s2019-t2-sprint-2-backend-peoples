﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.WebApi.Domains
{
    public class AutoresDomain
    {
        public int IdAutores { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Ativo { get; set; }
        public DateTime DataNascimento { get; set; }


    }
}
