using System.Runtime.CompilerServices;
using Dapper;
using MinimalApi.Data;
using MinimalApi.Interfaces;
using MinimalApi.Models;
using MinimalApi.Services;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddScoped<IDatabaseService, DatabaseService>();
        
        builder.Services.AddSingleton<DapperContext>();
        
        var app = builder.Build();
        // Creating a new user
        app.MapPost("/users", async (User user, IDatabaseService dbService) =>
        {
            try
            {
                var newUserId = await dbService.CreateNewUser(user);
                return Results.Created($"/users/{newUserId}", user);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        });
        // Creating a new post
        app.MapPost("/posts", async (Post post, IDatabaseService dbService) =>
        {
            try
            {
                var newPostId = await dbService.CreateNewPost(post);
                return Results.Created($"/posts/{newPostId}", post);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        });
        
        // Getting all posts
        app.MapGet("/posts", async (IDatabaseService dbService) =>
        {
            try
            {
                var posts = await dbService.GetAllPosts();
                return Results.Ok(posts);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        });
        
        // Following another user
        app.MapPost("/follow", async (Follow follow, IDatabaseService dbService) =>
        {
            try
            {
                var isFollowed = await dbService.FollowUser(follow.FollowerId, follow.FolloweeId);
                return isFollowed ? Results.Ok() : Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        });
        
        // Liking a post
        app.MapPost("/like", async (Like like, IDatabaseService dbService) =>
        {
            try
            {
                var isLiked = await dbService.LikePost(like.PostId, like.UserId);
                return isLiked ? Results.Ok() : Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        });
        app.Run();
    }
}