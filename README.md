[![N|Solid](https://repositorio.itc.edu.co/image/logo_es.png)](https://etitc.edu.co/es/)

# CLASE ELECTIVA .NET 
## API .net Core 6.0

Una API creada para solventar la necesidad de registro de equipos portátiles en las instalaciones de ETITC sede centro.

## Elaborada Con
- .Net Core 6.0 (C#)
- MongoDb
- Swagger
## Características
- CRUD de Usuarios, Dispositivos y Registro de Dispositivos.
- Contraseña Segura y Encriptada. 
- Generación de JWT para la autenticación de usuario.
- Habilitar y des-habilitar registros.

## Despliegue 

Requiere [Visual Studio 2022](https://visualstudio.microsoft.com/es/vs/).
Requiere [Git](https://git-scm.com/).

1. Clone el repositorio, desde una terminal

```sh
git clone https://github.com/manuelrojasm/ETITC_EquipmentControlAPI.git
```
2. En Visual Studio abra como proyecto el repositorio descargado.
3. Cree una Clase en la raíz llamada "Constants.cs" 
4. En dicho archivo agregue las variables de entorno de la API.
```sh
    public class Constants
    {
        public static string DataBase = "(nombre de la coleccion)";
        public static string Client = "(Conexion de la BD)"
        public const string SecrectKey = "(Llave privada)";
    }
```
5. Modifique Constants.cs agregando el nombre que quiere dar a la Colección en DataBase, el texto de conexión proporcionado por MongoDB en Client y en SecretKey un Hash o texto secreto que usted proporcione para usar como llave en la encriptación.

**Si lo puedes imaginar, Lo puedes Programar!**

[//]: # (Desarrollado por Manuel Rojas y Maura Tamayo)
