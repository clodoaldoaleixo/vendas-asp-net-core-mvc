using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasMVC.Models;

namespace VendasMVC.Controllers
{
    public class DepartamentosController : Controller
    {
        public IActionResult Index()
        {
            List<Departamento> listaDepartamentos = new List<Departamento>();
            listaDepartamentos.Add(new Departamento { Id = 1, Nome = "Eletrônico" });
            listaDepartamentos.Add(new Departamento { Id = 2, Nome = "Moda" });
            
            return View(listaDepartamentos);
        }
    }
}