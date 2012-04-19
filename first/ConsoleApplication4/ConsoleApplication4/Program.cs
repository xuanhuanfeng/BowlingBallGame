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
        private Game game = null;
        private int lastFrame = 0;
        public int Score { get; set; }

        private bool isAll = false;
        public bool IsAll
        {
            get { return isAll; }
            set { isAll = value; }
        }

        private bool isSpare = false;
        public bool IsSpare
        {
            get { return isSpare; }
            set { isSpare = value; }
        }

        private bool isFirstThrow = true;

        public Frame(Game game)
        {
            this.game = game;
        }
        public Frame()
        {
            this.game = null;
        }

        public void Throw(int pins)
        {
            if (isFirstThrow && (0 <= pins && 10 >= pins))
            {
                if (10 == pins)
                    IsAll = true;
                else
                    isFirstThrow = false;
                getScore(pins);
            }
            else if (!isFirstThrow && (0 <= pins && (10 - lastFrame) >= pins))
            {
                if ((10 - lastFrame) == pins)
                    IsSpare = true;

                isFirstThrow = true;
                getScore(pins);
            }           
            else
            {
                throw new ArgumentException();
            }

            if (IsAll)
                IsAll = false;
            if (IsSpare)
                IsSpare = false;
        }

        private void getScore(int pins)
        {
            lastFrame = Score = pins;
            game.Add(this);
        }
    }

    public class Game
    {
        private List<Frame> frameList = new List<Frame>();
        private int score = 0;
        private  const int FrameNum = 21;

        public int Score() 
        {
            score = 0;
            for (int i = 0; i < frameList.Count; i++)
            {
                if(frameList[i].IsAll)
                    score += (frameList[i].Score +
                        frameList[i + 1].Score + frameList[i + 2].Score);
                else if(frameList[i].IsSpare)
                    score += (frameList[i].Score +frameList[i + 1].Score);
                else
                    score += frameList[i].Score;
            }
                return score;
        }

        public void Add(Frame frame)
        {
            if (frameList.Count < FrameNum)
            {
                Frame _frame = new Frame();

                _frame.Score = frame.Score;
                _frame.IsSpare = frame.IsSpare;
                _frame.IsAll = frame.IsAll;

                frameList.Add(_frame);
            }
            else
                throw new ArgumentOutOfRangeException();
        }
    }
}
