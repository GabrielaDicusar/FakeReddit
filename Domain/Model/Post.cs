using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Shared;

public class Post
{
    
    public int Id  { get; set; }
    public string post  { get; private set; }
    public string title { get; private set; }
    public User user  { get; set; }

    // [JsonConstructor]
    // public Post(){}
    public Post(User user, string title, string post )
    {
        this.title = title;
        this.post = post;
        this.user = user;
    }
    
    public Post(){}
    
    
}