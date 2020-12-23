using System;
using YourEpic.WebAPI.Models;
namespace YourEpic.WebAPI.Mappers
{
    public class UserModelMapper
    {
        public static UserModel Map(Domain.Models.User user) {
            return new UserModel {
                ID = user.ID,
                Name = user.Name,
                Email = user.Email,
                Role = RoleModelMapper.Map(user.UserRole)
            };
        }

        public static Domain.Models.User Map(UserModel model) {
            return new Domain.Models.User {
                ID = model.ID,
                Name = model.Name,
                Email = model.Email,
                UserRole = RoleModelMapper.Map(model.Role)
            };
        }
    }
}
