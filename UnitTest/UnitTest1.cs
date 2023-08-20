namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void ValidateForTrue()
        {
            //ARRANGE
            var mocAddViewModel = new MockViewModel
            {
                Title = "DemoBook",
                Description = "What an awesome book!",
                Author = "John Doe",
                Pages = 120
            };

            //ACT
            var isValid = mocAddViewModel.Validate();

            //ASSERT
            Assert.True(isValid);
        }

        [Fact]
        public void ValidateForFalse()
        {
            //ARRANGE
            var mocAddViewModel = new MockViewModel
            {
                Title = "",
                Description = "What an awesome book!",
                Author = "John Doe",
                Pages = 5
            };

            //ACT
            var isValid = mocAddViewModel.Validate();

            //ASSERT
            Assert.False(isValid);
        }
    }
}