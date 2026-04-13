namespace SmartFactory.KpiApi.Models
{
    public class ProduccionRegistro
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Turno { get; set; } = string.Empty;
        public string Linea { get; set; } = string.Empty;
        public int ProduccionReal { get; set; }
        public int ProduccionObjetivo { get; set; }
        public int DowntimeMinutos { get; set; }
        public decimal ScrapPorcentaje { get; set; }
    }
}