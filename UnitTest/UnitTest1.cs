using BlazorEcommerce.Server.Services.AuthService;

namespace UnitTest
{
    public class UnitTest1
    {
        private readonly IAuthService _service;

        public UnitTest1(IAuthService service)
        {
            _service = service;
        }

        [Fact]
        public void Test1()
        {
            // Arrange
            var expected = "input test";



            // Act
            _service.test(out string actual);



            // Assert
            Assert.Equal(expected, actual);


        }
    }
}
