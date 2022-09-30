# All Trails Lead To Roam

#### By Megan McKissack, Louie Knolle, Ryan Gibson, Patty Rose

![Dev Team](/img/devsPic.jpg)

#### A web application map api built to create hiking trails by placing markers on the map.

## Technologies Used

* C#
* HTML
* CSS
* Javascript
* Bootstrap
* MySQL Workbench
* ASP.NET
* Entity Framework
* REPL
* Swagger

## Description

This web application uses ArcGIS maps in conjunction with our Trails api. With the Trails api you can place makers on the map to create hiking trails. Click on the map to get the latitude and longitude, then you can add a name and description. Do this as many times as you like to create the trail you want and place landmarks along the way!

## Setup/Installation

* First, make sure you have MySql Workbench downloaded and properly installed. You will also need a text editor(Vscode was used to make this application)
* At https://github.com/patty-rose/Trails.Solution.git copy the git repository URL from the green "code" button.
* Open a shell program & navigate to your desktop
* Clone the repository using the copied URL and the "git clone" command
* Make sure sensitive data/files are in the .gitignore file so they to no get pushed to a remote repository. The files in .gitignore should be:

```
  */obj/
  */bin/
  */appsettings.json
```

* In the shell program, navigate to TrailsApi directory of "Trails.Solution"
* In the TrailsApi directory create a file named "appsettings.json"
* Add the following code to the newly created .json file
```
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=trails;uid=root;pwd=epicodus;"
  }
}
```
* Make sure the following packages are restored or type the following in the Project directory.
  * `dotnet add package Microsoft.EntityFrameworkCore -v 5.0.0`
  * `dotnet add package Pomelo.EntityFrameworkCore.MySql -v 5.0.0-alpha.2`
  * `dotnet add package Microsoft.EntityFrameworkCore.Proxies -v 5.0.0`
  * `dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore -v 5.0.0`
* Then do the following accordingly in your terminal to update and connect your project to your local database :
  * `dotnet restore`
  * `dotnet build`
  * `dotnet ef migrations add Initial`
  * `dotnet run`

* The above code will create a new database in your local host with tables designed to store information related to the project.
* To interact with the local host website navigate to the project directories Trails Api and TrailsClient and run `dotnet run`or `dotnet watch run` for each, then type http://localhost:5001 into the URL bar in the browser.

## Known Bugs

* No known issues

## License

[MIT](LICENSE)

Copyright (c) 2022 Megan McKissack, Louie Knolle, Ryan Gibson, Patty Rose




Package needed for GeoCoordinate:

Packages needed for Client:
dotnet add package RestSharp --version 106.6.10
dotnet add package Newtonsoft.Json --version 12.0.2
