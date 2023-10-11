using Games.Games.Tennis;
using Shouldly;
using Xunit;

namespace Games.Tests.Tennis
{
    public class TennisScoringSystemTests
    {
        private readonly TennisScoringSystem tennisScoringSystem;
        public TennisScoringSystemTests()
        {
            tennisScoringSystem = new TennisScoringSystem();
        }

        [Theory]
        [InlineData(2, 1)]
        [InlineData(1, 1)]
        public void IsBaseScore_Points_True(int playerOnePoints, int playerTwoPoints)
        {
            bool result = tennisScoringSystem.IsBaseScore(playerOnePoints, playerTwoPoints);
            result.ShouldBeTrue();
        }

        [Theory]
        [InlineData(5, 3)]
        [InlineData(6, 5)]
        public void IsBaseScore_Points_False(int playerOnePoints, int playerTwoPoints)
        {
            bool result = tennisScoringSystem.IsBaseScore(playerOnePoints, playerTwoPoints);
            result.ShouldBeFalse();
        }

        [Theory]
        [InlineData(3, 2)]
        [InlineData(6, 5)]
        public void IsAdvantage_Points_True(int playerOnePoints, int playerTwoPoints)
        {
            bool result = tennisScoringSystem.IsAdvantage(playerOnePoints, playerTwoPoints);
            result.ShouldBeTrue();
        }

        [Theory]
        [InlineData(2, 1)]
        [InlineData(6, 6)]
        [InlineData(6, 8)]
        public void IsAdvantage_Points_False(int playerOnePoints, int playerTwoPoints)
        {
            bool result = tennisScoringSystem.IsAdvantage(playerOnePoints, playerTwoPoints);
            result.ShouldBeFalse();
        }

        [Fact]
        public void IsDeuce_Points_True()
        {
            bool result = tennisScoringSystem.IsDeuce(4, 4);
            result.ShouldBeTrue();
        }

        [Theory]
        [InlineData(2, 1)]
        [InlineData(6, 8)]
        public void IsDeuce_Points_False(int playerOnePoints, int playerTwoPoints)
        {
            bool result = tennisScoringSystem.IsDeuce(playerOnePoints, playerTwoPoints);
            result.ShouldBeFalse();
        }

        [Fact]
        public void IsGameOver_Points_True()
        {
            bool result = tennisScoringSystem.IsGameOver(4, 2);
            result.ShouldBeTrue();
        }

        [Theory]
        [InlineData(2, 0)]
        [InlineData(6, 7)]
        [InlineData(6, 6)]
        public void IsGameOver_Points_False(int playerOnePoints, int playerTwoPoints)
        {
            bool result = tennisScoringSystem.IsGameOver(playerOnePoints, playerTwoPoints);
            result.ShouldBeFalse();
        }
    }
}
