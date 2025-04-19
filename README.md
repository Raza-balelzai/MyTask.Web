# 📌 MyTask.Web

## 📋 Requirements

Before running this application, please ensure the following tools are installed on your system:

1. [Visual Studio](https://visualstudio.microsoft.com/)
2. [SQL Server](https://www.microsoft.com/en-us/sql-server)
3. [SQL Server Management Studio (SSMS)](https://learn.microsoft.com/en-us/sql/ssms/download-ssms)

---

## ⚙️ Getting Started

1. Clone the repository and open the solution in Visual Studio.
2. Navigate to `appsettings.json` and replace the server name in the connection string:

   ```json
   "ConnectionStrings": {
     "dbcs": "Server=YourSQLSERVER;Database=YourDbName;Trusted_Connection=True;"
   }


## 🧾 About the Project

**MyTask.Web** is a basic ASP.NET Core MVC web application designed to demonstrate essential web development practices using the .NET stack. It includes a fully functional login and registration system, user session management, and dynamic user listing with pagination.

### 🔧 Key Features

- 🧱 **MVC Architecture**: Clean separation of concerns between models, views, and controllers.
- 🎨 **Razor Views with Bootstrap**: All UI components are styled using Bootstrap to ensure a responsive and modern look.
- 📁 **Repository Pattern**: Abstracts data access logic to promote separation of concerns and maintainability.
- 🧩 **ViewModels / DTOs**: Used to support loose coupling between the UI and data access layers.
- 💉 **Dependency Injection**: Implemented across the project for better scalability, testability, and cleaner code.
- ✅ **Form Validation**: Both server-side and client-side validations are in place for the login and registration forms.
- 🔐 **Secure Authentication**: Passwords are hashed using the built-in ASP.NET Core Identity framework.
- 💾 **Session Management**: Authenticated user data is stored in session and accessed in the `Index` method of `HomeController`.
- 💬 **User Feedback via ViewBag**: Validation messages and feedback are passed to the views using `ViewBag`.
- 📄 **Pagination**: User list display is paginated to enhance usability and performance on large datasets.
