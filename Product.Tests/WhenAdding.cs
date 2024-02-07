namespace Product.Tests
{
    public class WhenAdding
    {
        [Fact]
        public void Should_Be_Zero_On_Empty_String()
        {
            //Arrange
            var sut = new StringCalculator(); //sut stands for 'system under test'

            //Act
            var sum = sut.Add("");

            //Assert
            Assert.Equal(0, sum);
        }
    }
}