Minimal API Project for Social Media Operations
This project is a Minimal API implementation using ASP.NET Core. It is designed to handle basic social media operations like user management, posts, follows, and likes. The API interacts with a database to store and retrieve data efficiently.

Features
User Management: Create new users.
Posts Management: Create and view posts.
Social Interactions:
Follow other users.
Like posts.
Tech Stack
ASP.NET Core (Minimal API)
Entity Framework Core (for database operations)
Dapper (for micro ORM operations)
SQL Database
Getting Started
These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

Prerequisites
.NET 6 SDK
An IDE (Visual Studio 2022, VSCode, etc.)
A SQL database set up and accessible
Installing
Clone the repository

Use Git or checkout with SVN using the web URL:

bash


git clone https://github.com/yourusername/yourprojectname.git
Navigate to the project directory

bash


cd yourprojectname
Install dependencies

Dependencies are handled via NuGet, and they should restore automatically when you build the project. If you need to manually restore them, run:

bash


dotnet restore
Set up your database connection

Modify the connection string in the appsettings.json file or set up an environment variable to point to your SQL database.

Apply migrations (if using EF Core)

Update the database with the latest migrations:

bash


dotnet ef database update
If you're using Dapper, ensure your database schema matches what the Dapper queries expect.

Run the project

Run the project using:

bash


dotnet run
This command will start a web server, and the API will be available typically on http://localhost:5000 or https://localhost:5001.

Usage
Here is how you can interact with the API using HTTP requests:

Create User

http


POST /users
Content-Type: application/json

{
  "username": "newuser",
  "email": "newuser@example.com"
}
Create Post

http


POST /posts
Content-Type: application/json

{
  "title": "New Post Title",
  "body": "This is a new post body.",
  "authorId": 1
}
Get All Posts

http


GET /posts
Follow User

http


POST /follow
Content-Type: application/json

{
  "followerId": 1,
  "followeeId": 2
}
Like Post

http


POST /like
Content-Type: application/json

{
  "postId": 10,
  "userId": 1
}
Testing
Refer to the README in the test directory for instructions on how to run automated tests for this project.

Contributing
Please read CONTRIBUTING.md for details on our code of conduct, and the process for submitting pull requests to us.