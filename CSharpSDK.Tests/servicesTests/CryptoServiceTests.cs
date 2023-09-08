using Xunit;
using CSharpSDK.Services;

namespace CSharpSDK.Tests
{
    public class CryptoServiceTests
    {
        [Fact]
        public void ComputeHMACSHA256_ReturnsNonNullValue()
        {
            // Arrange
            string key = "testKey";
            string message = "Hello, World!";

            // Act
            string result = CryptoService.ComputeHMACSHA256(key, message);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void ComputeHMACSHA256_DifferentMessages_ReturnDifferentHashes()
        {
            // Arrange
            string key = "testKey";
            string message1 = "Hello, World!";
            string message2 = "Hello, Universe!";

            // Act
            string result1 = CryptoService.ComputeHMACSHA256(key, message1);
            string result2 = CryptoService.ComputeHMACSHA256(key, message2);

            // Assert
            Assert.NotEqual(result1, result2);
        }

        [Fact]
        public void ComputeHMACSHA256_DifferentKeys_ReturnDifferentHashes()
        {
            // Arrange
            string key1 = "testKey1";
            string key2 = "testKey2";
            string message = "Hello, World!";

            // Act
            string result1 = CryptoService.ComputeHMACSHA256(key1, message);
            string result2 = CryptoService.ComputeHMACSHA256(key2, message);

            // Assert
            Assert.NotEqual(result1, result2);
        }

        [Fact]
        public void ComputeHMACSHA256_NullKey_ThrowsArgumentNullException()
        {
            // Arrange
            string nullKey = null;
            string message = "Hello, World!";

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => CryptoService.ComputeHMACSHA256(nullKey, message));
        }

        [Fact]
        public void ComputeHMACSHA256_NullMessage_ThrowsArgumentNullException()
        {
            // Arrange
            string key = "testKey";
            string nullMessage = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => CryptoService.ComputeHMACSHA256(key, nullMessage));
        }

    }
}