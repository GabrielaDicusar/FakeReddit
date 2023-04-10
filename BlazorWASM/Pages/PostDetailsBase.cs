using HttpClients.ClientInterfaces;
using Microsoft.AspNetCore.Components;
using Shared;

namespace BlazorWasm.Pages;

public class PostDetailsBase : ComponentBase
{
    [Parameter]
    public int Id { get; set; }
    [Inject]
    public IPostService PostService { get; set; }
    public ICollection<Post> Posts { get; set; }
    public Post Post { get; set; }
    
    public string ErrorMessage { get; set; }

    protected override async Task OnInitializedAsync()
    {
        try
        {
            Posts = await PostService.GetAsync(null, null, null, Id);
            Post = Posts.First();
            Posts.Clear();
        }
        catch(Exception ex)
        {
            ErrorMessage = ex.Message;
        }
    }
}