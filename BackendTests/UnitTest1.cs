using Xunit;

namespace BackendTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            var expected = 4;
            var actual = 2 + 2;

            // Act & Assert
            Assert.Equal(expected, actual);  // This will pass because 2 + 2 = 4
        }
    }
}
