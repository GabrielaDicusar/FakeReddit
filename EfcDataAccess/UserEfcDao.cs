using Application.DaoInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared;

namespace EfcDataAccess;

public class UserEfcDao : IUserDao
{

    private readonly PostContext context;

    public UserEfcDao(PostContext pc)
    {
        context = pc;
    }

    public async Task<User> CreateAsync(User user)
    {
        EntityEntry<User> newUser = await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return newUser.Entity;
    }

    public async Task<User?> GetByUsernameAsync(string userName)
    {
        User? existing = await context.Users.FirstOrDefaultAsync(u =>
            u.UserName.ToLower().Equals(userName.ToLower())
        );
        return existing;
    }

    public async Task<User?> GetByIdAsync(object ownerId)
    {
        User? user = await context.Users.FindAsync(ownerId);
        return user;
    }
}