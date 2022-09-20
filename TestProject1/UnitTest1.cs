using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using ConsoleApp21;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddObserver()
        {
            Countdown countdown = new Countdown();
            Reader obs1 = new Reader("Соня");
            Reader obs2 = new Reader("Аня");

            countdown.addObs(obs1);
            int exp = 1;
            int act = countdown.numOfObserver();
            Assert.AreEqual(exp, act);

            countdown.addObs(obs2);
            exp = 2;
            act = countdown.numOfObserver();
            Assert.AreEqual(exp, act);
        }

        [TestMethod]
        public void RemoveObserver()
        {
            Countdown countdown = new Countdown();
            Reader obs1 = new Reader("Соня");
            Reader obs2 = new Reader("Аня");

            countdown.addObs(obs1);
            countdown.addObs(obs2);

            int exp = 2;
            int act = countdown.numOfObserver();
            Assert.AreEqual(exp, act);

            countdown.removeObs(obs2);
            exp = 1;
            act = countdown.numOfObserver();
            Assert.AreEqual(exp, act);
        }

        [TestMethod]
        public void NotifyObserersForOneReader()
        {
            StringWriter strwr = new StringWriter();
            Console.SetOut(strwr);

            Countdown countdown = new Countdown();
            Reader obs1 = new Reader("Соня");
            countdown.addObs(obs1);

            string str = "Соня - message1";
            int sleep = 1000;
            countdown.NotifyObs("message1", sleep);
            bool act = strwr.ToString().Contains(str);

            Assert.IsTrue(act);
        }

        [TestMethod]
        public void NotifyObserersForManyReader()
        {
            StringWriter strwr = new StringWriter();
            Console.SetOut(strwr);

            Countdown countdown = new Countdown();
            Reader obs1 = new Reader("Соня");
            Reader obs2 = new Reader("Аня");
            countdown.addObs(obs1);
            countdown.addObs(obs2);

            string str1 = "Соня - message1";
            string str2 = "Аня - message2";
            int sleep = 1000;

            countdown.NotifyObs("message1", sleep);
            countdown.NotifyObs("message2", sleep);

            bool act1 = strwr.ToString().Contains(str1);
            bool act2 = strwr.ToString().Contains(str2);

            Assert.IsTrue(act1);
            Assert.IsTrue(act2);
        }
    }
}
