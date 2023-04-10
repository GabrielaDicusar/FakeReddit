using System.Collections;
using Application.DaoInterfaces;
using Domain.DTOs;
using Shared;

namespace FileData.DAOs;

public class PostFileDao : IPostDao
{
    private readonly FileContext context;

    public PostFileDao(FileContext context)
    {
        this.context = context;
    }
    
    public Task<Post> CreateAsync(Post post)
    {
        int postId = 1;
        if (context.Posts.Any())
        {
            postId = context.Posts.Max(p => p.Id);
            postId++;
        }

        post.Id = postId;

        context.Posts.Add(post);
        context.SaveChanges();

        return Task.FromResult(post);
        
    }

    public async Task<IEnumerable<Post>> GetAllPosts()
    {
        var result =  context.Posts.AsEnumerable();
        result = context.Posts;
        return result;
    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchPostParameters)
    {
        var result =  context.Posts.AsEnumerable();
        
        if (!string.IsNullOrEmpty(searchPostParameters.Username))
        {
            // we know username is unique, so just fetch the first
            result = context.Posts.Where(p=>
                p.user.UserName.Equals(searchPostParameters.Username, StringComparison.OrdinalIgnoreCase));
        }
        
        
        if (searchPostParameters.UserId != null)
        {
            result = result.Where(p => p.user.Id == searchPostParameters.UserId);
        } 
        
        if (searchPostParameters.PostId != null)
        {
            result = result.Where(p => p.Id == searchPostParameters.PostId);
        }
        
        if (!string.IsNullOrEmpty(searchPostParameters.TitleContains))
        {
            result = result.Where(p =>
                p.post.Contains(searchPostParameters.TitleContains, StringComparison.OrdinalIgnoreCase));
        }

        return Task.FromResult(result);
    }
}