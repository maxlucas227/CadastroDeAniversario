using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AT_CadastroDeAniversario.Models;
using Microsoft.EntityFrameworkCore;
using AT_CadastroDeAniversario.Repository;

namespace AT_CadastroDeAniversario.Repository
{
    public class PessoaRepository
    {
        private readonly BancoDeDados DateBase;
        //private static List<Pessoa> Pessoas = new List<Pessoa>();

        public PessoaRepository(BancoDeDados DateBase)
        {
            this.DateBase = DateBase;

        }

        public void Salvar(Pessoa pessoa)
        {
            DateBase.Set<Pessoa>().Add(pessoa);
            DateBase.SaveChanges();
        }

        public List<Pessoa> BuscarPessoas(string busca)
        {
            if (busca != null)
            {
                return DateBase.Set<Pessoa>().Where(Pessoa => Pessoa.nome.ToLower().Contains(busca.ToLower())).ToList();



            }

            return DateBase.Set<Pessoa>().ToList();


        }

        public Pessoa Buscarid(Guid? id)
        {
            if (id == null) return null;


            return DateBase.Set<Pessoa>().First(Pessoa => Pessoa.Id == id);

            // return Pessoas.Find(Pessoa => Pessoa.Id == id);//



        }

        public Pessoa Editar(Guid id, string nome, DateTime DataDeAniversario)
        {
            var db = DateBase.Set<Pessoa>().Find(id);
            db.nome = nome;
            db.DataDeAniversario = DataDeAniversario;
            DateBase.Set<Pessoa>().Update(db);
            DateBase.SaveChanges();


            return db;
            //var p = Buscarid(id);
            //p.nome = nome;
            //p.DataDeAniversario = DataDeAniversario;


            //return p;
        }

        public void Excluir(Guid id)
        {
            var db = DateBase.Set<Pessoa>().Find(id);
            DateBase.Set<Pessoa>().Remove(db);
            DateBase.SaveChanges();




            //    //var p = Buscarid(id);
            //    //Pessoas.Remove(p);
            //}


        }
        public List<Pessoa> AniversarianteDoDia()
        {
            var niverDay = new List<Pessoa>();
            var p = BuscarPessoas(null);
            foreach (var l in p)
            {
                var aniversario = new DateTime(DateTime.Now.Year, l.DataDeAniversario.Month, l.DataDeAniversario.Day);
                TimeSpan intervalo = aniversario - DateTime.Now;
                
                
                    if (intervalo.Days == 0)
                {
                    niverDay.Add(l);
                }
             
            }
            return niverDay;
        }
    }
}
