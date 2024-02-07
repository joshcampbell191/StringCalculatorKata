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

        [Theory]
        [InlineData("1", 1)]
        [InlineData("10", 10)]
        public void Should_Be_Number_On_Single_Number(string numbers, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var sum = sut.Add(numbers);

            //Assert
            Assert.Equal(expected, sum);
        }

        [Theory]
        [InlineData("1+1", 2)]
        [InlineData("12+34", 46)]
        public void Should_Return_Sum_On_Plus_Delimited_Numbers(string numbers, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var sum = sut.Add(numbers);

            //Assert
            Assert.Equal(expected, sum);
        }

        [Theory]
        [InlineData("1,2,3", 6)]
        [InlineData("1,1,1,1,1", 5)]
        public void Should_Return_Sum_On_Comma_Delimited_Numbers(string numbers, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var sum = sut.Add(numbers);

            //Assert
            Assert.Equal(expected, sum);
        }

        [Theory]
        [InlineData("1\n2", 3)]
        public void Should_Return_Sum_On_New_Line_Delimited_Numbers(string numbers, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var sum = sut.Add(numbers);

            //Assert
            Assert.Equal(expected, sum);
        }

        [Theory]
        [InlineData("//;1;2", 3)]
        [InlineData("//[***]1***2***3", 6)]
        [InlineData("//[*][%]1*2%3", 6)]
        [InlineData("//[***][%%%]1***2%%%3", 6)]
        public void Should_Return_Sum_On_Custom_Delimited_Numbers(string numbers, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var sum = sut.Add(numbers);

            //Assert
            Assert.Equal(expected, sum);
        }

        [Theory]
        [InlineData("-1", "Negatives not allowed (-1)")]
        [InlineData("-1,-2", "Negatives not allowed (-1,-2)")]
        public void Should_Throw_On_Negative_Number(string numbers, string expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            Action act = () => sut.Add(numbers);

            //Assert
            var exception = Assert.Throws<InvalidOperationException>(act);
            Assert.Equal(expected, exception.Message);
        }

        [Theory]
        [InlineData("1,1005", 1)]
        public void Should_Ignore_Numbers_Greater_Than_1000(string numbers, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Act
            var sum = sut.Add(numbers);

            //Assert
            Assert.Equal(expected, sum);
        }
    }
}