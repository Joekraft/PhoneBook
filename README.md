# PhoneBook
POC for a simple ASP MVC Core website which posts Phone Book entries to a .Net Core API, using Entity Framework for the ORM in a Code First design to a LocalDB database for storage and retrieval.

### Setup
Scope to the PhoneBook.API project and create the PhoneBook database
* .NET CLI
```dotnet ef database update```
* NuGet Package Manager Console
```Update-Database```
* Run both the PhoneBook.API and PhoneBook.Web projects

### Use Cases
* Add entry to my phone book
* View phone book where I can search for entries (text box to search and list view)
 
### Data Structures
#### PhoneBook {Name, Entries}
* ID
* Name
#### Entry {Name, PhoneNumber}
* ID
* Name
* PhoneNumber
* PhoneBookID

### Project Structure 
#### Frontend
*  ASP.Net Core website
#### Backend
* ASP.Net Web API 2
* Entity Framework Core
#### Database
* LocalDB (SQL Server Express)
#### Tools
* Visual Studio 2019 Community Edition
* .Net Core v2.2

### Todo
* Form validation
* User facing error messages (when API/DB is down)
* Move apiURL to appsettings.json Configuration
