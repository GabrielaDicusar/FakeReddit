namespace Domain.DTOs;

public class SearchPostParametersDto
{
    public string? Username  { get;  }
    public int? UserId  { get; }
    public string? TitleContains  { get; }
    public int? PostId { get; }

    public SearchPostParametersDto(string? username, int? userId, string? titleContains,int? postId)
    {
        Username = username;
        UserId = userId;
        TitleContains = titleContains;
        PostId = postId;
    }
}