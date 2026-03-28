using PortalCampanas.Models;

namespace PortalCampanas.Services
{
    public static class CampanaService
    {
        private static List<Campaña> campanas = new List<Campaña>
        {
            new Campaña { Id = 1, Nombre = "Campaña Verano", Categoria = "Ropa", Estado = "Vigente", FechaInicio = DateTime.Now.AddDays(-10), FechaFin = DateTime.Now.AddDays(20), Canal = "Online", DescuentoPct = 15, Descripcion = "Promoción de temporada verano." },
            new Campaña { Id = 2, Nombre = "Campaña Escolar", Categoria = "Útiles", Estado = "Próxima", FechaInicio = DateTime.Now.AddDays(5), FechaFin = DateTime.Now.AddDays(30), Canal = "Tiendas", DescuentoPct = 10, Descripcion = "Descuentos en útiles escolares." }
        };

        public static List<Campaña> ObtenerCampanas() => campanas;
        public static Campaña? ObtenerPorId(int id) => campanas.FirstOrDefault(c => c.Id == id);
    }
}
