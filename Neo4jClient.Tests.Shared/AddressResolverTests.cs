using FluentAssertions;
using Neo4jClient.Test.Fixtures;
using Xunit;

namespace Neo4jClient.Tests.Shared
{
    public class UriCreatorTests : IClassFixture<CultureInfoSetupFixture>
    {
        [Theory]
        [InlineData("x.foo.com", "scheme://x.foo.com:7687/", 7687)]
        [InlineData("x.foo.com:7687", "scheme://x.foo.com:7687/", 7687)]
        [InlineData("x.foo.com:7688", "scheme://x.foo.com:7688/", 7688)]
        [InlineData("bolt://x.foo.com:7688", "bolt://x.foo.com:7688/", 7688)]
        public void GeneratesTheCorrectUri(string input, string expectedUri, int expectedPort)
        {
            var response = UriCreator.From(input);
            response.AbsoluteUri.Should().Be(expectedUri);
            response.Port.Should().Be(expectedPort);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void ReturnsNullWhenNullOrWhitespacePassedIn(string uri)
        {
            UriCreator.From(uri).Should().BeNull();
        }
    }
}