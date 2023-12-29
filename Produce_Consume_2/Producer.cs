using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsumeProduce
{
    public class Producer
    {
        private static Stack<int> stack;
        private Thread producer;
        private static Random rand = new Random();
        private int total = 0;
        public Producer(Stack<int> generalStack, int generalTotal)
        {
            total = generalTotal;
            stack = generalStack;
            producer = new Thread(Produce);
            producer.Start();
        }
        public void Produce()
        { 
            Thread.CurrentThread.Name = "producer";
            try
            {
                Monitor.Enter(stack);
                for (int i = 0; i < total; i++)
                {
                    stack.Push(rand.Next(0, 256));
                }
                Monitor.Pulse(stack);
            }
            finally
            {
                Monitor.Exit(stack);
            }
        }
    }
}
