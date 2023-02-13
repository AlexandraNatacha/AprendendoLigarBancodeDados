using AprendendoLigarBancodeDados.Contexto;
using AprendendoLigarBancodeDados.Models.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AprendendoLigarBancodeDados.Controllers
{
    public class PessoaController : Controller
    {
        private readonly DbContextOptions<BancoDeDados> DbContextOptions;

        public PessoaController(DbContextOptions<BancoDeDados> dbContextOptions)
        {
            DbContextOptions = dbContextOptions;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Pessoa pessoa)
        {
            using (var contexto = new BancoDeDados(DbContextOptions))
            {
                contexto.Add(pessoa);
                contexto.SaveChanges();
            }

            return View("Index");
        }

        [HttpGet]
        public IActionResult Listar()
        {
            var listaDePessoas = new List<Pessoa>();
            using (var contexto = new BancoDeDados(DbContextOptions))
            {
                listaDePessoas = contexto.Pessoa.ToList();
            }

            return View(listaDePessoas);
        }
        public IActionResult Deletar(int Id)
        {
            using (var contexto = new BancoDeDados(DbContextOptions))
            {
                var deletarPessoa = contexto.Pessoa.First(x => x.Id == Id);
                contexto.Remove(deletarPessoa);
                contexto.SaveChanges();
            }

            return RedirectToAction("Listar");
        }
       
    }
}
