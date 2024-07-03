# EcommerceAPI - DigitalesWeb - English

EcommerceAPI is a RESTful API for E-commerce Management developed using ASP.NET Core, Entity Framework Core, MySQL, and JWT for security. This project serves as an example of implementing a complete API with JWT-based authentication and authorization, and CRUD operations for product management. 

# If you like it, please click to show your support. ⭐️Star

## Features

- **ASP.NET Core**: Robust and scalable framework for developing web applications.
- **Entity Framework Core**: ORM to facilitate interaction with the MySQL database.
- **MySQL**: Relational database for data storage.
- **JWT (JSON Web Tokens)**: Secure authentication and authorization implementation.
- **CRUD Operations**: Complete product management (create, read, update, delete).
- **Swagger**: Interactive API documentation and testing, which opens automatically in the browser when running `dotnet run`.

## Prerequisites

- .NET Core SDK
- MySQL Server
- Visual Studio Code
- Postman (optional, for testing)

## Project Setup

### 1. Clone the Repository

```bash
git clone https://github.com/yourusername/EcommerceAPI.git
cd EcommerceAPI
```

### 2. Configure the Connection String

Modify the `appsettings.json` file with your MySQL database connection string:

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

### 3. Migrate the Database

Run the following commands to apply the migrations and create the database:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 4. Run the Application

Start the application with the command:

```bash
dotnet run
```

The API will be available at `https://localhost:5070`, and Swagger UI will open automatically at `https://localhost:5070/index.html`.

## Available Endpoints

### Authentication

- **User Registration**

  `POST /api/auth/register`
  
  Body:
  ```json
  {
      "Username": "testuser",
      "Password": "password123"
  }
  ```

- **User Login**

  `POST /api/auth/login`
  
  Body:
  ```json
  {
      "Username": "testuser",
      "Password": "password123"
  }
  ```
  
  Response:
  ```json
  {
      "token": "yourJWTtoken"
  }
  ```

### Products

Endpoints protected with JWT. Add the token in the `Authorization` header with the format `Bearer <yourJWTtoken>`.

- **Get All Products**

  `GET /api/products`
  
- **Get Product by ID**

  `GET /api/products/{id}`
  
- **Create a New Product**

  `POST /api/products`
  
  Body:
  ```json
  {
      "Name": "Product1",
      "Description": "Description1",
      "Price": 10.99
  }
  ```
  
- **Update a Product**

  `PUT /api/products/{id}`
  
  Body:
  ```json
  {
      "Id": 1,
      "Name": "Updated Product",
      "Description": "Updated Description",
      "Price": 15.99
  }
  ```

- **Delete a Product**

  `DELETE /api/products/{id}`

## API Documentation with Swagger

The API includes Swagger integration for easy documentation and testing of endpoints. Swagger UI will automatically open in the browser when running the application with `dotnet run`, accessible at `https://localhost:5070/index.html`.

## Contribution

Contributions are welcome. Please open an issue or create a pull request for improvements and bug fixes.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.



# EcommerceAPI - DigitalesWeb - Español

EcommerceAPI es una API RESTful para la Gestión de Comercio Electrónico desarrollada utilizando ASP.NET Core, Entity Framework Core, MySQL, y JWT para la seguridad. Este proyecto sirve como un ejemplo de implementación de una API completa con autenticación y autorización basadas en JWT, y operaciones CRUD para la gestión de productos.

## Características

- **ASP.NET Core**: Framework robusto y escalable para desarrollar aplicaciones web.
- **Entity Framework Core**: ORM para facilitar la interacción con la base de datos MySQL.
- **MySQL**: Base de datos relacional para almacenamiento de datos.
- **JWT (JSON Web Tokens)**: Implementación de autenticación y autorización segura.
- **Operaciones CRUD**: Gestión completa de productos (crear, leer, actualizar, eliminar).
- **Swagger**: Documentación interactiva y pruebas de la API, se abre automáticamente en el navegador al ejecutar `dotnet run`.

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

La API estará disponible en `https://localhost:5070` y Swagger UI se abrirá automáticamente en `https://localhost:5070/index.html`.

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

## Documentación de la API con Swagger

La API incluye integración con Swagger para facilitar la documentación y prueba de los endpoints. Swagger UI se abrirá automáticamente en el navegador al ejecutar la aplicación con `dotnet run`, accesible en `http://localhost:5070`.

## Contribución

Las contribuciones son bienvenidas. Por favor, abre un issue o crea un pull request para mejoras y correcciones de errores.

## Licencia

Este proyecto está licenciado bajo la Licencia MIT. Consulta el archivo [LICENSE](LICENSE) para más detalles.

---
