using Shared;

namespace FileData;

//This class holds information before storing it in the JSON file
public class DataContainer
{
    public ICollection<User> Users { get; set; }
    public ICollection<Post> Posts { get; set; }
}