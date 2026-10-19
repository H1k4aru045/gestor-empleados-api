# API Mobiliario

Actividad: tabla, procedimientos almacenados y API en .NET con pruebas en Postman.
Alumno: Jonathan Mendoza Martinez, tabla **Mobiliario**.

## 1. Base de datos

El script `Mobiliario_Script.sql` se ejecuta en SQL Server Management Studio. Con él se crea la base `PracticaMobiliario`, la tabla, los 5 procedimientos y 12 registros de prueba.

## 2. Configuración de la conexión

En `appsettings.json` se agregó la cadena de conexión, con el `Server` cambiado según la instancia de SQL Server que se use:

```json
"ConnectionStrings": {
  "CadenaSQL": "Server=localhost;Database=PracticaMobiliario;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

## 3. Registro del servicio

En `Program.cs`, junto a los demás servicios, se registró la clase de datos:

```csharp
builder.Services.AddSingleton<MobiliarioData>();
```

## 4. Ejecución

La API se ejecuta desde Visual Studio:


Queda en `http://localhost:5299`, en el puerto que se muestre en la consola.

## 5. Pruebas en Postman

Se creo una coleccion y dentro de esta cada metodo siguiendo la logica de anteriores practicas. 

Las peticiones se probaron en este orden: POST, GET todos, GET por ID, PUT, GET por ID (para verificar el cambio), DELETE y GET todos (el registro dado de baja ya no aparece).

| Operación | Método | Ruta |
|---|---|---|
| Registrar | POST | /api/mobiliarios |
| Consultar todos (activos) | GET | /api/mobiliarios |
| Consultar por ID | GET | /api/mobiliarios/1 |
| Actualizar | PUT | /api/mobiliarios/1 |
| Baja lógica | DELETE | /api/mobiliarios/1 |