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

        public int Turn { get; set; }

        private bool isFirstThrow = true;

        public Frame(Game game)
        {
            this.game = game;
        }
        public Frame()
        {
            this.game = null;
        }
        #endregion

        public void Throw(int pins)
        {
            if (isFirstThrow && (0 <= pins && 10 >= pins))
            {
                if (10 == pins)
                    IsAll = true;
                else
                    isFirstThrow = false;

                   Turn++; 

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
            for (int i = 0; i < frameList.Count && frameList[i].Turn <= 10; i++)
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
                Frame frame1 = new Frame();

                frame1.Score = frame.Score;
                frame1.IsSpare = frame.IsSpare;
                frame1.IsAll = frame.IsAll;
                frame1.Turn = frame.Turn;

                frameList.Add(frame1);
            }
            else
                throw new ArgumentOutOfRangeException();
        }
    }
}
