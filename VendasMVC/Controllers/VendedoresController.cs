﻿using System;
using System.Collections.Generic;
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
            VendedorViewModel vm = new VendedorViewModel();
            vm.Departamentos = CarregaDepartamentos();

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            _servico.Gravar(vendedor);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var obj = _servico.Pesquisar(id);

            if (obj == null)
            {
                return NotFound();
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

            VendedorViewModel vm = new VendedorViewModel();
            vm.Departamentos = CarregaDepartamentos();
            vm.Vendedor = obj;

            return View(vm);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Vendedor vendedor)
        {
            if (id != vendedor.Id)
            {
                return BadRequest();
            }

            try
            {
                _servico.Atualizar(vendedor);
                return RedirectToAction("Index");
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcorrenciaException)
            {
                return NotFound();
            }
        }

        private List<Departamento> CarregaDepartamentos()
        {
            return _departamento.Listar();
        }
    }
}
