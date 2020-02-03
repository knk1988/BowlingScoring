using System;

namespace BowlingScoring
{
    public class Game
    {
        #region Private Members
        private readonly int[] rolls = new int[21];
        private int currentRoll = 0; 
        #endregion

        #region Constructor

        public Game()
        {
        } 
        #endregion

        #region Public Members

        public int Score()
        {
            int score = 0;
            int frameIndex = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(frameIndex))
                {
                    score += StrikeBonus(frameIndex);
                    frameIndex++;
                }
                else if (IsSpare(frameIndex))
                {
                    score += 10 + SpareBonus(frameIndex);
                    frameIndex += 2;
                }
                else
                {
                    score += SumOfBallsInFrame(frameIndex);
                    frameIndex += 2;
                }

            }
            return score;
        }

        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        } 
        #endregion

        #region Private Members

        private int SumOfBallsInFrame(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1];
        }

        private int SpareBonus(int frameIndex)
        {
            return rolls[frameIndex + 2];
        }

        private int StrikeBonus(int frameIndex)
        {
            return 10 + rolls[frameIndex + 1] +
                                    rolls[frameIndex + 2];
        }

        private bool IsStrike(int frameIndex)
        {
            return rolls[frameIndex] == 10;
        }

        private bool IsSpare(int frameIndex)
        {
            return rolls[frameIndex] + rolls[frameIndex + 1] == 10;
        } 
        #endregion
    }
}