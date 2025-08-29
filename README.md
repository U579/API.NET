🌐 API.NET
API.NET es una API desarrollada en .NET Core para gestionar recursos web de manera eficiente, segura y escalable. Está diseñada con arquitectura hexagonal, lo que permite una separación clara entre el núcleo de negocio y los adaptadores externos.

✨ Características
- 🧱 Arquitectura Hexagonal (Ports & Adapters)
- 🔐 Autenticación y autorización con JWT
- 🛠️ CRUD completo para entidades principales
- ⚠️ Manejo de errores centralizado
- 📚 Documentación interactiva con Swagger

⚙️ Instalación
- Clona el repositorio:
git clone https://github.com/tuusuario/API.NET.git
- Instala las dependencias:
dotnet restore
- Ejecuta la API:
dotnet run


🚀 Uso
Puedes explorar y probar los endpoints de forma interactiva a través de Swagger UI:
http://localhost:5095/swagger


Esta interfaz te permite:
- Enviar peticiones
- Visualizar respuestas
- Validar el comportamiento de la API en tiempo real
También puedes consumir la API desde herramientas como:
- 🧪 Thunder Client (Visual Studio Code)
- 📬 Postman
- 🖥️ curl
Solo asegúrate de incluir los siguientes encabezados en cada petición:
X-API-KEY: clave-super-secreta-123
Content-Type: application/json


🛠️ Configuración
Edita el archivo appsettings.json para configurar:
- 🔗 Cadena de conexión a la base de datos
- 🔐 Clave de API para el middleware de seguridad
- ⚙️ Otros parámetros de entorno

📦 Funcionalidades
La API permite gestionar la entidad Usuario mediante operaciones RESTful, respetando los principios de arquitectura hexagonal para garantizar:
- Escalabilidad
- Mantenibilidad
- Desacoplamiento entre capas

🧩 Gestión de Usuarios
| Metodo|     Ruta      | 
| POST  | /api/user     |
| GET   | /api/user     |
| GET   | /api/user/{id}|
| PUT   | /api/user/{id}|
| PATCH | /api/user/{id}|
| DELETE| /api/user/{id}|


🔐 Seguridad
- 🔒 Middleware de API KEY
Todas las peticiones deben incluir el encabezado X-API-KEY con una clave válida definida en appsettings.json.
- 🛡️ Swagger está excluido del middleware para permitir el acceso libre a la documentación interactiva.

📚 Documentación interactiva
Accede a la interfaz Swagger en:
http://localhost:5095/swagger


Desde ahí puedes explorar los endpoints, enviar peticiones y visualizar respuestas en tiempo real.

🧪 Compatible con herramientas externas
Puedes consumir la API desde:
- 🧪 Thunder Client (Visual Studio Code)
- 📬 Postman
- 🖥️ curl
Recuerda incluir los headers:
X-API-KEY: clave-super-secreta-123
Content-Type: application/json


👨‍💻 Autor
Marco Uriel Gómez Romero
Desarrollador full-stack con enfoque ético, autodidacta y comprometido con la mejora continua.
📍 Ario de Rosales, México

📄 Licencia
Este proyecto está licenciado bajo la GNU General Public License v3.0.
Puedes copiarlo, modificarlo y distribuirlo bajo los términos de esta licencia.
Consulta el texto completo en:
🔗 https://www.gnu.org/licenses/gpl-3.0.html