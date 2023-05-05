using Application.DaoInterfaces;
using Domain.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared;

namespace EfcDataAccess;

public class PostEfcDao : IPostDao
{
    
    private readonly PostContext context;

    public PostEfcDao(PostContext pc)
    {
        context = pc;
    }
    public async Task<Post> CreateAsync(Post post)
    {
        EntityEntry<Post> newPost = await context.Posts.AddAsync(post);
        await context.SaveChangesAsync();
        return newPost.Entity;
    }

    public async Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchPostParameters)
    {
        IQueryable<Post> result = context.Posts.Include(post => post.user).AsQueryable();
        
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
        
        List<Post> result2 = await result.ToListAsync();

        return result2;
    }

    public async Task<IEnumerable<Post>> GetAllPosts()
    {
        IQueryable<Post> result = context.Posts.Include(post => post.user).AsQueryable();
        List<Post> result2 = await result.ToListAsync();
        return result2;
    }
}