using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VendasMVC.Models;
using VendasMVC.Services;

namespace VendasMVC.Controllers
{
    public class VendedoresController : Controller
    {
        private VendedorService _servico;

        public VendedoresController(VendedorService servico)
        {
            _servico = servico;
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            _servico.Gravar(vendedor);
            return RedirectToAction("Index");
        }
    }
}
