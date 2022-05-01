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
        private readonly ITestOutputHelper _outputHelper;

        public IssueTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public void Create_ShouldReturnIssue()
        {
            // arrange
            var random = new Random();
            var stringLenght = random.Next(1,Issue.MAX_NAME_LENGHT);
            var stringBuilder = new StringBuilder();
            var name = Enumerable.Range(0, stringLenght).Aggregate(stringBuilder, (x,y) => x.Append("a")).ToString();
            _outputHelper.WriteLine(name);
            
            var fixture = new Fixture();
            // var name = fixture.Create<string>();
            var description = fixture.Create<string>();
            var createDate = DateTime.Now;
            
            // act
            var (issue, error) = Issue.Create(name, description, createDate);

            // assert
            Assert.Empty(error);
            Assert.NotNull(issue);
        }
    }
}