# Employee-Approval-with-ASP.NET-Core-MVC
 
Setup and Run ASP.NET Core MVC Project

Follow these steps to set up and run a .NET 7 project after cloning it:



Prerequisites

.NET 7 SDK (Install from dotnet.microsoft.com).

MSSQL Server (Install locally or use a remote instance).

Code Editor: Visual Studio 2022 (or Visual Studio Code).

Steps

Clone the Repository

Open the terminal and clone the project:


git clone https://github.com/Md-Tahsif-Ahmed/Employee-Approval-with-ASP.NET-Core-MVC

 
Run the following command to restore required packages:

 
 
dotnet restore

Configure the Database

Update the appsettings.json file with your MSSQL Server connection string:

"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=YOUR_DATABASE_NAME;User Id=USER;Password=PASSWORD;"
}

Apply Database Migrations

Run the migrations to set up the database schema:


dotnet ef database update

Build and Run the Project

Clean, build, and run the project:


dotnet clean
dotnet build
dotnet run
Access the Application

Open the browser and navigate to the provided URL, e.g., http://localhost:5000.

 
dotnet restore	 ->(Restore project dependencies)

dotnet ef database  ->(update	Apply EF Core migrations)

dotnet build	      ->(Build the project)

dotnet run	   ->(Run the application)

Troubleshooting

Ensure MSSQL Server is running.

Install EF CLI tools:

dotnet tool install --global dotnet-ef

 
