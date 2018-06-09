using System.Collections.Generic;
using System.Linq;

namespace BowlingKata
{
    public class BowlingGame
    {
        public readonly List<Roll> _rolls = new List<Roll>();

        private int _rollNumberInFrame = 1;

        public int Score { get; private set; }

        public void Roll(int pinsKnockedDown)
        {
            if (pinsKnockedDown == 10)
            {
                _rolls.Add(BowlingKata.Roll.NewStrike());
            }
            else if (_rollNumberInFrame == 2 && _rolls.Last().PinsKnockedDown + pinsKnockedDown == 10)
            {
                _rolls.Add(BowlingKata.Roll.NewSpare(pinsKnockedDown: pinsKnockedDown));
            }
            else
            {
                _rolls.Add(BowlingKata.Roll.New(pinsKnockedDown: pinsKnockedDown));
                if (_rollNumberInFrame == 2)
                {
                    _rollNumberInFrame = 1;
                }
                else
                {
                    _rollNumberInFrame++;
                }
            }

            Score = ComputeScore();
        }

        public int ComputeScore()
        {
            return _rolls
                .Select((roll, index) => new { Roll = roll, Index = index })
                .Sum(x =>
                {
                    if (x.Roll.IsStrike)
                    {
                        return _rolls.Count > x.Index + 2
                            ? x.Roll.PinsKnockedDown + _rolls[x.Index + 1].PinsKnockedDown + _rolls[x.Index + 2].PinsKnockedDown
                            : 0;
                    }

                    if (x.Roll.IsSpare)
                    {
                        return _rolls.Count > x.Index + 1
                            ? x.Roll.PinsKnockedDown + _rolls[x.Index + 1].PinsKnockedDown
                            : 0;
                    }

                    return x.Roll.PinsKnockedDown;
                });
        }
    }
}