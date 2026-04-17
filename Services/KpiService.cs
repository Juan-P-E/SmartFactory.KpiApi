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
        public OeeDto ObtenerOee()
        {
            var eficiencia = ObtenerEficiencia().EficienciaPromedio;
            var downtime = ObtenerDowntime().DowntimePromedioMinutos;

            decimal disponibilidad = 100 - downtime;

            decimal oee = Math.Round((eficiencia * disponibilidad) / 100, 2);

            return new OeeDto
            {
                OeePorcentaje = oee
            };
        }
        public List<OeePorTurnoDto> ObtenerOeePorTurno()
        {
            var registros = ProduccionData.ObtenerRegistros();

            var resultado = registros
                .GroupBy(r => r.Turno)
                .Select(g =>
                {
                    var totalReal = g.Sum(x => x.ProduccionReal);
                    var totalObjetivo = g.Sum(x => x.ProduccionObjetivo);
                    var downtimePromedio = g.Average(x => x.DowntimeMinutos);

                    decimal eficiencia = 0;
                    if (totalObjetivo > 0)
                    {
                        eficiencia = (decimal)totalReal / totalObjetivo * 100;
                    }

                    decimal disponibilidad = 100 - (decimal)downtimePromedio;

                    decimal oee = Math.Round((eficiencia * disponibilidad) / 100, 2);

                    return new OeePorTurnoDto
                    {
                        Turno = g.Key,
                        OeePorcentaje = oee
                    };
                })
                .ToList();

            return resultado;
        }
        public ScrapDto ObtenerScrapPromedio()
        {
            var registros = ProduccionData.ObtenerRegistros();

            var promedio = registros.Average(r => r.ScrapPorcentaje);

            return new ScrapDto
            {
                ScrapPromedio = promedio
            };
        }
        public ResumenKpiDto ObtenerResumen()
        {
            var oee = ObtenerOee();
            var eficiencia = ObtenerEficiencia();
            var downtime = ObtenerDowntime();
            var scrap = ObtenerScrapPromedio();

            return new ResumenKpiDto
            {
                Oee = oee.OeePorcentaje,
                Eficiencia = eficiencia.EficienciaPromedio,
                DowntimePromedio = downtime.DowntimePromedioMinutos,
                ScrapPromedio = scrap.ScrapPromedio
            };
        }
    }
}