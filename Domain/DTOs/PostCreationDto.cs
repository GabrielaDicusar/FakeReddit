using System.Text.Json.Serialization;

namespace Domain.DTOs;
public class PostCreationDto
{
    public int UserId { get; }
    public string Title { get; }
    public string Post { get; }

    public PostCreationDto(int userId, string title, string post)
    {
        UserId = userId;
        Title = title;
        Post = post;
    }
}