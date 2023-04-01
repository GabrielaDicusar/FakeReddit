namespace Domain.DTOs;
//This is just some kind of blue print for the actual user. The UserController will use the UserLogic to create the 3D version of it
public class UserCreationDto
{
    public string UserName{ get; set; }

    public UserCreationDto(string userName)
    {
        UserName = userName;
    }
}