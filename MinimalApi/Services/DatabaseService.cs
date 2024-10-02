using Dapper;
using MinimalApi.Data;
using MinimalApi.Interfaces;
using MinimalApi.Models;

namespace MinimalApi.Services;

public class DatabaseService : IDatabaseService
{
    private readonly DapperContext _db;

    public DatabaseService(DapperContext db)
    {
        _db = db;
    }

    public async Task<int> CreateNewUser(User user)
    {
        using var conn = _db.CreateConnection();
        var sql = @"INSERT INTO users (username, email) VALUES (@Username, @Email) RETURNING id;";
        return await conn.ExecuteScalarAsync<int>(sql, user);
    }
    
    public async Task<int> CreateNewPost(Post post)
    {
        using var conn = _db.CreateConnection();
        var sql = @"INSERT INTO posts (title, body, author_id) VALUES (@Title, @Body, @AuthorId) RETURNING id;";
        return await conn.ExecuteScalarAsync<int>(sql, post);
    }
    
    public async Task<IEnumerable<Post>> GetAllPosts()
    {
        using var conn = _db.CreateConnection();
        var sql = @"SELECT * FROM posts;";
        return await conn.QueryAsync<Post>(sql);
    }
    
    public async Task<bool> FollowUser(int followerId, int followeeId)
    {
        using var conn = _db.CreateConnection();
        var sql = @"INSERT INTO follows (follower_id, followee_id) VALUES (@FollowerId, @FolloweeId);";
        return await conn.ExecuteAsync(sql, new { FollowerId = followerId, FolloweeId = followeeId }) > 0;
    }
    
    public async Task<bool> LikePost(int postId, int userId)
    {
        using var conn = _db.CreateConnection();
        var sql = @"INSERT INTO post_likes (post_id, user_id) VALUES (@PostId, @UserId);";
        return await conn.ExecuteAsync(sql, new { PostId = postId, UserId = userId }) > 0;
    }
}