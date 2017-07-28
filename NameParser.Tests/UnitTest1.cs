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
            var nameParser = new Parser();

            //Act
            var result = nameParser.ParseName(nameToTest);

            //Assert
            Assert.Equal(result.FirstName, expectedFirstName);
            Assert.Equal(result.MiddleInitial, expectedMiddleInitial);
            Assert.Equal(result.LastName, expectedLastName);
        }


        [Theory]
        [InlineData("Bob Marley Jr.", "Bob", "Marley", "Jr.")]
        [InlineData("Bob Marley Esq", "Bob", "Marley", "Esq")]
        // [Fact]
        public void FirstAndLastNameArePopulatedPlusSuffix(string nameToTest, string expectedFirstName, 
                                                           string expectedLastName, string expectedSuffix)
        {
            //Arrange
            var nameParser = new Parser();

            //Act
            var result = nameParser.ParseName(nameToTest);

            //Assert
            Assert.Equal(result.FirstName, expectedFirstName);
            Assert.Equal(result.LastName, expectedLastName);
            Assert.Equal(result.Suffix, expectedSuffix);
        }


        [Theory]
        [InlineData("Mr. Bob Michaels", "Mr.", "Bob", "Michaels")]
        [InlineData("Mrs. Aunt Jemima", "Mrs.", "Aunt", "Jemima")]
        // [Fact]
        public void PrefixPlusFirstAndLastNamePopulated(string nameToTest, string expectedPrefix, 
                                                        string expectedFirstName, string expectedLastName)
        {
            //Arrange
            var nameParser = new Parser();

            //Act
            var result = nameParser.ParseName(nameToTest);

            //Assert
            Assert.Equal(result.Prefix, expectedPrefix);
            Assert.Equal(result.FirstName, expectedFirstName);
            Assert.Equal(result.LastName, expectedLastName);
        }


        [Fact]
        public void OnlyInitialsForFirstAndMiddleNamePopulated()
        {
            //Arrange
            var name = "P J O'Rourke";
            var nameParser = new Parser();

            //Act
            var result = nameParser.ParseName(name);

            //Assert
            Assert.Equal(result.FirstName, "P");
            Assert.Equal(result.MiddleInitial, "J");
            Assert.Equal(result.LastName, "O'Rourke");
        }


        [Fact]
        public void OnlyInitialsWithPeriodsForFirstAndMiddleNamePopulated()
        {
            //Arrange
            var name = "C. S. Lewis";
            var nameParser = new Parser();

            //Act
            var result = nameParser.ParseName(name);

            //Assert
            Assert.Equal(result.FirstName, "C.");
            Assert.Equal(result.MiddleInitial, "S.");
            Assert.Equal(result.LastName, "Lewis");
        }


        [Fact]
        public void PrefixPlusFirstAndMiddleNameInitialsPlusSuffix()
        {
            //Arrange
            var name = "Mr. C. S. Lewis PhD";
            var nameParser = new Parser();

            //Act
            var result = nameParser.ParseName(name);

            //Assert
            Assert.Equal(result.Prefix, "Mr.");
            Assert.Equal(result.FirstName, "C.");
            Assert.Equal(result.MiddleInitial, "S.");
            Assert.Equal(result.LastName, "Lewis");
            Assert.Equal(result.Suffix, "PhD");
        }
    }
}
