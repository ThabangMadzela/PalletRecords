PalletRecords MVC Web Application
=================================

A web application to manage pallets and their configurations using .NET 8, Bootstrap 5, and SQLite.

* * *

Project Overview
----------------

This project is an ASP.NET MVC Web Application designed to manage records of pallets and configurations. It allows users to create, edit, delete, and search for pallets. Pallets can have configurations that define batch weights and other attributes. The system calculates how many batches a pallet contains based on its weight and the batch weight.

### Key Features

*   Create, Edit, and Delete Pallets
*   Manage Pallet Configurations (Batch Weight)
*   Batch Calculation based on Pallet Weight and Batch Weight
*   Search Functionality
*   Database integration using SQLite

Setup Instructions
------------------

### 1\. Clone the Repository

    git clone 

### 2\. Install Dependencies

Ensure you have .NET 8 SDK installed. You can download the SDK from [here](https://dotnet.microsoft.com/download/dotnet).

Run the following commands to set up the necessary tools and packages:

    dotnet new tool-manifest    # Create the tool manifest (if not already present)
    dotnet tool install dotnet-ef       # Install the Entity Framework Core CLI tool
    dotnet add package Microsoft.EntityFrameworkCore.Sqlite     # SQLite provider for EF Core
    dotnet add package Microsoft.EntityFrameworkCore.Tools       # EF Core tools
    dotnet add package Microsoft.AspNetCore.Mvc                  # MVC support
    dotnet add package Microsoft.EntityFrameworkCore.Design      # Design-time support for EF Core
    dotnet add package Microsoft.AspNetCore.Mvc.ViewFeatures     # View features for MVC

### 3\. Configure the SQLite Database

This application uses SQLite for data storage. Ensure that the database is configured in `Program.cs` and migrations are applied correctly.

### 4\. Run the Application

You can run the application using the following command:

    dotnet run

Features & Functionality
------------------------

The application includes the following key functionalities:

*   **Create Pallet:** Users can add a new pallet with details like number, weight, material, and description. This view is located in `Views/Pallets/Create.cshtml`.
*   **Edit Pallet:** Allows users to modify existing pallet details. The form is located in `Views/Pallets/Edit.cshtml`.
*   **Delete Pallet:** Users can delete a pallet record. This action is handled in `Views/Pallets/Delete.cshtml`.
*   **View Pallet Details:** Each pallet can be viewed with its full details, including its configuration. This view is located in `Views/Pallets/Details.cshtml`.
*   **Search for Pallets:** Users can filter pallets by material using the search form located in `Views/Pallets/Index.cshtml`.

Models
------

The application uses the following models to represent the pallet and its configurations:

*   **Pallet.cs**: Represents the pallet entity, including properties like number, weight, material, and description.
*   **PalletConfig.cs**: Represents the pallet configuration entity, including properties like name, description, and batch weight.
*   **ConfiguredPallet.cs**: A view model used for creating or editing a pallet and its configuration together.

Database Context
----------------

The database context is located in `Data/AppDbContext.cs`, which sets up the EF Core context and manages migrations and queries for the database.

Controller
----------

The logic for handling pallet-related actions (CRUD operations, batch calculation) is implemented in the `PalletsController.cs` class. It includes action methods for:

*   Displaying a list of pallets (**Index** method)
*   Displaying a pallet's details (**Details** method)
*   Creating a new pallet (**Create** method)
*   Editing a pallet (**Edit** method)
*   Deleting a pallet (**Delete** method)
*   Calculating the number of batches for a pallet based on weight and batch weight

Technologies Used
-----------------

This project is built using the following technologies:

*   **ASP.NET MVC 8** - The core framework for building the web application
*   **SQLite** - The database for storing pallet and configuration data
*   **Entity Framework Core** - For database interaction and migrations
*   **Bootstrap 5** - For responsive front-end design
*   **JavaScript/jQuery** - For dynamic client-side interactions (e.g., form validation)

How to Use
----------

Once the application is running, navigate to the following pages to interact with the application:

*   **Home:** The default landing page showing the list of pallets.
*   **Create Pallet:** Navigate to the 'Create' page to add new pallets (located at `/Pallets/Create`).
*   **Edit Pallet:** Click on any pallet from the list to edit it (located at `/Pallets/Edit/{id}`).
*   **Delete Pallet:** You can delete a pallet by clicking on the 'Delete' button next to it.
*   **View Pallet Details:** Click on any pallet from the list to view its details (located at `/Pallets/Details/{id}`).
*   **Search:** Use the search form to filter pallets by material (located at `/Pallets/Index`).

License
-------

This project is licensed under the MIT License - see the [LICENSE](#) file for details.