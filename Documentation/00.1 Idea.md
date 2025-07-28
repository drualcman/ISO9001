# ¿Qué es ISO 9001 aplicado al software de ventas online?
ISO 9001 no impone tecnología, sino procesos que garanticen calidad, trazabilidad, mejora continua y satisfacción del cliente.

Vamos a ver dónde se implementa ISO 9001 en tu arquitectura con ejemplos claros y aplicables al software que estás creando.

## Trazabilidad del pedido y auditoría
Proceso ISO: Todo pedido debe quedar registrado, ser trazable y auditable.

¿Cómo lo aplicas?

En el caso de uso PlaceOrderInteractor, debes registrar un log de auditoría con:

- Fecha del pedido
- Usuario que lo hizo
- Productos solicitados
- Resultado del procesamiento

Ejemplo dentro de Interactor:

```csharp
AuditLog audit = new AuditLog
{
    EventType = "PlaceOrder",
    Timestamp = DateTime.UtcNow,
    UserId = request.CustomerId,
    Data = JsonSerializer.Serialize(request)
};


await auditLogRepository.SaveAsync(audit);
```

## Control de documentos y registros
Proceso ISO: Todos los documentos generados (facturas, recibos, órdenes) deben estar almacenados, versionados si corresponde, y accesibles.

¿Cómo lo aplicas?

Guardar una copia digital del pedido y del pago con un identificador único.

Agregar una tabla de historial de pedidos y pagos para garantizar que cada acción sea consultable en el futuro.

## Validación y revisión de procesos
Proceso ISO: Validar que los datos estén correctos antes de continuar.

¿Cómo lo aplicas?

En los Interactors, antes de procesar pedidos o pagos, agregas validaciones explícitas como:

```csharp
if (request.Items.Count == 0)
{
    outputPort.Invalid("Order must contain at least one item.");
    return;
}
```

Esto forma parte del control de calidad preventivo, obligatorio en ISO 9001.

## Seguimiento de la satisfacción del cliente
Proceso ISO: Medir satisfacción.

¿Cómo lo aplicas?

Después de cada pedido completado, guardar un registro que permita:

- Calificar la experiencia (puntuación, comentarios)
- Enviar una encuesta o formulario (si decides hacerlo)
- Crear una entidad CustomerFeedback que se asocie al pedido.

## Mejora continua y análisis de incidencias
Proceso ISO: Debes poder registrar errores, analizar causas y aplicar mejoras.

¿Cómo lo aplicas?

Crear un módulo para registrar incidencias o fallos en los procesos:

- Pagos rechazados
- Fallos en stock
- Problemas en el envío
- Asociar esas incidencias al pedido, cliente, o responsable.

## Responsabilidades y roles
Proceso ISO: Debe quedar claro quién hace qué.

¿Cómo lo aplicas?

Añadir una entidad UserRole y asociar cada acción a un usuario.

Implementar control de permisos en los controladores: solo ciertos roles pueden registrar pagos o aprobar descuentos.