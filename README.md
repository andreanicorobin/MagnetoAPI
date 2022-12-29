# MagnetoAPI
Nivel 2 API REST


API REST que envía la secuencia de adn a una base de datos

La aplicación se encuentra elaborada en el lenguaje .NET CORE 6 C#, con una Base de Datos en SQL Server, que tiene la función de recibir un archivo de formato JSON con un arreglo de secuencias de ADN que luego almacena en la BD.

Para probar la API es necesario descargar la BD la cual se cuentra anexa en este proyecto con el nombre de "Mutans_BD", la cual debe restaurarse y colocar su cadena de conexión en el archivo "Mutant_bd.cs" (linea 14) de la API. Una vez colocada la cadena de conexión verificar en View/ServerExplorer que la Base de Datos se encuentre conectada y compilar la API. La API se ejecuta automáticamente con Swagger pero también puede verificarse mediante postman con el archivo JSON que se definió en la prueba:

{ “dna”:["ATGCGA","CAGTGC","TTATGT","AGAAGG","CCCCTA","TCACTG"] }
