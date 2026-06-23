# ISO9001.WebAPI (Demo)

Host de demostración del paquete **ISO9001.Core**. Es una Minimal API que expone todos los
casos de uso de la librería sobre una **base de datos en memoria** (`ISO9001.Database.InMemory`),
sin SQL ni configuración externa. Sirve para probar la librería de extremo a extremo antes de
publicar el NuGet.

> Este proyecto referencia los **proyectos** `ISO9001.WebAPI.Mappers` y `ISO9001.Database.InMemory`
> (no el paquete NuGet), así que cualquier cambio en `ISO9001.Core` se ve aquí al recompilar.

## Cómo ejecutar

```bash
cd Src/Demo/ISO9001.WebAPI
dotnet run --launch-profile http      # http://localhost:5058
# o
dotnet run --launch-profile https     # https://localhost:7131 (+ http://localhost:5058)
```

- Perfiles en `Properties/launchSettings.json`. El entorno es `Development`.
- Al arrancar con el perfil `https` se abre el navegador en la UI de documentación.

## Cómo probar

Hay tres vías, en orden de comodidad:

1. **UI de documentación / testing** — [`/docs/api`](http://localhost:5058/docs/api)
   (WebApiDocumentator). En compilación **DEBUG** el panel de testing está habilitado
   (`EnableTesting = true` en `Program.cs`), así que puedes lanzar peticiones desde el navegador.
2. **OpenAPI** — el documento se sirve en [`/openapi/v1.json`](http://localhost:5058/openapi/v1.json)
   (`AddOpenApi` / `MapOpenApi`). Útil para importarlo en Postman, Insomnia o un Swagger UI externo.
3. **curl / cliente HTTP** — ejemplos más abajo.

> **Importante:** la base de datos es en memoria y el almacén es **singleton**: los datos sembrados
> con los `POST` persisten mientras la app esté en marcha y **se borran al reiniciar**. Para probar
> cualquier consulta primero hay que registrar datos con su `POST`.

### Cómo se forman las rutas

Las rutas las genera `CreateEndpoint(...)` (en `ISO9001.WebAPI.Mappers/Helpers/EndpointHelper.cs`):
quita el sufijo `Endpoints` del grupo y pasa cada segmento PascalCase a **kebab-case**
(los `{parametros}` de ruta se respetan). Por eso `CustomerFeedbackEndpoints` + `"{companyId}/Analyze/"`
resulta en `customer-feedback/{companyId}/analyze`.

Para **añadir endpoints de prueba**, sigue el patrón `builder.Map...` dentro del mapper del módulo
correspondiente en `ISO9001.WebAPI.Mappers` (así aparecen automáticamente en OpenAPI y en `/docs/api`).

---

## Catálogo de endpoints

Parámetros de query habituales: `from` y `end` (rango de fechas, opcionales; por defecto las
consultas usan los **últimos 30 días**).

> Las consultas de lista devuelven el `Id` de cada registro (en todos los módulos: `Id`, o `LogId`
> en Audit Log), que es el que necesitas para los endpoints `/id/{id}` y `/master-id/{masterId}`.

### Customer Feedback (`customer-feedback`)
| Método | Ruta | Descripción |
|---|---|---|
| POST | `/customer-feedback` | Registra feedback (body `CustomerFeedbackRequest`). Rating 1-5. |
| GET | `/customer-feedback/{companyId}` | Todo el feedback de la empresa (`?from&end`). |
| GET | `/customer-feedback/{companyId}/id/{id}` | Feedback por id. |
| GET | `/customer-feedback/{companyId}/entity/{entityId}` | Feedback de una entidad/pedido (`?from&end`). |
| GET | `/customer-feedback/{companyId}/customer/{customerId}` | Feedback de un cliente (`?from&end`). |
| GET | `/customer-feedback/{companyId}/rating/{rating}` | Feedback con un rating concreto (`?from&end`). |
| **GET** | **`/customer-feedback/{companyId}/analyze`** | **★ Análisis de satisfacción** (`?entityId&from&end`). Devuelve `AnalyzeFeedbackResponse`. |
| GET | `/customer-feedback/{companyId}/entity/{entityId}/report` | Informe PDF (`ReportViewModel`). |

### Audit Log (`audit-log`)
| Método | Ruta |
|---|---|
| POST | `/audit-log` (body `AuditLogRequest`) |
| GET | `/audit-log/{companyId}` · `/.../entity/{entityId}` · `/.../action/{action}` · `/.../id/{id}` · `/.../entity/{entityId}/report` |

### Incident Report (`incident-report`)
| Método | Ruta |
|---|---|
| POST | `/incident-report` (body `IncidentReportRequest`) |
| GET | `/incident-report/{companyId}` · `/.../entity/{entityId}` · `/.../id/{id}` · `/.../entity/{entityId}/report` |

### Non Conformity (`non-conformity`)
| Método | Ruta |
|---|---|
| POST | `/non-conformity` (body `NonConformityRequest`) · `/non-conformity/{companyId}/detail` (body `NonConformityCreateDetailRequest`) |
| GET | `/non-conformity/{companyId}` · `/.../entity/{entityId}` · `/.../status/{status}` · `/.../affected-process/{affectedProcess}` · `/.../entity/{entityId}/report` · `/.../master-id/{masterId}/report` |

### Audit Event (`audit-event`)
| Método | Ruta | Descripción |
|---|---|---|
| GET | `/audit-event/{companyId}?entityId=...` | Timeline unificado de una entidad (logs, feedback, incidencias, no conformidades). |

### Quality Dashboard (`dash-board`)
| Método | Ruta | Descripción |
|---|---|---|
| GET | `/dash-board/{companyId}/dashboard?from&end` | KPIs agregados (`QualityDashboardResponse`). |

### Audit Report (`audit-report`)
| Método | Ruta | Descripción |
|---|---|---|
| GET | `/audit-report/{companyId}/{entityId}?from&end` | Informe de auditoría combinado de una entidad. |

---

## Probar la feature: AnalyzeCustomerFeedback

Mide la satisfacción del cliente (ISO 9001 cláusula 9.1.3) agregando el feedback en:
`AverageRating`, `TotalCount`, `RatingsByValue` (distribución 1-5) y `RecentComments`
(los 5 comentarios más recientes no vacíos). `entityId` es **opcional**: sin él analiza toda la
empresa; con él, una entidad/pedido concreto.

### 1) Sembrar feedback

```bash
H=http://localhost:5058
curl -X POST $H/customer-feedback -H "Content-Type: application/json" \
  -d '{"entityId":"order-100","companyId":"empresa-1","customerId":"cust-1","rating":5,"comments":"Excelente servicio","reportedAt":"2026-06-20T10:00:00Z"}'
curl -X POST $H/customer-feedback -H "Content-Type: application/json" \
  -d '{"entityId":"order-100","companyId":"empresa-1","customerId":"cust-2","rating":4,"comments":"Buen producto","reportedAt":"2026-06-21T11:00:00Z"}'
curl -X POST $H/customer-feedback -H "Content-Type: application/json" \
  -d '{"entityId":"order-200","companyId":"empresa-1","customerId":"cust-3","rating":2,"comments":"Entrega lenta","reportedAt":"2026-06-22T09:00:00Z"}'
curl -X POST $H/customer-feedback -H "Content-Type: application/json" \
  -d '{"entityId":"order-200","companyId":"empresa-1","customerId":"cust-4","rating":1,"comments":"","reportedAt":"2026-06-22T15:00:00Z"}'
```

### 2) Consultar el análisis

```bash
# Toda la empresa (rango explícito que cubre los datos)
curl "$H/customer-feedback/empresa-1/analyze?from=2026-06-01&end=2026-06-30"

# Filtrado por entidad
curl "$H/customer-feedback/empresa-1/analyze?entityId=order-100&from=2026-06-01&end=2026-06-30"

# Sin rango: usa el default (últimos 30 días)
curl "$H/customer-feedback/empresa-1/analyze"
```

Respuesta de ejemplo (toda la empresa con los 4 seeds):

```json
{
  "averageRating": 3.0,
  "totalCount": 4,
  "ratingsByValue": { "5": 1, "4": 1, "2": 1, "1": 1 },
  "recentComments": ["Entrega lenta", "Buen producto", "Excelente servicio"]
}
```

Observa que el comentario vacío (rating 1) **no** aparece en `recentComments`.

> Si usas el default sin `from/end`, recuerda que el filtro llega hasta el **final del día actual**:
> registros con `reportedAt` posterior a "hoy" en el reloj del servidor quedarán fuera.

### En la UI

Abre [`/docs/api`](http://localhost:5058/docs/api), localiza el grupo **customer-feedback**,
y prueba `GET /customer-feedback/{companyId}/analyze` rellenando `companyId` (y opcionalmente
`entityId`, `from`, `end`).
