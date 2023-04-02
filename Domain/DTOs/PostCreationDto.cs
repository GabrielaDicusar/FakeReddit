using System.Text.Json.Serialization;

namespace Domain.DTOs;
public class PostCreationDto
{
    public int UserId { get; }
    public string Title { get; }

    public PostCreationDto(int userId, string title)
    {
        UserId = userId;
        Title = title;
    }
}