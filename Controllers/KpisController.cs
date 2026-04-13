using Microsoft.AspNetCore.Mvc;
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
    }
}