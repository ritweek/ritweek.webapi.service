# ritweek.webapi.service

# Employee Management API

This is a .NET Core Web API project for managing employee data. The API allows you to perform CRUD (Create, Read, Update, Delete) operations on employee records stored in an in-memory database.

## Features

- Add a new employee
- Get a list of all employees
- Get a specific employee by ID
- Update an existing employee
- Delete an employee
- Search

## Technologies Used

- .NET Core 6
- Entity Framework Core
- In-memory Database
- Swagger (API documentation)

### Logging

The Employee Management API uses logging to record important events and error information. It uses the logging framework provided by ASP.NET Core.

The API logs errors and other relevant information using the ILogger interface. The logs are written to the configured logging provider, such as the console, file, or a third-party logging service.

By default, the API logs errors to the console output in the development environment. In a production environment, you can configure the logging to use other providers, such as a file or a logging service like Azure Application Insights.

To enable additional logging or modify the logging behavior, you can update the logging configuration in the `appsettings.json` file or use a different logging provider.



## Getting Started

Follow the instructions below to get started with the project on your local machine.

### Prerequisites

- .NET Core 6 SDK (or later) installed on your machine

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/ritweek/ritweek.webapi.service.git
   ```

2. Navigate to the project directory:

   ```bash
   cd ritweek.webapi.service
   ```

3. Build the project:

   ```bash
   dotnet build
   ```

4. Run the API:

   ```bash
   dotnet run
   ```

   The API will start running on `http://localhost:5000`.

### API Documentation

The API documentation is available through Swagger. You can access it by navigating to `http://localhost:5000/swagger` in your web browser. Swagger provides a user-friendly interface to explore and test the API endpoints.

### Usage

You can use tools like Postman or cURL to interact with the API endpoints. Refer to the API documentation for detailed information on each endpoint and their request/response formats.

### Screen
    ![Alt text](/relative/path/to/SwaggerPage.png?raw=true "Optional Title")

## Contributing

Contributions are welcome! If you find any issues or want to add new features, please submit a pull request. Make sure to follow the existing coding style and conventions.

## License

This project is licensed under the [MIT License](LICENSE).

## Acknowledgments

- This project was developed as a part of the employee management system.
- Thanks to the contributors and open-source community for their valuable contributions.

## Contact

For any questions or inquiries, please contact [Ritweek Ranjan](mailto:ritweek+github@gmail.com).

---
