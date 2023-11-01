using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using StringManipulation;
using Moq;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;

namespace StringManipulation.Tests
{
    public class StringOperationsTest
    {
        [Fact]
        public void ConcatenateStringsTest()
        {
            // Arrange
            var strOperations = new StringOperations();

            // act
            var result = strOperations.ConcatenateStrings("Hello", "Jamecho");

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal("Hello Jamecho", result);
        }

        [Fact]
        public void IsPalindrome_True()
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.IsPalindrome("ama");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsPalindrome_False()
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.IsPalindrome("qwe");

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void QuantintyInWordsTest()
        {
            // Arrange 
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.QuantintyInWords("cat", 10);

            // Assert
            Assert.StartsWith("ten", result);
            Assert.EndsWith("cats", result);
            Assert.Contains("cat", result);
        }

        [Fact]
        public void GetStringLength_nullExceptionTest()
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act


            // Assert
            Assert.ThrowsAny<ArgumentNullException>(() => strOperations.GetStringLength(null));
        }

        [Fact]
        public void GetStringLengthTest()
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.GetStringLength("asd");

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void GetStringLength_inputMoreThan0Test()
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.GetStringLength("asd");

            // Assert
            Assert.True(result > 0);
        }

        [Fact]
        public void RemoveWhitespaceTest()
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.RemoveWhitespace("a    b c     d  e    f ");

            // Assert
            Assert.Equal("abcdef", result);
        }

        [Fact]
        public void TruncateString_ExceptionTest()
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act


            // Asert
            Assert.ThrowsAny<ArgumentOutOfRangeException>(() => strOperations.TruncateString("this is a big test", 0));
        }

        [Fact(Skip = "Test not valid at the moment, TICKET: PQEK01")]
        public void TruncateStringTest()
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.TruncateString("this is a great challenge", 9);

            // Asert
            Assert.Equal("this is a", result);
        }

        [Theory]
        [InlineData("V", 5)]
        [InlineData("III", 3)]
        [InlineData("X", 10)]
        // [InlineData("P", -1)]
        public void FromRomanToNumberTest(string romanNumber, int expected)
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var res = strOperations.FromRomanToNumber(romanNumber);

            // Assert
            Assert.Equal(expected, res);

        }

        [Theory]
        [InlineData("ama", true)]
        [InlineData("other", false)]
        public void IsPalindromeTest(string word, bool expected)
        {
            // Arrange
            var strOperations = new StringOperations();

            // Act
            var result = strOperations.IsPalindrome(word);

            //  Assert
            if (expected)
            {
                Assert.True(result);
            }
            else
            {
                Assert.False(result);
            }
        }

        [Fact]
        public void CountOcurrencesTest()
        {
            // the CountOcurrences method, uses a logger that is mocked by mockLogger 
            var mockLogger = new Mock<ILogger<StringOperations>>();
            var strOperations = new StringOperations(mockLogger.Object);

            var result = strOperations.CountOccurrences("Hello platzi", 'l');

            Assert.Equal(3, result);
        }

        [Fact]
        public void ReadFile()
        {
            var strOperations = new StringOperations();

            // this is mocking the reading of the file 
            var mockFileReader = new Mock<IFileReaderConector>();
            mockFileReader.Setup(p => p.ReadString(It.IsAny<string>())).Returns("Reading file");

            var result = strOperations.ReadFile(mockFileReader.Object, "file2.txt");

            Assert.Equal("Reading file", result);
        }


    }
}
