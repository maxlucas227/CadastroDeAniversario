using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AT_CadastroDeAniversario.Repository;
using Microsoft.AspNetCore.Mvc;
using AT_CadastroDeAniversario.Models;

namespace AT_CadastroDeAniversario.Controllers
{
    public class PessoasController : Controller
    {
        public PessoasController(PessoaRepository DateBase)
        {
            this.DateBase = DateBase;

        }

        public PessoaRepository DateBase;

        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(string nome, DateTime DataDeAniversario) //aqui vc recebe a data do aniversario, ou quase isso
        {
            Pessoa novaPessoa = new Pessoa();
            novaPessoa.nome = nome;
            novaPessoa.DataDeAniversario = DataDeAniversario;//datetime.now pega a data atual do cadastro
            novaPessoa.Id = Guid.NewGuid();


            DateBase.Salvar(novaPessoa);


            return View();
        }

        public IActionResult Delecao(Guid id)
        {


            DateBase.Excluir(id);
            return RedirectToAction(nameof(Lista));
        }


        public IActionResult Detalhes(Guid id)
        {
            
            var pessoa = DateBase.Buscarid(id);
            return View(pessoa);

        }

        
        public IActionResult Edicao(Guid? id)
        {
            
            
            var pessoa = DateBase.Buscarid(id);
            return View(pessoa);
        }

        [HttpPost]
        public IActionResult Edicao(Guid id, string nome,DateTime DataDeAniversario)
        {

            var pessoa = DateBase.Editar(id, nome, DataDeAniversario);

            return View(pessoa);
            
        }

        [HttpGet]
        public IActionResult Lista(string busca)
        {
            

            List<Pessoa> pessoas = DateBase.BuscarPessoas(busca);


            return View(pessoas);
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            var p = DateBase.AniversarianteDoDia();

            return View(p);
        }

    }
}
