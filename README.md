# Wall sticker shop
desc according teacher

## Technologies Used

- C#
- .NET Core

## Installation

1. Clone the repository to your local machine.
2. Open the project in your preferred IDE.
3. Build and run the application.

## Usage

1. Open a web browser or use swagger
2. Navigate to the API endpoints to interact with the application.

## API Endpoints
#Users

| HTTP Method | Endpoint                | Description                   |
|-------------|-------------------------|-------------------------------|
| GET         | /api/users/{id}         | Get a specific user by ID     |
| POST        | /api/users              | logIn                         |
| POST        | /api/users              | register                      |
| PUT         | /api/users/{id}         | Update an existing user       |

#Products

| HTTP Method | Endpoint                | Description                   |
|-------------|-------------------------|-------------------------------|
| GET         | /api/Products           | Get all products              |
| GET         | /api/Products/search    | Get products by search        |
| POST        | /api/Products           | Create a new product          |

#Categories

| HTTP Method | Endpoint                | Description                   |
|-------------|-------------------------|-------------------------------|
| GET         |/api/Categories          | Get all categories            |
| POST        |/api/Categories          | Create a new category         |

#Orders


| HTTP Method | Endpoint                | Description                   |
|-------------|-------------------------|-------------------------------|
| GET         |/api/Orders/{id}         |Get a specific order by ID     |
| POST        |/api/Orders              | Create a new order            |

#passwords

| HTTP Method | Endpoint                | Description                   |
|-------------|-------------------------|-------------------------------|
| POST        |/api/passwords           | Create a new password         |

## Dependencies

- ASP.NET Core 
- Entity Framework Core 



