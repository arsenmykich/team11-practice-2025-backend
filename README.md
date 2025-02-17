README: ASP.NET Core API Web Application
======================================

Project Name: Royale Cinema

Description:
------------
This project is a web application built using ASP.NET Core API. It provides backend services for cinema theatre website with movie, actor, and director management.

Features:
---------
- RESTful API with endpoints for [movies, actors, directors, etc.].
- JSON-based request and response format.
- Many-to-many relationship handling for entities like [e.g., movies and actors].

Technologies Used:
-------------------
- .NET 8 
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL

Prerequisites:
--------------
- .NET SDK installed (check with `dotnet --version`)
- Database server running (PostgreSQL)

Setup Instructions:
--------------------
1. Clone the repository:
   ```bash
   git clone [https://github.com/yourusername/your-repo.git](https://github.com/arsenmykich/team11-practice-2025-backend.git)
   cd your-repo
   ```

2. Configure the "secrets" file:
   ```json
   {
    "JwtSettings": {
      "SecretKey": "your_secret_key"
  
    },
  
    "ConnectionStrings": {
      "CinemaDb": "your_connection_string"
    }
  }
   ```

3. Apply database migrations:
   ```bash
   dotnet ef database update
   ```

4. Run the application:
   ```bash
   dotnet run --launch-profile https
   ```

5. Access the API at `http://localhost:5273` or `https://localhost:7230`.

API Endpoints:
---------------
- `GET /api/movie` - Get all movies.
- `POST /api/movie` - Add a new movie.
- `GET /api/movie/{id}` - Get movie by ID.
- `PUT /api/movie/{id}` - Update movie details.
- `DELETE /api/movie/{id}` - Delete movie.

Sample JSON Requests:
----------------------
**Create Movie:**
```json
"movies": [
    {
      "id": 1,
      "filmName": "Inception",
      "description": "A mind-bending thriller",
      "trailer": "https://youtu.be/YoHD9XEInc0?si=Wt8c3QPHAsK5IXTI",
      "duration": 148,
      "ageRating": 13,
      "releaseDate": "2010-07-16T00:00:00Z",
      "posterPath": "/posters/inception.jpg",
      "backgroundImagePath": "/backgrounds/inception.jpg",
      "voteAverage": 8.8,
      "voteCount": 20000,
      "directorId": 3,
      "genres": [
        1,
        3
      ],
      "actors": [
        1
      ]
    }
```

Testing:
--------
You can test the API using tools like Postman or Swagger UI (available at `/swagger` when the app is running).

Troubleshooting:
----------------
- If the app fails to connect to the database, verify connection string settings.
- Check if migrations are applied correctly.

Contributing:
-------------
- Fork the repository.
- Create a new feature branch.
- Commit changes with descriptive messages.
- Open a pull request.
