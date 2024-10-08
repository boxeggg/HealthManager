#  HealthManager

This project is an ASP.NET MVC (.NET 7) web application designed to store and manage medical test results. It also allows users to associate these results with specific devices and customize their profiles.

The app, developed during my internship, is available in Polish

## Features

- **Test Results Management**: Add, edit, and view medical test results.
- **Device Association**: Link test results to specific medical devices.
- **User Profile Customization**: Users can modify and customize their profiles, such as personal data (weight,name etc)

## Technologies

- ASP.NET MVC (Version 7)
- ASP.NET Identity
- Entity Framework Core
- SQL Server (for database)
- HTML, CSS, JavaScript (Frontend)
- Bootstrap (for responsive design)

## Screenshots

1. **Main Dashboard Panel**
   ![Main Dashboard](panel.webp)

2. **User Registration Panel**
   ![Registration Panel](profile.webp)

3. **Measurement Results Overview**
   ![Measurement Results](pomiary.webp)

4. **Device Connection Settings**
   ![Device Settings](urządzenia.webp)

## Requirements

- .NET 7 SDK
- SQL Server (local or cloud)
- Visual Studio (or any other IDE supporting .NET)

## Setup Instructions

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/your-repo-name.git
2. Open the solution in Visual Studio.
3. Update the `appsettings.json` file to configure the connection string for your SQL Server instance.
4. Apply the database migrations:
   ```bash
   dotnet ef database update
