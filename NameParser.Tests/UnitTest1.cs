using System;
using NameParser;
using Xunit;

namespace NameParser.Tests
{
    public class WhenParsingNameInformation
    {
        [Fact]
        public void OneNameIsEnteredFirstNameIsPopulated()
        {
            //Arrange 
            var name = "Zandaya";
            var nameParser = new Parser();

            //Act
            var result = nameParser.ParseName(name);

            //Assert
            Assert.Equal(result.FirstName, "Zandaya");
        }

        [Theory]
        [InlineData("Steve Jones", "Steve", "Jones")]
        [InlineData("Mary Barnes-Jones", "Mary", "Barnes-Jones")]
        // [Fact]
        public void TwoNamesEnteredFirstAndLastNameArePopulated(string nameToTest, string expectedFirstName, 
                                                                string expectedLastName)
        {
            //Arrange
            // var name = "Steve Jones";
            var nameParser = new Parser();

            //Act
            var result = nameParser.ParseName(nameToTest);

            //Assert
            Assert.Equal(result.FirstName, expectedFirstName);
            Assert.Equal(result.LastName, expectedLastName);
        }

        [Theory]
        [InlineData("Steve L. Jones", "Steve", "L.", "Jones")]
        [InlineData("Steve X Jones", "Steve", "X", "Jones")]
        // [Fact]
        public void FirstAndLastNameArePopulatedPlusMiddleInitial(string nameToTest, string expectedFirstName, 
                                                                  string expectedMiddleInitial, string expectedLastName)
        {
            //Arrange
            // var name = "Steve Jones";
            var nameParser = new Parser();

            //Act
            var result = nameParser.ParseName(nameToTest);

            //Assert
            Assert.Equal(result.FirstName, expectedFirstName);
            Assert.Equal(result.MiddleInitial, expectedMiddleInitial);
            Assert.Equal(result.LastName, expectedLastName);
        }
    }
}
