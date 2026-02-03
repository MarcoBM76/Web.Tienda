Este proyecto es una aplicación Web Full-Stack desarrollada con Angular 16+ para el Frontend y .NET Core Web API para el Backend, utilizando SQL Server como motor de base de datos.

Requisitos Previos
Antes de comenzar, asegúrate de tener instalado:

Node.js (v18 o superior)

.NET SDK 8.0 (o la versión que estés usando)

SQL Server Management Studio (SSMS).

Pasos para el Despliegue
1. Configuración de la Base de Datos (Paso Crítico)
Antes de ejecutar la aplicación, debes preparar el esquema de datos:

Abre SQL Server y crea una base de datos vacía (ej. TiendaDB).

Navega a la carpeta /scripts en la raíz de este repositorio.

Abre el archivo createDB.sql.

Ejecuta el script sobre la base de datos que creaste.

Nota: Este script creará las tablas Articulo, Tienda, Cliente y la tabla relacional ArticuloTienda, incluyendo las restricciones de llave foránea.

2.- Configura la cadena de conexión en el archivo appsettings.json:

JSON
"ConnectionStrings": {
  "DefaultConnection": "Server=TU_SERVIDOR;Database=TiendaDB;Trusted_Connection=True;TrustServerCertificate=True;"
}

3. Instala las dependencias de Node:

Bash
npm install

4.- Credenciales de AccesoEl sistema cuenta con protección por roles. 
Puedes usar las siguientes cuentas para probar
Usuario	    Contraseña	Rol	          Acceso
admin	      1234	       ADMIN	      Acceso total (Tiendas, Clientes, Artículos)
vendedor	  1234	        USER	      Solo lectura y gestión de Artículos


Tecnologías Utilizadas
Frontend: Angular, Bootstrap 5 (Responsive Design), Reactive Forms.

Backend: .NET Core, Entity Framework Core.

Base de Datos: SQL Server

Seguridad: Auth Guards y Role-based Access Control.
