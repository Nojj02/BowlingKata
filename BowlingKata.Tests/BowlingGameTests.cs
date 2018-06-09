using Xunit;

namespace BowlingKata.Tests
{
    public class BowlingGameTests
    {
        [Fact]
        public void ScoreIsZero_OneRoll_NoPinsKnockedDown()
        {
            var game = new BowlingGame();

            game.Roll(pinsKnockedDown: 0);

            Assert.Equal(0, game.Score);
        }

        [Fact]
        public void ScoreIsPinsKnockedDown_OneRoll_SomePinsKnockedDown()
        {
            var game = new BowlingGame();

            game.Roll(pinsKnockedDown: 3);

            Assert.Equal(3, game.Score);
        }

        [Fact]
        public void ScoresSummedUp_TwoRolls()
        {
            var game = new BowlingGame();

            game.Roll(pinsKnockedDown: 3);
            game.Roll(pinsKnockedDown: 4);

            Assert.Equal(7, game.Score);
        }

        [Fact]
        public void ScoreOfSpareDeferred_TwoRolls_Spare()
        {
            var game = new BowlingGame();

            game.Roll(pinsKnockedDown: 3);
            game.Roll(pinsKnockedDown: 7);

            Assert.Equal(3, game.Score);
        }

        [Fact]
        public void ScoreOfStrikeDeferred_OneRoll_Strike()
        {
            var game = new BowlingGame();

            game.Roll(pinsKnockedDown: 10);

            Assert.Equal(0, game.Score);
        }

        [Fact]
        public void ScoreOfSpareDeferred_FiveRolls_SpareOnFourthRoll()
        {
            var game = new BowlingGame();

            game.Roll(pinsKnockedDown: 2);
            game.Roll(pinsKnockedDown: 7);
            game.Roll(pinsKnockedDown: 5);
            game.Roll(pinsKnockedDown: 5);
            game.Roll(pinsKnockedDown: 3);

            Assert.Equal(25, game.Score);
        }

        [Fact]
        public void ScoreOfStrikeIsDeferred_TwoRolls_FirstRollIsStrike()
        {
            var game = new BowlingGame();

            game.Roll(pinsKnockedDown: 10);
            game.Roll(pinsKnockedDown: 5);

            Assert.Equal(5, game.Score);
        }

        [Fact]
        public void StrikeAddsScoreOfNextTwoRolls_ThreeRolls_FirstRollIsStrike()
        {
            var game = new BowlingGame();

            game.Roll(pinsKnockedDown: 10);
            game.Roll(pinsKnockedDown: 5);
            game.Roll(pinsKnockedDown: 3);

            Assert.Equal(26, game.Score);
        }

        [Fact]
        public void SpareAddsScoreOfNextRoll_ThreeRolls_FirstTwoRollsAreSpare()
        {
            var game = new BowlingGame();

            game.Roll(pinsKnockedDown: 3);
            game.Roll(pinsKnockedDown: 7);
            game.Roll(pinsKnockedDown: 5);

            Assert.Equal(20, game.Score);
        }

        [Fact]
        public void RollsInBetweenFramesAreNotSpares_ThreeRolls()
        {
            var game = new BowlingGame();

            game.Roll(pinsKnockedDown: 3);
            game.Roll(pinsKnockedDown: 5);
            game.Roll(pinsKnockedDown: 5);

            Assert.Equal(13, game.Score);
        }

        [Fact]
        public void PerfectGame()
        {
            var game = new BowlingGame();

            game.Roll(pinsKnockedDown: 10);
            game.Roll(pinsKnockedDown: 10);
            game.Roll(pinsKnockedDown: 10);
            game.Roll(pinsKnockedDown: 10);
            game.Roll(pinsKnockedDown: 10);
            game.Roll(pinsKnockedDown: 10);
            game.Roll(pinsKnockedDown: 10);
            game.Roll(pinsKnockedDown: 10);
            game.Roll(pinsKnockedDown: 10);
            game.Roll(pinsKnockedDown: 10);
            game.Roll(pinsKnockedDown: 10);
            game.Roll(pinsKnockedDown: 10);

            Assert.Equal(300, game.Score);
        }

        [Fact]
        public void LastRollInCompleteGameIsSpare()
        {
            var game = new BowlingGame();

            game.Roll(pinsKnockedDown: 10);
            game.Roll(pinsKnockedDown: 10);
            game.Roll(pinsKnockedDown: 10);
            game.Roll(pinsKnockedDown: 10);
            game.Roll(pinsKnockedDown: 10);
            game.Roll(pinsKnockedDown: 10);
            game.Roll(pinsKnockedDown: 10);
            game.Roll(pinsKnockedDown: 10);
            game.Roll(pinsKnockedDown: 10);
            game.Roll(pinsKnockedDown: 9);
            game.Roll(pinsKnockedDown: 1);
            game.Roll(pinsKnockedDown: 10);

            Assert.Equal(279, game.Score);
        }
    }
}