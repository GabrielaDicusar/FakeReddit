using System.Security.Claims;
using Domain.DTOs;
using Shared;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    Task<User> Create(UserCreationDto dto);
    public Task LoginAsync(string username, string password);
    public Task LogoutAsync();
    
    //used to provide authentication state details to the Blazor auth framework, whenever the app needs to know about who is logged in
    public Task<ClaimsPrincipal> GetAuthAsync();
    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
    
}