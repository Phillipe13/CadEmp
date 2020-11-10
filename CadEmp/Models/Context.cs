using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CadEmp.Models
{
    public class Context : DbContext
    {
        public DbSet <Cadastro> Cadastros { get; set; }
    }
}