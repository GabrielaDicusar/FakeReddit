using Domain.DTOs;
using Shared;

namespace Application.DaoInterfaces;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);
    Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchPostParameters);
    Task<IEnumerable<Post>> GetAllPosts();
}