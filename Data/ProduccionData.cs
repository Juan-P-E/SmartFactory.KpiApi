using SmartFactory.KpiApi.Models;

namespace SmartFactory.KpiApi.Data
{
    public static class ProduccionData
    {
        public static List<ProduccionRegistro> ObtenerRegistros()
        {
            return new List<ProduccionRegistro>
            {
                new ProduccionRegistro
                {
                    Id = 1,
                    Fecha = new DateTime(2026, 4, 1),
                    Turno = "Mañana",
                    Linea = "Linea 1",
                    ProduccionReal = 920,
                    ProduccionObjetivo = 1000,
                    DowntimeMinutos = 35,
                    ScrapPorcentaje = 2.5m
                },
                new ProduccionRegistro
                {
                    Id = 2,
                    Fecha = new DateTime(2026, 4, 1),
                    Turno = "Tarde",
                    Linea = "Linea 1",
                    ProduccionReal = 980,
                    ProduccionObjetivo = 1000,
                    DowntimeMinutos = 20,
                    ScrapPorcentaje = 1.8m
                },
                new ProduccionRegistro
                {
                    Id = 3,
                    Fecha = new DateTime(2026, 4, 1),
                    Turno = "Noche",
                    Linea = "Linea 2",
                    ProduccionReal = 870,
                    ProduccionObjetivo = 950,
                    DowntimeMinutos = 40,
                    ScrapPorcentaje = 3.1m
                },
                new ProduccionRegistro
                {
                    Id = 4,
                    Fecha = new DateTime(2026, 4, 2),
                    Turno = "Mañana",
                    Linea = "Linea 2",
                    ProduccionReal = 930,
                    ProduccionObjetivo = 950,
                    DowntimeMinutos = 18,
                    ScrapPorcentaje = 1.6m
                },
                new ProduccionRegistro
                {
                    Id = 5,
                    Fecha = new DateTime(2026, 4, 2),
                    Turno = "Tarde",
                    Linea = "Linea 3",
                    ProduccionReal = 1100,
                    ProduccionObjetivo = 1150,
                    DowntimeMinutos = 22,
                    ScrapPorcentaje = 2.2m
                }
            };
        }
    }
}