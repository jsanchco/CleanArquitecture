Migración
*********

1- Establecer como proyecto de inicio en donde tengamos instanciado CA.Domain (cadena de conexión). En mi caso CA.API
2- En la 'Consola del Administrador de Paquetes' establecer como 'Proyecto predeterminado' en donde tengamos instanciados los repositorios. En mi caso CA.DataEFCore
3- Ejecutamos en Power-Shell 'add-migration FirstMigration'
4- Se creará en CA.Domain una carpeta en donde se creará la migración
5- Construimos la base de datos en donde haya indicado la cadena de conexión ejecutando en Power-Shell 'Update-Database'
6- Corremos la app CA.SeedData

7- Si queremos eliminar la Migración, ejecutamos en Power-Shell 'remove-migration'