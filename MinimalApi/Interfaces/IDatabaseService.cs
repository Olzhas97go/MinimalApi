using MinimalApi.Models;

namespace MinimalApi.Interfaces;
public interface IDatabaseService
{
    Task<int> CreateNewUser(User user);
    Task<int> CreateNewPost(Post post);
    Task<IEnumerable<Post>> GetAllPosts();
    Task<bool> FollowUser(int followerId, int followeeId);
    Task<bool> LikePost(int postId, int userId);
}