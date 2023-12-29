using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsumeProduce
{
    public class Consumer
    {
        private const int consumerCount = 4;
        private Stack<int> stack;
        private Thread consumer;
        private int total = 0;
        private int index = 0;
        public Consumer(Stack<int> generalStack, int generalTotal)
        {
            total = generalTotal * consumerCount;
            stack = generalStack;
            for (int i = 0; i < consumerCount; i++)
            {
                consumer = new Thread(Consume);
                consumer.Name = $"consumer {i+ 1}";
                consumer.Start();
            }
        }
        public void Consume()
        {
            int count = 0;
            while (total >= count)
            {
                try
                {
                    Monitor.Enter(stack);
                    if (total - count < 3 )
                    {
                        for (int i = 0; i < stack.Count; i++)
                        {
                            Console.WriteLine(stack.Pop());
                            count++;
                        }
                    }
                    else if (stack.Count < 3)
                    {
                        Monitor.Wait(stack);
                    }
                    else
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            Console.WriteLine(stack.Pop());
                            count++;
                        }
                        Monitor.Pulse(stack);
                        Console.WriteLine("====================================================");
                    }
                }
                finally
                {
                    Monitor.Exit(stack);
                }
            }
        }
    }
}
