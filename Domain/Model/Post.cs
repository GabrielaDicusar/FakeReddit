using System.Text.Json.Serialization;

namespace Shared;

public class Post
{
    public string post  { get; set; }
    public string title { get; set; }
    public User user  { get; set; }
    public int Id  { get; set; }

    // [JsonConstructor]
    // public Post(){}
    public Post(User user, string title, string post )
    {
        this.title = title;
        this.post = post;
        this.user = user;
    }
}