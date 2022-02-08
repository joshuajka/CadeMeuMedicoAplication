using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadeMeuMedicoAplication.Models
{
    public class Cidade
    {
        [Required(ErrorMessage = "Obrigatório informar o Nome")]
        [StringLength(100, ErrorMessage = "O Nome deve possuir no máximo 100 caracteres")]
        public string Nome { get; set; }
    }
}