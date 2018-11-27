using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasMVC.Services;

namespace VendasMVC.Controllers
{
    public class VendasController : Controller
    {
        private readonly VendasService _vendasService;

        public VendasController(VendasService vendasService)
        {
            _vendasService = vendasService;
        }

        public IActionResult Index()
        {
            return View();
        } 
        
        public async Task<IActionResult> BuscaSimples(DateTime? dtInicial, DateTime? dtFinal)
        {
            ViewData["dtInicial"] = dtInicial.Value.ToString("dd/MM/yyyy");
            ViewData["dtFinal"] = dtFinal.Value.ToString("dd/MM/yyyy");

            var retorno =  await _vendasService.ListarPorDataAsync(dtInicial, dtFinal);
            return View(retorno);
        }

        public async Task<IActionResult> BuscaGrupo(DateTime? dtInicial, DateTime? dtFinal)
        {
            ViewData["dtInicial"] = dtInicial.Value.ToString("dd/MM/yyyy");
            ViewData["dtFinal"] = dtFinal.Value.ToString("dd/MM/yyyy");

            var retorno = await _vendasService.ListarAgrupadoPorDataAsync(dtInicial, dtFinal);
            return View(retorno);
        }
        
    }
}