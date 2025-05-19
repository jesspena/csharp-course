using Generics;

namespace Test.Generics
{
    public class TestSafeBox
    {
        // TODO: Add positive scenario

        [Fact]
        public void SafeBox_ShouldThrowIfNull()
        {
            Assert.Throws<ArgumentNullException>(() => new SafeBox<string>(null));
        }

        [Fact]
        public void SafeBox_ShouldStoreValueCorrectly()
        {
            var safeBox = new SafeBox<string>("hola");
            Assert.Equal("hola", safeBox.Value);
        }
    }
}
