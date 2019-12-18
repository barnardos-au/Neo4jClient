using System.Collections.Generic;
using FluentAssertions;
using Moq;
using Neo4jClient.Cypher;
using Neo4jClient.Test.Fixtures;
using Xunit;

namespace Neo4jClient.Test.Cypher
{
    public class WithIdentifierMethod : IClassFixture<CultureInfoSetupFixture>
    {
        private class ObjectWithIds
        {
            public List<int> Ids { get; set; }
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(null)]
        public void DoesNothing_WhenIdentifierIsNullOrWhitespace(string identifier)
        {
            var mockGc = new Mock<IRawGraphClient>();

            var cfq = new CypherFluentQuery(mockGc.Object);
            cfq.WithIdentifier(identifier);
            var query = cfq.Query;
            query.Identifier.Should().BeNull();
        }

        [Fact]
        public void SetsTheIdentifer_WhenValid()
        {
            const string identifier = "MyQuery";
            var mockGc = new Mock<IRawGraphClient>();

            var cfq = new CypherFluentQuery(mockGc.Object);
            cfq.WithIdentifier(identifier);
            var query = cfq.Query;
            query.Identifier.Should().Be(identifier);
        }
    }
}