using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Shared;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao postDao;
    private readonly IUserDao userDao;

    public PostLogic(IPostDao postDao, IUserDao userDao)
    {
        this.postDao = postDao;
        this.userDao = userDao;
    }


    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        User? user = await userDao.GetByIdAsync(dto.UserId);
        if (user == null)
        {
            throw new Exception($"User with id {dto.UserId} was not found.");
        }

        ValidatePost(dto);
        Post post = new Post(user, dto.Title, dto.Post );
        Post created = await postDao.CreateAsync(post);
        return created;
    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchPostParameters)
    {
        return postDao.GetAsync(searchPostParameters);
    }

    public Task<IEnumerable<Post>> GetAllPosts()
    {
        return postDao.GetAllPosts();
    }

    private void ValidatePost(PostCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title)) throw new Exception("Title cannot be empty.");
        // other validation stuff
    }
}