using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AT_CadastroDeAniversario.Models;

namespace AT_CadastroDeAniversario.Repository
{
    public class BancoDeDados : DbContext
    {
        public BancoDeDados(DbContextOptions<BancoDeDados> options):base(options)
        {
                
        }

        public static object Pessoas { get; internal set; }
        public DbSet<Pessoa> pessoas { get; set; }

    }
}
