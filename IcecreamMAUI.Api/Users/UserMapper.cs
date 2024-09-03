using IcecreamMAUI.Api.Users.Entities;
using IcecreamMAUI.Shared.Models;

namespace IcecreamMAUI.Api.Users;

public static class UserMapper
{
    public static UserDto ToDto(this User user)
    {
        return new UserDto(
                Id: user.Id,
                Name: user.Name,
                Address: user.Address,
                Email: user.Email);
    }
}
