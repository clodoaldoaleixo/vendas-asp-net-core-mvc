using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VendasMVC.Models;
using VendasMVC.Models.ViewModels;
using VendasMVC.Services;
using VendasMVC.Services.Exceptions;

namespace VendasMVC.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedorService _servico;
        private readonly DepartamentoService _departamento;

        public VendedoresController(VendedorService servico, DepartamentoService departamento)
        {
            _servico = servico;
            _departamento = departamento;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var lista = _servico.Listar();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var vm = MontaViewModel(null);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {
                _servico.Gravar(vendedor);
                return RedirectToAction("Index");
            }
            else
            {
                var vm = MontaViewModel(vendedor);
                return View(vm);
            }
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var obj = _servico.Pesquisar(id);

            if (obj == null)
            {
                return RedirectToAction("Error", new { mensagem = "Vendedor não encotrado" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int Id)
        {
            _servico.Deletar(Id);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            var obj = _servico.Pesquisar(id);
            return View(obj);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = _servico.Pesquisar(id);

            if (obj == null)
            {
                return NotFound();
            }

            var vm = MontaViewModel(obj);

            return View(vm);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Vendedor vendedor)
        {
            //Verifica se o modelo está preenchido corretamente, seguindo os data annotations
            if (!ModelState.IsValid)
            {
                var vm = MontaViewModel(vendedor);
                return View(vm);
            }

            if (id != vendedor.Id)
            {
                return Error("Id inválido");
            }

            try
            {
                _servico.Atualizar(vendedor);
                return RedirectToAction("Index");
            }
            catch (NotFoundException)
            {
                return Error("Vendedor não encontrado.");
            }
            catch (DbConcorrenciaException)
            {
                return Error("Existe outro usuário acessando o mesmo registro");
            }
        }

        public IActionResult Error(string mensagem)
        {
            var erro = new ErrorViewModel();
            erro.RequestId = Activity.Current == null ? HttpContext.TraceIdentifier : Activity.Current.Id;
            erro.Mensagem = mensagem;

            return View(erro);
        }

        private VendedorViewModel MontaViewModel(Vendedor vendedor)
        {
            VendedorViewModel vm = new VendedorViewModel();
            vm.Departamentos = _departamento.Listar();
            vm.Vendedor = vendedor;

            return vm;
        }
    }
}
