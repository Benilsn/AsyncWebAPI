using MyAPI.Business.Entities;
using MyAPI.Model.Users;

namespace MyAPI.Business.Services
{
    public static class Converted
    {
        public static UserViewModel Convert(User user)
        {
            var userViewModel = new UserViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
                Email = user.Email,
                Username = user.Username,
                Password = user.Password
            };
            return userViewModel;
        }

        public static User Convert(UserInputModel userInputModel)
        {
            var user = new User
            {
                FirstName = userInputModel.FirstName,
                LastName = userInputModel.LastName,
                Age = userInputModel.Age,
                Email = userInputModel.Email,
                Username = userInputModel.Username,
                Password = userInputModel.Password
            };
            return user;
        }
    }
}
