using Moq;
using RoadTripPlannerApp.Model;
using RoadTripPlannerApp.Services;
using RoadTripPlannerApp.ViewModel;

namespace RoadTripPlannerAppTest
{
    public class ProfileTest
    {

        [Fact]
        public async Task LoadUserDetails_OnNavigate_DetailsDisplayed()
        {
            await Task.Delay(1);
            //// Arrange
            //var databaseService = new DatabaseMockService();
            //var alert = new Mock<IAlertService>();
            //UserModel user = new UserModel() { Id = 0, Email = "user1@mail.com", Username = "user1", Password = "password1" };
            //await databaseService.LogInUser(user);
            //var profileViewModel = new ProfileViewModel(databaseService, alert.Object);
            //// Act
            //profileViewModel.LoadUserDetails();
            //// Assert
            //Assert.Equal(user.Email, profileViewModel.Email);
            //Assert.Equal(user.Username, profileViewModel.Username);
            //Assert.Equal(user.Password, profileViewModel.Password);
        }
        [Fact]
        public async Task UpdateUserDetails_ValidInput_SuccessfulUpdate()
        {
            await Task.Delay(1);
        }
        [Fact]
        public async Task UpdateUserDetails_InvalidInput_DetailsNotModified()
        {
            await Task.Delay(1);
        }
        [Fact]
        public async Task LogOut_CLicked_UserLoggedOut()
        {
            await Task.Delay(1);
        }
    }
}
