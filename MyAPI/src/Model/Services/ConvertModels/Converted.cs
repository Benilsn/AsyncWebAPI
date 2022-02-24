using MyAPI.src.Model.Entities.User;

namespace MyAPI.src.Model.Services.ConvertModels
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
                Email = user.Email

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

            };
            return user;
        }
    }
}
