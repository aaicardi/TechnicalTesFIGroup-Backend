# TechnicalTesFIGroup-Backend
Technical Tes FIGroup Backend

# Ejecutar Migraciones
Para ejecutar las migraciones realice los siguientes Pasos:
1. En su equipo local cree una base de datos llamada FIGroupDB
2. Seleccione como proyecto de inicio "TecnicalTest.FIGroup.UI.Api"
3. En el proyecto TecnicalTest.FIGroup.Infrastructure en la clase DependencyInjection.cs descomentar la linea 26 y comentar las lineas 27 y 28
4. Modificar las credenciales: "Server=[TUSERVER];Database=FIGroupDB;User Id=[TU-USUARIO];Password=[TU-PASSWORD];MultipleActiveResultSets=true;encrypt=true;trustServerCertificate=true; de acceso configuradas en su base de datos y cambie las que se encuentran el la linea 24
5. En la consola "Package Manager Console", seleccione el proyecto TecnicalTest.FIGroup.Infrastructure y ejecute la siguiente linea de comandos: update-database. Este comando ejecutará las migraciones del proyecto, creando tablas e insertando datos semillas.
6. Luego de ejecutar el comando, comenta la linea 26 y descomentar las lineas 27 y 28
7. Ejecutar el proyecto

