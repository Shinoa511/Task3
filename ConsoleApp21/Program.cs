using System;
using System.Threading;
using System.Collections.Generic;


namespace ConsoleApp21
{
    class Program
    {
        static void Main(string[] args)
        {
            Countdown countdown = new Countdown();
            Reader obs1 = new Reader("Соня");
            Reader obs2 = new Reader("Аня");
            Reader obs3 = new Reader("Алексей");

            Console.WriteLine("Через какое время уведомить?");
            int sleep = Convert.ToInt32(Console.ReadLine());

            countdown.addObs(obs1);
            countdown.addObs(obs2);
            countdown.NotifyObs("message1", sleep);

            countdown.addObs(obs3);
            countdown.NotifyObs("message2", sleep);

            countdown.removeObs(obs2);
            countdown.NotifyObs("message3", sleep);

            countdown.removeObs(obs3);
            countdown.NotifyObs("message4", sleep);

            Console.ReadKey();
        }
    }

    public interface Observer
    {
        void update(string message);
    }

    public class Reader : Observer
    {
        public string name { get; set; }
        public Reader(string name) => this.name = name;
        public void update(string message) => Console.WriteLine(name + " - " + message);
    }

    public interface Observable
    {
        void addObs(Observer observer);
        void removeObs(Observer observer);
        void NotifyObs(string message, int sleep);
    }

    public class Countdown : Observable
    {
        private List<Observer> observers = new List<Observer>();
        public void addObs(Observer observer) => observers.Add(observer);
        public void removeObs(Observer observer) => observers.Remove(observer);

        public void NotifyObs(string message, int sleep)
        {
            Thread.Sleep(sleep);
            foreach (var observer in observers)
            {
                observer.update(message);
            }
            Console.WriteLine("\n");
        }

        public int numOfObserver() => observers.Count;
    }





    }
