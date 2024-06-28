
# EcommerceAPI DigitalesWeb

EcommerceAPI es una API RESTful para la Gestión de Comercio Electrónico desarrollada utilizando ASP.NET Core, Entity Framework Core, MySQL, y JWT para la seguridad. Este proyecto sirve como un ejemplo de implementación de una API completa con autenticación y autorización basadas en JWT, y operaciones CRUD para la gestión de productos.

 API RESTful para la Gestión de Comercio Electrónico utilizando ASP.NET Core, Entity Framework Core, MySQL, y JWT para la seguridad

## Características

- **ASP.NET Core**: Framework robusto y escalable para desarrollar aplicaciones web.
- **Entity Framework Core**: ORM para facilitar la interacción con la base de datos MySQL.
- **MySQL**: Base de datos relacional para almacenamiento de datos.
- **JWT (JSON Web Tokens)**: Implementación de autenticación y autorización segura.
- **Operaciones CRUD**: Gestión completa de productos (crear, leer, actualizar, eliminar).

## Requisitos Previos

- .NET Core SDK
- MySQL Server
- Visual Studio Code
- Postman (opcional, para pruebas)

## Configuración del Proyecto

### 1. Clonar el Repositorio

```bash
git clone https://github.com/tuusuario/EcommerceAPI.git
cd EcommerceAPI
```

### 2. Configurar la Cadena de Conexión

Modificar el archivo `appsettings.json` con la cadena de conexión a tu base de datos MySQL:

```json
{
    "ConnectionStrings": {
        "DefaultConnection": "server=localhost;database=ecommercedb;user=root;password=yourpassword;"
    },
    "Jwt": {
        "Key": "yourSecretKey",
        "Issuer": "yourIssuer",
        "Audience": "yourAudience"
    }
}
```

### 3. Migrar la Base de Datos

Ejecutar los siguientes comandos para aplicar las migraciones y crear la base de datos:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 4. Ejecutar la Aplicación

Iniciar la aplicación con el comando:

```bash
dotnet run
```

La API estará disponible en `https://localhost:5001`.

## Endpoints Disponibles

### Autenticación

- **Registro de Usuario**

  `POST /api/auth/register`
  
  Cuerpo:
  ```json
  {
      "Username": "testuser",
      "Password": "password123"
  }
  ```

- **Login de Usuario**

  `POST /api/auth/login`
  
  Cuerpo:
  ```json
  {
      "Username": "testuser",
      "Password": "password123"
  }
  ```
  
  Respuesta:
  ```json
  {
      "token": "yourJWTtoken"
  }
  ```

### Productos

Endpoints protegidos con JWT. Añadir el token en el encabezado `Authorization` con el formato `Bearer <yourJWTtoken>`.

- **Obtener todos los productos**

  `GET /api/products`
  
- **Obtener un producto por ID**

  `GET /api/products/{id}`
  
- **Crear un nuevo producto**

  `POST /api/products`
  
  Cuerpo:
  ```json
  {
      "Name": "Product1",
      "Description": "Description1",
      "Price": 10.99
  }
  ```
  
- **Actualizar un producto**

  `PUT /api/products/{id}`
  
  Cuerpo:
  ```json
  {
      "Id": 1,
      "Name": "Updated Product",
      "Description": "Updated Description",
      "Price": 15.99
  }
  ```

- **Eliminar un producto**

  `DELETE /api/products/{id}`

## Contribución

Las contribuciones son bienvenidas. Por favor, abre un issue o crea un pull request para mejoras y correcciones de errores.

## Licencia

Este proyecto está licenciado bajo la Licencia MIT. Consulta el archivo [LICENSE](LICENSE) para más detalles.