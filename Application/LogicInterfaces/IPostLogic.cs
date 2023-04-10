using Domain.DTOs;
using Shared;

namespace Application.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreateAsync(PostCreationDto dto);
    Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchPostParameters);
    Task<IEnumerable<Post>> GetAllPosts();
    
}