 # Cómo usar la información generada por los procesos de auditoría
 
 Quién debe acceder a ella es esencial para cumplir con los requisitos de ISO 9001, y también para que tenga valor real en la gestión de calidad.

## ¿Cuál es el propósito de los procesos de auditoría en ISO 9001?
En ISO 9001, las auditorías internas tienen como propósito:

- Verificar que los procesos están funcionando como se definió en el sistema de gestión de calidad.
- Detectar desviaciones o no conformidades que no han sido reportadas.
- Recoger evidencias objetivas para tomar decisiones informadas y mejorar.
- Demostrar trazabilidad en caso de auditorías externas (por clientes o certificadores).

## ¿Qué datos hemos generado hasta ahora que sirven para auditoría?
Tú ya tienes trazabilidad de eventos como:

- Creación de pedido.
- Registro y resolución de no conformidades.
- Registro de pagos.
- Envío de feedback del cliente.
- Reporte y análisis de incidencias.
- Estado de pedidos, fechas de actualización, etc.

Cada uno de estos eventos representa un punto auditado en el ciclo de vida del proceso.

## ¿Cómo y quién debe usar esta información?
### Responsable de Calidad (usuario interno de la empresa):
Tiene acceso a un módulo de auditoría interna o panel de trazabilidad, donde puede:

- Consultar los eventos de cada pedido.
- Revisar si todos los pasos del proceso se han cumplido (por ejemplo: si un pedido se pagó antes de ser entregado, si se resolvió una no conformidad correctamente, etc.).
- Generar informes de cumplimiento o incumplimiento.
- Exportar evidencias de trazabilidad.

### Auditor Externo (certificador o cliente):
Puede recibir un acceso restringido (por tiempo o usuario) o un informe generado desde el sistema donde se visualice:

- Un pedido específico y su trazabilidad completa.
- Estadísticas de cumplimiento de procedimientos.
- Histórico de no conformidades y acciones correctivas aplicadas.

### Directivos o responsables de mejora continua:
Usan los datos para detectar patrones y tomar decisiones.

Pueden ver dashboards como:

- Tiempo promedio de resolución de no conformidades.
- Porcentaje de pedidos con incidencias.
- Evaluaciones de feedback negativo vs positivo por producto.

## ¿Cómo implementarlo en tu sistema (basado en Clean Architecture y Blazor)?
Te propongo tres funcionalidades que puedes desarrollar:

### Panel de auditoría por pedido:
En Blazor, un componente donde el responsable de calidad puede ingresar un ID de pedido y ver:

- Todos los eventos asociados con ese pedido (fecha, tipo de evento, responsable).
- Estados del pedido con sus timestamps (creado, pagado, entregado, cerrado).
- Si hubo no conformidades o feedback negativo.
- Acciones correctivas aplicadas.

### Dashboard de calidad (estadístico):
Una sección con gráficas (usando por ejemplo ChartJs adaptado a Blazor sin JS o usando componentes SVG puros o canvas por CSS) con:

- Tendencias de incidencias.
- Ratio de resolución vs generación.
- Satisfacción del cliente a lo largo del tiempo.
 
### Generador de informe de auditoría:
Un botón en el panel de auditoría que permita exportar un informe en PDF (por ejemplo, usando SkiaSharp o un sistema de plantillas) con los datos trazables para un pedido, cliente o periodo de tiempo.

## ¿Qué necesitas para completar esto?
Ya tienes muchos de los eventos registrados. Solo falta:

- Una tabla común de "AuditEvents" o "EventLog" donde se centralicen los eventos claves por tipo (pedido creado, pago recibido, etc.).
- Vistas en Blazor para consultar por cliente, por pedido o por fechas.

Autorizaciones: que solo perfiles específicos (como el rol "Auditor" o "Responsable de calidad") puedan acceder a estos informes.