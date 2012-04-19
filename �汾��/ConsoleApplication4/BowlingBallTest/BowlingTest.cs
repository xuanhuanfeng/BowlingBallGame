using BowlingBall;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BowlingBallTest
{


    /// <summary>
    ///这是 ProgramTest 的测试类，旨在
    ///包含所有 ProgramTest 单元测试
    ///</summary>
    [TestClass()]
    public class ProgramTest
    {
        private Game game = new Game();
        private Frame frame;


        [TestMethod]
        public void FirstThrow()
        {
            frame = new Frame(game);
            frame.Throw(5);
            Assert.AreEqual(5, game.Score());
        }

        [TestMethod]
        public void SecondThrow()
        {
            frame = new Frame(game);
            frame.Throw(5);
            frame.Throw(3);
            Assert.AreEqual(8, game.Score());
        }

        [TestMethod]
        public void ThirdTurn()
        {
            frame = new Frame(game);
            frame.Throw(1);
            frame.Throw(4);

            frame.Throw(4);
            frame.Throw(5);

            frame.Throw(5);
            frame.Throw(4);
            Assert.AreEqual(23, game.Score());
        }

        [TestMethod]
        public void HasSpareTurn()
        {
            frame = new Frame(game);
            frame.Throw(1);
            frame.Throw(4);

            frame.Throw(5);
            frame.Throw(5);

            frame.Throw(6);
            Assert.AreEqual(27, game.Score());
        }

        [TestMethod]
        public void HasAllTurn()
        {
            frame = new Frame(game);
            frame.Throw(1);
            frame.Throw(4);

            frame.Throw(4);
            frame.Throw(5);

            frame.Throw(6);
            frame.Throw(4);

            frame.Throw(5);
            frame.Throw(5);

            frame.Throw(10);

            frame.Throw(0);
            frame.Throw(1);
            Assert.AreEqual(61, game.Score());
        }

        [TestMethod]
        public void TheTenthTurn()
        {
            frame = new Frame(game);
            frame.Throw(1);
            frame.Throw(4);

            frame.Throw(4);
            frame.Throw(5);

            frame.Throw(6);
            frame.Throw(4);

            frame.Throw(5);
            frame.Throw(5);

            frame.Throw(10);

            frame.Throw(0);
            frame.Throw(1);

            frame.Throw(7);
            frame.Throw(3);

            frame.Throw(6);
            frame.Throw(4);

            frame.Throw(10);

            frame.Throw(2);
            frame.Throw(8);
            frame.Throw(6);
            Assert.AreEqual(133, game.Score());
        } 
    }
}
