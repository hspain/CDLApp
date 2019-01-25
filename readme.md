### Cie Digital Labs Assessment

#### Overview

This API has been deployed vie Azure Web Apps to: http://cdlapp.azurewebsites.net

This API was created with a relatively simple tech stack using ASP.NET Core, Entity Framework Core, xUnit, JWT and Azure SQL.

You will need the .NET Core SDK (2.2) to build and run the application.  It can be downloaded here: https://dotnet.microsoft.com/download

To build the app run the following commands in the ```CieDigitalAssessment.API``` directory:

```dotnet restore```

```dotnet build```

To run a local development server run the following command

```dotnet run```

#### Documentation

This app has a fully functional API documentation and testing portal using Swagger (Swashbuckle) which can be found here: http://cdlapp.azurewebsites.net/swagger

An example endpoint for CRUD operations on the data would be to make a GET request at http://cdlapp.azurewebsites.net/api/movies which will return data similar to the following:

```json
[
    {
        "id": 1,
        "title": "Braveheart 2",
        "dateMade": "1995-01-01T00:00:00",
        "director": "Mel Gibson",
        "boxArtUrl": "http://imgr.com/asfdsa",
        "movieCopy": []
    }
]
```

#### Authentication

Authentication and membership is handled through JWT tokens requested via POST at the following endpoint: http://cdlapp.azurewebsites.net/api/users/authenticate

As a test user, the following will authenticate:

```json
{
    "username": "hspain",
    "passwordHash": "test"
}
```

The response will be similar to this:

```json
{
    "id": 1,
    "username": "hspain",
    "passwordHash": null,
    "isAdmin": false,
    "dateCreated": "2001-01-01T00:00:00",
    "dateLoggedIn": "2001-01-01T00:00:00",
    "stripeToken": " ",
    "customerId": 1,
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYmYiOjE1NDgzNzM5MDAsImV4cCI6MTU0ODk3ODcwMCwiaWF0IjoxNTQ4MzczOTAwfQ.t4wma5INOQ5O4WBpgXprMSkL4HiT4JL7C1udgJI9NeU",
    "customer": null
}
```



You can then use the JWT token provided and pass it as an Authentication: Bearer token for subsequently authenticated requests.  All CRUD functions outside of GETs are authenticated.

#### Continuous Integration/Deployment

This app is configured with continuous integration to a staging server on Azure.  Any commits made to this repository will automatically be built using Azure DevOps and deployed to the Azure Web App with pertinent notifications going out to my email.

<img src="https://i.imgur.com/NQhD95w.png" alt="CDL CI" width="300"/>


### Development Process

#### Modeling

The first step to generating the API was to model the data.  I used a tool called SqlDBM which allowed me to model the database and generate the SQL scripts once finished.  The model looks like the following:

![Data Model](https://i.imgur.com/TjfX1rI.png)

#### Code Skeleton

The next step was to create the skeleton of what the solution would look like by creating basic projects for the Model, Data Access Layer, Tests and API itself.

The code for the model (C#) was generated through the built in scaffolding based on an existing database that was created on Azure.  Entity Framework core was leveraged along with EF Migrations.ci

<img src="https://i.imgur.com/xQT3dLh.png" alt="CDL Directory" width="300"/>


#### Basic Crud

The CRUD controllers were created using a generic repository pattern paired with a generic controller.  This allowed me to create all of the basic crud functions for each of the major object types with only a handful of lines of code each.

This also created a highly decoupled architecture that makes extension and revision across all entities much easier.

#### Membership

The membership layer was created using the built in Authentication middleware that comes with ASP.NET Core.  The JWT authentication scheme was configured in the Startup file and [Authorize] data annotations were added to methods that need the Bearer token headers present for.

Each token expires in 7 days.

#### Testing

Example integration and unit tests were added to show how to test the code outside of the database/api and also how to test the full client as well.