using SmartFactory.KpiApi.Data;
using SmartFactory.KpiApi.Models;
using SmartFactory.KpiApi.DTOs;

namespace SmartFactory.KpiApi.Services
{
    public class KpiService
    {
        public List<ProduccionRegistro> ObtenerProduccion()
        {
            return ProduccionData.ObtenerRegistros();
        }

        public EficienciaDto ObtenerEficiencia()
        {
            var registros = ProduccionData.ObtenerRegistros();

            var totalReal = registros.Sum(r => r.ProduccionReal);
            var totalObjetivo = registros.Sum(r => r.ProduccionObjetivo);

            decimal eficiencia = 0;

            if (totalObjetivo > 0)
            {
                eficiencia = Math.Round((decimal)totalReal / totalObjetivo * 100, 2);
            }

            return new EficienciaDto
            {
                EficienciaPromedio = eficiencia
            };
        }
        public DowntimeDto ObtenerDowntime()
        {
            var registros = ProduccionData.ObtenerRegistros();

            var totalDowntime = registros.Sum(r => r.DowntimeMinutos);
            decimal promedioDowntime = Math.Round((decimal)registros.Average(r => r.DowntimeMinutos), 2);

            return new DowntimeDto
            {
                DowntimeTotalMinutos = totalDowntime,
                DowntimePromedioMinutos = promedioDowntime
            };
        }
    }
}