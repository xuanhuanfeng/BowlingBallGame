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

        [TestMethod]
        public void FirstThrow()
        {
            game.Throw(5);
            Assert.AreEqual(5, game.Score());
        }

        [TestMethod]
        public void SecondThrow()
        {
            game.Throw(5);
            game.Throw(3);
            Assert.AreEqual(8, game.Score());
        }

        [TestMethod]
        public void ThirdTurn()
        {
            game.Throw(1);
            game.Throw(4);

            game.Throw(4);
            game.Throw(5);

            game.Throw(5);
            game.Throw(4);
            Assert.AreEqual(23, game.Score());
        }

        [TestMethod]
        public void HasSpareTurn()
        {
            game.Throw(1);
            game.Throw(4);

            game.Throw(5);
            game.Throw(5);

            game.Throw(6);
            Assert.AreEqual(27, game.Score());
        }

        [TestMethod]
        public void HasAllTurn()
        {
            game.Throw(1);
            game.Throw(4);

            game.Throw(4);
            game.Throw(5);

            game.Throw(6);
            game.Throw(4);

            game.Throw(5);
            game.Throw(5);

            game.Throw(10);

            game.Throw(0);
            game.Throw(1);
            Assert.AreEqual(61, game.Score());
        }

        [TestMethod]
        public void TheTenthTurn()
        {
            game.Throw(1);
            game.Throw(4);

            game.Throw(4);
            game.Throw(5);

            game.Throw(6);
            game.Throw(4);

            game.Throw(5);
            game.Throw(5);

            game.Throw(10);

            game.Throw(0);
            game.Throw(1);

            game.Throw(7);
            game.Throw(3);

            game.Throw(6);
            game.Throw(4);

            game.Throw(10);

            game.Throw(2);
            game.Throw(8);
            game.Throw(6);
            Assert.AreEqual(133, game.Score());
        } 
    }
}
