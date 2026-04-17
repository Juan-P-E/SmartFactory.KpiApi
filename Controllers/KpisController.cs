using Microsoft.AspNetCore.Mvc;
using SmartFactory.KpiApi.DTOs;
using SmartFactory.KpiApi.Services;

namespace SmartFactory.KpiApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KpisController : ControllerBase
    {
        private readonly KpiService _kpiService;

        public KpisController(KpiService kpiService)
        {
            _kpiService = kpiService;
        }

        [HttpGet("produccion")]
        public IActionResult ObtenerProduccion()
        {
            var registros = _kpiService.ObtenerProduccion();
            return Ok(registros);
        }

        [HttpGet("eficiencia")]
        public IActionResult ObtenerEficiencia()
        {
            var eficiencia = _kpiService.ObtenerEficiencia();
            return Ok(eficiencia);
        }
        [HttpGet("downtime")]
        public IActionResult ObtenerDowntime()
        {
            var downtime = _kpiService.ObtenerDowntime();
            return Ok(downtime);
        }
        [HttpGet("oee")]
        public IActionResult ObtenerOee()
        {
            var oee = _kpiService.ObtenerOee();
            return Ok(oee);
        }
        [HttpGet("oee-por-turno")]
        public IActionResult ObtenerOeePorTurno()
        {
            var resultado = _kpiService.ObtenerOeePorTurno();
            return Ok(resultado);
        }
        [HttpGet("scrap")]
        public ActionResult<ScrapDto> ObtenerScrap()
        {
            var resultado = _kpiService.ObtenerScrapPromedio();
            return Ok(resultado);
        }
        [HttpGet("resumen")]
        public IActionResult ObtenerResumen()
        {
            var resultado = _kpiService.ObtenerResumen();
            return Ok(resultado);
        }
    }
}