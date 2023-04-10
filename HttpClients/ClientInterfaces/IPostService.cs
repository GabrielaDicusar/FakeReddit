using Domain.DTOs;
using Shared;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task CreateAsync(PostCreationDto dto);
    Task<ICollection<Post>> GetAsync(
        string? userName, 
        int? userId,
        string? titleContains
    );
}