using System.Text.Json.Serialization;

namespace Shared;

public class Post
{
    public string post  { get; set; }
    public User user  { get; set; }
    public int Id  { get; set; }

    // [JsonConstructor]
    // public Post(){}
    public Post(User user, string post )
    {
        this.post = post;
        this.user = user;
    }
}