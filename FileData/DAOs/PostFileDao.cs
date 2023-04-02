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

    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchPostParameters)
    {
        Console.WriteLine("Got to PostFileDao");
        var result =  context.Posts.AsEnumerable();
        Console.WriteLine("Initiated the enumerable");
        if (!string.IsNullOrEmpty(searchPostParameters.Username))
        {
            Console.WriteLine("Got in if statement 1");
            // we know username is unique, so just fetch the first
            result = context.Posts.Where(p=>
                p.user.UserName.Equals(searchPostParameters.Username, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Passed in if statement 1");
        }
        
        
        if (searchPostParameters.UserId != null)
        {
            Console.WriteLine("Got in if statement 2");
            result = result.Where(p => p.user.Id == searchPostParameters.UserId);
            Console.WriteLine("Passed in if statement 2");
        }
        
        if (!string.IsNullOrEmpty(searchPostParameters.TitleContains))
        {
            Console.WriteLine("Got in if statement 3");
            result = result.Where(p =>
                p.post.Contains(searchPostParameters.TitleContains, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Passed in if statement 3");
        }

        return Task.FromResult(result);
    }
}