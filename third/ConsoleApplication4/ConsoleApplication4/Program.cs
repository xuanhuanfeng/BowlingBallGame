using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingBall
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Frame
    {
        #region variable

        private const int totalPinsNum = 10;
        private const int totalTurnsNum = 10;
        private int lastFramePinsNum = 0;
        private bool isTurnStart = true;
        private int score = 0;
        public int Score { get { return score; } }

        private bool isAll = false;
        public bool IsAll { get { return isAll; } }

        private bool isSpare = false;
        public bool IsSpare { get { return isSpare; } }

        private bool isSpecialThrow = false;
        public bool IsSpecialThrow
        {
            get { return isSpecialThrow; }
            set { isSpecialThrow = value; }
        }


        #endregion

        public Frame(int pins,bool isTurnStart, int lastFramePinsNum)
        {
            this.isTurnStart = isTurnStart;
            this.lastFramePinsNum = lastFramePinsNum;
            Throw(pins);
        }
        public void Throw(int pins)
        {
            InvalidPins(pins);

            if (isTurnStart)
            {
                if (totalPinsNum == pins)
                    isAll = true;
                score = pins;
            }
            else
            {
                if ((totalPinsNum - lastFramePinsNum) == pins)
                    isSpare = true;           
                score = pins;
            }
        }

        private void InvalidPins(int pins)
        {
            if ((pins < 0 || pins > totalPinsNum) || (!isTurnStart && pins > (totalPinsNum - lastFramePinsNum)))
                throw new ArgumentException();
        }
    }

    public class Game
    {
        private List<Frame> frameList = new List<Frame>();
        private int score = 0;
        private const int FrameNum = 21;
        private const int totalTurnsNum = 10;

        private bool isTurnStart = true;
        private int lastFramePinsNum = 0;
        private int turn = 0;


        public int Score()
        {
            score = 0;
            for (int i = 0; i < frameList.Count && !frameList[i].IsSpecialThrow; i++)
            {
                if (frameList[i].IsAll)
                    score += (frameList[i].Score +
                        frameList[i + 1].Score + frameList[i + 2].Score);
                else if (frameList[i].IsSpare)
                    score += (frameList[i].Score + frameList[i + 1].Score);
                else
                    score += frameList[i].Score;
            }
            return score;
        }

        public void Throw(int pins)
        {
            if (frameList.Count < FrameNum)
            {
                Frame frame = new Frame(pins, isTurnStart, lastFramePinsNum);

                if (isTurnStart)
                {
                    if (!frame.IsAll)
                        isTurnStart = false;

                    turn++;
                    if (turn > totalTurnsNum)
                        frame.IsSpecialThrow = true;
                    lastFramePinsNum = pins;
                }
                else
                {
                    isTurnStart = true;
                }

                frameList.Add(frame);
            }
            else
                throw new ArgumentOutOfRangeException();
        }
    }
}
