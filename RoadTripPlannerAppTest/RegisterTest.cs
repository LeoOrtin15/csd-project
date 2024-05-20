using RoadTripPlannerApp.ViewModel;
using RoadTripPlannerApp.Services;
using RoadTripPlannerApp.Model;
using Moq;

namespace RoadTripPlannerAppTest
{
    public class RegisterTest
    {
        [Fact]
        public async Task Register_ValidInput_AccountCreated()
        {
            // Arrange
            var databaseService = new DatabaseMockService();
            var alert = new Mock<IAlertService>();
            var registerViewModel = new RegisterViewModel(databaseService, alert.Object);
            registerViewModel.Email = "test";
            registerViewModel.Username = "test";
            registerViewModel.Password = "test";
            // Act
            await registerViewModel.RegisterCommand.ExecuteAsync(null);
            // Assert
            Assert.NotNull(await databaseService.GetUser("test"));
        }
        [Fact]
        public async Task Register_InvalidInput_AccountNotCreated()
        {
            // Arrange
            var databaseService = new DatabaseMockService();
            var alert = new Mock<IAlertService>();
            var registerViewModel = new RegisterViewModel(databaseService, alert.Object);
            registerViewModel.Email = "test";
            registerViewModel.Username = "user1";
            registerViewModel.Password = "test";
            // Act
            await registerViewModel.RegisterCommand.ExecuteAsync(null);
            // Assert
            Assert.Equivalent(await databaseService.GetUser("test"), new UserModel());
        }
    }
}
