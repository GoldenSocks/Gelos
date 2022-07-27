using System;
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

        private static string WordsGenerator(int wordsNum)
        {
            var letters = _random.Next(1, MAX_WORD_LENGHT);
            var words = wordsNum;

            var lettersArr = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            var stringBuilder = new StringBuilder();

            for (int i = 1; i <= words; i++)
            {
                for (int j = 1; j <= letters; j++)
                {
                    var letterIndex = _random.Next(0, lettersArr.Length - 1);
                    stringBuilder.Append(lettersArr[letterIndex]);
                }
                stringBuilder.Append(" ");
            }
            return stringBuilder.ToString();
        }

        [Fact]
        public void Create_ShouldReturnIssue()
        {
            // arrange
            var wordsCount = Issue.MAX_NAME_LENGHT / (MAX_WORD_LENGHT + 1);
            var words = _random.Next(1, wordsCount);
            var name = WordsGenerator(words);
            _outputHelper.WriteLine(name);

            var fixture = new Fixture();
            // var name = fixture.Create<string>();
            var description = fixture.Create<string>();
            var createDate = DateTime.Now;

            // act
            var issue = Issue.Create(name, description, createDate);

            // assert
            Assert.NotNull(issue);
        }

        [Fact]
        public void Create_ShouldReturnError()
        {
            // arrange
            var wordsCount = Issue.MAX_NAME_LENGHT / (MAX_WORD_LENGHT + 1);
            var words = _random.Next(wordsCount + 1, Issue.MAX_NAME_LENGHT);
            var name = WordsGenerator(words);
            _outputHelper.WriteLine(name);

            var fixture = new Fixture();
            // var name = fixture.Create<string>();
            var description = fixture.Create<string>();
            var createDate = DateTime.Now;

            // act
            var issue = Issue.Create(name, description, createDate);
            _outputHelper.WriteLine("\r\n\tErrore: " + issue.Value);

            // assert
            Assert.Null(issue);
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