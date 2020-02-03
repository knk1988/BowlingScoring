using BowlingScoring;
using NUnit.Framework;

namespace BowlingScoringUnitTests
{
    public class Tests
    {
        Game game;
        [SetUp]
        public void Setup()
        {
            game = new Game();
        }

        [Test]
        public void Test_Gutter_Game()
        {
            // Arrange
            int n = 20;
            int pins = 0;

            // Act
            RollMany(n, pins);

            // Assert
            Assert.AreEqual(0, game.Score());
        }

        [Test]
        public void Test_All_Ones()
        {
            // Arrange
            int n = 20;
            int pins = 1;

            // Act
            RollMany(n, pins);

            // Assert
            Assert.AreEqual(20,game.Score());
        }

        [Test]
        public void Test_One_Spare()
        {
            // Arrange
            int n = 17;
            int pins = 0;

            // Act
            RollSpare();
            game.Roll(3);
            RollMany(n, pins);

            // Assert
            Assert.AreEqual(16, game.Score());
        }

        [Test]
        public void Test_One_Strike()
        {
            // Arrange
            int n = 16;
            int pins = 0;

            // Act
            RollStrike();
            game.Roll(3);
            game.Roll(4);
            RollMany(n, pins);

            // Assert
            Assert.AreEqual(24, game.Score());
        }

        [Test]
        public void Test_Perfect_Game()
        {
            // Arrange

            // Act 
            RollMany(12, 10);

            // Assert 
            Assert.AreEqual(300, game.Score());
        }

        private void RollStrike()
        {
            game.Roll(10);
        }

        private void RollSpare()
        {
            game.Roll(5);
            game.Roll(5);
        }

        private void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
            {
                game.Roll(pins);
            }
        }


    }
}