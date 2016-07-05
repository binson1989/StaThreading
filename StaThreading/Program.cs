using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StaThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            var deviceInfo = new DeviceInfo();
            var thread1 = new Thread(new ThreadStart(() =>
            {
                deviceInfo.Take1();
                Console.WriteLine("Performing Take 1:");
                Console.WriteLine("Thread id: " + Thread.CurrentThread.ManagedThreadId + ", Session Id: " + deviceInfo.Take1());
            }));
            thread1.Start();
            thread1.Join();

            var thread2 = new Thread(new ThreadStart(() =>
            {
                Console.WriteLine("Performing Take 2:");
                Console.WriteLine("Thread id: " + Thread.CurrentThread.ManagedThreadId + ", Session Id: " + deviceInfo.Take2());
            }));
            thread2.Start();
            thread2.Join();

            Console.ReadLine();
        }
    }

    public class DeviceInfo
    {
        private int _sessionId;

        public int Take1()
        {
            _sessionId = 1;
            return _sessionId;
        }

        public int Take2()
        {
            return _sessionId;
        }
    }
}
