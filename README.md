Minimal API Project for Social Media Operations
This project is a Minimal API implementation using ASP.NET Core. It is designed to handle basic social media operations such as user management, posts, follows, and likes. The API interacts with a database to store and retrieve data efficiently.

Features
User Management: Create new users.
Posts Management: Create and manage posts.
Social Interactions:
Ability to follow other users.
Ability to like posts.
Tech Stack
ASP.NET Core (Minimal API)
Entity Framework Core (for ORM operations)
Dapper (for micro ORM operations)
SQL Database
Getting Started
These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

Prerequisites
.NET 6 SDK: Required for building and running the .NET applications.
An IDE (Preferred: Visual Studio 2022, VSCode).
A fully configured SQL database.
Installation
Clone the repository

bash


git clone https://github.com/yourusername/yourprojectname.git
Navigate to the project directory

bash


cd yourprojectname
Install dependencies

Dependencies should auto-restore with the build process. If needed manually, run:

bash


dotnet restore
Configure the database connection

Modify the appsettings.json or use environment variables to set up your connection string to the SQL database.

Apply database migrations (if using EF Core)

bash


dotnet ef database update
Ensure your SQL schemes are prepared if using Dapper.

Run the application

bash


dotnet run
The API will be available typically on http://localhost:5000 or https://localhost:5001.

Usage
Interacting with the API
Create a User

http


POST /users
Content-Type: application/json

{
  "username": "newuser",
  "email": "newuser@example.com"
}
Post a new message

http


POST /posts
Content-Type: application/json

{
  "title": "New Post Title",
  "body": "This is the content of the new post.",
  "authorId": 1
}
Retrieve all posts

http


GET /posts
Follow another user

http


POST /follow
Content-Type: application/json

{
  "followerId": 1,
  "followeeId": 2
}
Like a post

http


POST /like
Content-Type: application/json

{
  "postId": 10,
  "userId": 1
}
Testing
Check out the testing/README.md for instructions on how to execute the automated tests for this project.

Contributing
We welcome contributions! Please read CONTRIBUTING.md for details on our code of conduct and the process for submitting pull requests to us.

Be sure to update the URLs and commands with specifics from your project environment. This README gives a comprehensive, clean, and straightforward instruction set for anyone who would be using or contributing to your project.
