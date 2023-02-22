# TechnicalTesFIGroup-Backend
Technical Tes FIGroup Backend

# Ejecutar Migraciones
Para ejecutar las migraciones realice los siguientes Pasos:
1. En su equipo local cree una base de datos llamada FIGroupDB
2. En el proyecto TecnicalTest.FIGroup.Infrastructure en la clase DependencyInjection.cs descomentar la linea 24 y comentar las lineas 25 y 26
3. Modificar las credenciales: "Server=[TUSERVER];Database=FIGroupDB;User Id=[TU-USUARIO];Password=[TU-PASSWORD];MultipleActiveResultSets=true;encrypt=true;trustServerCertificate=true; de acceso configuradas en su base de datos y cambie las que se encuentran el la linea 24
4. En la consola de comandos ejecutar: update-database
5. Luego de ejecutar el comando, comenta la linea 24 y descomentar las lineas 25 y 26
6. Ejecutar el proyecto

