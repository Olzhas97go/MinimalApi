# Minimal API Project for Social Media Operations

This project is a **Minimal API** implementation using **ASP.NET Core**. It handles basic social media operations such as user management, posts, follows, and likes. The API interacts with a database to store and retrieve data efficiently.

## Features

- **User Management**: Create and manage users.
- **Posts Management**: Create and manage posts.
- **Social Interactions**:
  - Follow other users.
  - Like posts.

## Tech Stack

- **ASP.NET Core (Minimal API)**
- **Entity Framework Core** (for ORM operations)
- **Dapper** (for micro ORM operations)
- **SQL Database**

---

## Getting Started

Follow these instructions to get a copy of the project up and running on your local machine for development and testing.

### Prerequisites

- **.NET 6 SDK**: Required to build and run the .NET application.
- **An IDE**: (Preferred: Visual Studio 2022 or VSCode).
- **SQL Database**: Fully configured for the project.

### Installation

1. **Clone the repository**:
   ```bash
   git clone https://github.com/yourusername/yourprojectname.git

Navigate to the project directory:

bash
Copy code
cd yourprojectname
Install dependencies: Dependencies should auto-restore with the build process. If needed, run manually:

bash
Copy code
dotnet restore
Configure the database connection: Modify the appsettings.json or use environment variables to set up your connection string for the SQL database.

Apply database migrations (if using EF Core):

bash
Copy code
dotnet ef database update
Ensure your SQL schemes are prepared if using Dapper.

Run the application:

bash
Copy code
dotnet run
The API will be available at:

http://localhost:5000
https://localhost:5001
Usage
Here’s how you can interact with the API:

Create a User
http
Copy code
POST /users
Content-Type: application/json

{
  "username": "newuser",
  "email": "newuser@example.com"
}

Post a New Message
http
Copy code
POST /posts
Content-Type: application/json

{
  "title": "New Post Title",
  "body": "This is the content of the new post.",
  "authorId": 1
}
Retrieve All Posts
http
Copy code
GET /posts
Follow Another User
http
Copy code
POST /follow
Content-Type: application/json

{
  "followerId": 1,
  "followeeId": 2
}
Like a Post
http
Copy code
POST /like
Content-Type: application/json

{
  "postId": 10,
  "userId": 1
}
Testing
For instructions on how to execute the automated tests for this project, refer to the testing/README.md file.

Contributing
We welcome contributions! Please read the CONTRIBUTING.md for details on our code of conduct and the process for submitting pull requests.
