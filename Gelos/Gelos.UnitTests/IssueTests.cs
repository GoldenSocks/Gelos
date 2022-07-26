using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoFixture;
using Gelos.Domain.Models;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Xunit;
using Xunit.Abstractions;

namespace Gelos.UnitTests
{
    public class IssueTests
    {
        private const int MAX_WORD_LENGHT = 20;
        private readonly ITestOutputHelper _outputHelper;
        private readonly static Random _random = new();

        public IssueTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        private static string WordsGenerator(int length)
        {            
            var lettersArr = "ABCDEFGHIJKLMNOPQRSTUVWXYZ 0123456789.,@#$%".ToCharArray();

            var stringBuilder = new StringBuilder();

            for (int i = 1; i <= length; i++)
            {
                var letterIndex = _random.Next(0, lettersArr.Length - 1);
                stringBuilder.Append(lettersArr[letterIndex]);
            }
            return stringBuilder.ToString();
        }

        [Fact]
        public void Create_ShouldReturnIssue()
        {
            // arrange
            var nameLength = _random.Next(1, Issue.MAX_NAME_LENGTH);
            var name = WordsGenerator(nameLength);
            _outputHelper.WriteLine(name);

            var fixture = new Fixture();
            var description = fixture.Create<string>();
            var createDate = DateTime.Now;

            // act
            var (issue, error) = Issue.Create(name, description, createDate);

            // assert
            Assert.Empty(error);
            Assert.NotNull(issue);
        }

        [Theory]
        [MemberData(nameof(GenerateData))]
        public void Create_ShouldReturnError(string name, string description)
        {
            // arrange
            var createDate = DateTime.Now;

            // act
            var (issue, error) = Issue.Create(name, description, createDate);
            _outputHelper.WriteLine("\r\n\tErrore: " + error);

            // assert
            Assert.NotEmpty(error);
            Assert.Null(issue);
        }

        private static IEnumerable<object[]> GenerateData()
        {
            var random = new Random();

            for (var i = 0; i < 10; i++)
            {
                var nameLength = _random.Next(Issue.MAX_NAME_LENGTH + 1, int.MaxValue);
                yield return new object[] {WordsGenerator(nameLength)};
                yield return new object[] {string.Empty.PadLeft(random.Next(0,100), ' '), string.Empty.PadLeft(random.Next(0,100), ' ')};
                yield return new object[] {null, string.Empty.PadLeft(random.Next(0,100), ' ')};    
            }
            yield return new object[] {string.Empty, string.Empty};
        }

        [Fact]
        public void Get_ShouldReturnIssue()
        {
            // arrange
            

            // act

            // assert

        }
    }
}