# TheatreBookingSystem

TheatreBookingSystem is a web application built using ASP.NET MVC, designed to allow users to book seats for theatre performances. The application is designed to be intuitive and easy to use for both users and administrators.


## Features

### For Users
<li>Registration and Login: Users can create accounts and log in to make bookings.</li><li>
Browse Performances: View a list of available performances with dates, times, and seat availability.</li><li>
Book Tickets: Select seats and book tickets for chosen performances.</li><li>
Booking History: View a history of all bookings made.</li>

### For Administrators
<li>Manage Performances: Add, edit, and delete performances.</li><li>
Manage Bookings: View and manage user bookings.</li><li>
Manage Users: View and manage user accounts.</li>

## System Requirements
<li>Platform: ASP.NET MVC</li><li>
Database: SQL Server or other compatible databases</li><li>
Framework: .NET Framework 4.7.2 or later</li><li>
Development Environment: Visual Studio 2019 or later</li>


## Installation

### 1. Clone the repository:
```shell
git clone https://github.com/Jaroslawx/TheatreBookingSystem-MVC
```
### 2. Open the solution in Visual Studio.

### 3. Restore the NuGet packages:
```shell
Update-Package -reinstall
```
### 4. Update the connection string in appsettings.json to match your database configuration.

### 5. Apply migrations to set up the database:
```shell
Update-Database
```

### 6. Run the application:
```shell
Start-Without-Debugging
```


## Usage
### For Users
<ol>
<li>Register: Create an account using the registration form.</li><li>
Login: Use your credentials to log in.</li><li>
Browse Performances: Navigate to the performances page to view available shows.</li><li>
Book Tickets: Select a performance, choose your seats, and confirm the booking.</li><li>
View Booking History: Access your booking history from your profile.</li>
</ol>

### For Administrators
<ol>
<li>Login: Use admin credentials to log in.</li><li>
Manage Performances: Add, edit, or delete performances from the admin panel.</li><li>
Manage Bookings: View and manage user bookings.</li><li>
Manage Users: View and manage user accounts.</li>
</ol>

## License
This project is licensed under the MIT License. See the [LICENSE](https://github.com/Jaroslawx/TheatreBookingSystem-MVC/blob/master/LICENSE) file for details.
