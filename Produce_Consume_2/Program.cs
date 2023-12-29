using System;
using System.Collections.Generic;


namespace ConsumeProduce
{
    public class Program
    {
        static Stack<int> stack = new Stack<int>();
        static void Main(string[] args)
        {
            int total = 12;
            Producer producer = new Producer(stack, total);
            Consumer consumer = new Consumer(stack, total);
            Console.ReadKey();
        }
    }
}
