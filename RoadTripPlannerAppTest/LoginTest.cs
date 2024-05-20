using Moq;
using RoadTripPlannerApp.Model;
using RoadTripPlannerApp.Services; 
using RoadTripPlannerApp.ViewModel;

namespace RoadTripPlannerAppTest
{
    public class LoginTest
    {
        [Fact]
        public async Task Login_ValidInput_SuccessfulLogin()
        {
            //// Arrange
            //var databaseService = new DatabaseMockService();
            //var alert = new Mock<IAlertService>();
            //var loginViewModel = new LoginViewModel(databaseService, alert.Object);
            //loginViewModel.Username = "user1"; // Registered user
            //loginViewModel.Password = "password1"; // Correct password
            //// Act
            //await loginViewModel.LoginCommand.ExecuteAsync(null);
            //// Assert
            //Assert.NotNull(await databaseService.GetLoggedInUser());
        }
        [Fact]
        public async Task Login_NotRegisteredUser_UnableToLogin()
        {
            // Arrange
            var databaseService = new DatabaseMockService();
            var alert = new Mock<IAlertService>();
            var loginViewModel = new LoginViewModel(databaseService, alert.Object);
            loginViewModel.Username = "test"; //Unregistered user
            loginViewModel.Password = "test";
            // Act
            await loginViewModel.LoginCommand.ExecuteAsync(null);
            // Assert
            Assert.Equivalent(await databaseService.GetLoggedInUser(), new UserModel());
        }
        [Fact]
        public async Task Login_IncorrectPassword_UnableToLogin()
        {
            // Arrange
            var databaseService = new DatabaseMockService();
            var alert = new Mock<IAlertService>();
            var loginViewModel = new LoginViewModel(databaseService, alert.Object);
            loginViewModel.Username = "user1"; //Registered user
            loginViewModel.Password = "test"; // Incorrect password
            // Act
            await loginViewModel.LoginCommand.ExecuteAsync(null);
            // Assert
            Assert.Equivalent(await databaseService.GetLoggedInUser(), new UserModel());
        }
    }
}
