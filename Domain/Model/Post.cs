namespace Shared;

public class Post
{
    public string post;
    public User user;

    public Post(string post, User user)
    {
        this.post = post;
        this.user = user;
    }
}