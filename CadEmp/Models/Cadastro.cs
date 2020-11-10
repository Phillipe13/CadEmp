using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadEmp.Models
{
    public class Cadastro
    {
        [Key]
        public int id { get; set; }
        public string cnpj { get; set; }
        public string nome_fantasia { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }

        public DateTime data_do_cadastro;
    }
}