# SmartFactory KPI API

Proyecto en C# (.NET / ASP.NET Core) orientado a simular un backend de métricas industriales.

La idea es representar un escenario real de planta, donde se calculan indicadores clave de producción y se exponen mediante una API para su consumo en dashboards.

## Qué hace

A partir de datos simulados de producción, la API calcula:

- Producción total
- Eficiencia
- Downtime (total y promedio)
- OEE (Overall Equipment Effectiveness)
- OEE por turno
- Scrap promedio
- Resumen general de KPIs

## Endpoints disponibles

- GET /api/kpis/produccion  
- GET /api/kpis/eficiencia  
- GET /api/kpis/downtime  
- GET /api/kpis/oee  
- GET /api/kpis/oee-por-turno  
- GET /api/kpis/scrap  
- GET /api/kpis/resumen  

También se puede filtrar por línea en:

- GET /api/kpis/oee-por-turno?linea=Linea 1

## Ejemplo de respuesta

```json
{
  "oee": 69.39,
  "eficiencia": 95.05,
  "downtimePromedio": 27,
  "scrapPromedio": 2.24
}
Tecnologías usadas
C#
ASP.NET Core Web API
LINQ
Swagger (OpenAPI)

Próximo paso

Conectar esta API con Power BI para visualizar los datos en un dashboard.