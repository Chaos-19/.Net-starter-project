# Contoso Pizza Inventory Management API

This project is a cross-platform RESTful service for managing pizza inventory, developed using ASP.NET Core Web API with .NET and C#. It is designed to support the operations of adding, viewing, modifying, and removing pizza types in the inventory, adhering to the CRUD (Create, Read, Update, Delete) operations.

## Project Overview

The project serves as a backend service for a pizza company's web storefront and mobile application. The API enables the management of pizza inventory, which includes creating, reading, updating, and deleting pizza data.

## Features

- **Create**: Add new pizza types to the inventory.
- **Read**: Retrieve a list of all available pizza types or a specific pizza type by ID.
- **Update**: Modify existing pizza details.
- **Delete**: Remove a pizza type from the inventory.

## Technologies Used

- **ASP.NET Core**: A cross-platform, high-performance framework for building modern, cloud-based, internet-connected applications.
- **.NET**: A free, cross-platform, open-source developer platform for building many different types of applications.
- **C#**: A modern, object-oriented programming language developed by Microsoft.
- **Visual Studio Code**: A lightweight but powerful source code editor which runs on your desktop and is available for Windows, macOS, and Linux.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download/dotnet)
- [Visual Studio Code](https://code.visualstudio.com/)

### Installation

1. **Clone the repository:**
   ```bash
   git clone https://github.com/Chaos-19/.Net-starter-project.git
   ```
2. **Navigate to the project directory:**
   ```bash
   cd .Net-starter-project
   ```
3. **Restore the dependencies:**
   ```bash
   dotnet restore
   ```

### Running the Application

To run the application locally:

1. **Run the project:**
   ```bash
   dotnet run
   ```
2. The API will be available at `https://localhost:5001` (or a different port, depending on the configuration).

### Testing

You can use tools like [RestClient](https://marketplace.visualstudio.com/items?itemName=humao.rest-client) or [Postman](https://www.postman.com/) or [cURL](https://curl.se/) to test the API endpoints . Make sure to start the server before testing.


## Acknowledgements

This project was developed as part of a training module on Microsoft Learn. Special thanks to the Microsoft community for their support and resources.
