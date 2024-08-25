using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PC1.Controllers
{
    [Route("[controller]")]
    public class OperacionController : Controller
    {
        private readonly ILogger<OperacionController> _logger;

        public OperacionController(ILogger<OperacionController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }




        [HttpPost]
        public IActionResult Invertir(OperacionModel model)
        {
            const decimal IGV_RATE = 0.18m;

            // Calcular Comisión
            model.Comision = model.MontoAbonar > 300 ? 3 : 1;

            // Calcular IGV
            model.IGV = model.MontoAbonar * IGV_RATE;

            // Calcular Total a Pagar
            model.TotalAPagar = model.MontoAbonar + model.IGV + model.Comision;

            return View("Resultado", model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }



    }

    public class OperacionModel
    {
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public DateTime FechaOperacion { get; set; }
        public List<string> Instrumentos { get; set; }
        public decimal? MontoAbonar { get; set; }
        public decimal? Comision { get; set; }
        public decimal? IGV { get; set; }
        public decimal? TotalAPagar { get; set; }
    }
}