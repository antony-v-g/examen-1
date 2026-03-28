using Microsoft.AspNetCore.Mvc;
using PortalCampanas.Services;

namespace PortalCampanas.Controllers
{
    public class CampanasController : Controller
    {
        public IActionResult Index(string? categoria, string? estado)
        {
            var campanas = CampanaService.ObtenerCampanas();

            if (!string.IsNullOrEmpty(categoria))
                campanas = campanas.Where(c => c.Categoria == categoria).ToList();

            if (!string.IsNullOrEmpty(estado))
                campanas = campanas.Where(c => c.Estado == estado).ToList();

            return View(campanas);
        }

        public IActionResult Detalle(int id)
        {
            var campana = CampanaService.ObtenerPorId(id);
            if (campana == null) return NotFound();
            return View(campana);
        }

        public IActionResult Resumen()
        {
            var campanas = CampanaService.ObtenerCampanas();
            var resumen = new
            {
                Total = campanas.Count,
                Vigentes = campanas.Count(c => c.Estado == "Vigente"),
                Proximas = campanas.Count(c => c.Estado == "Próxima"),
                PromedioDescuento = campanas.Average(c => c.DescuentoPct),
                CantidadPorCanal = campanas.GroupBy(c => c.Canal)
                                           .ToDictionary(g => g.Key, g => g.Count())
            };
            return View(resumen);
        }
    }
}
