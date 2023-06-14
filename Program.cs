using System;
using System.Threading;
using System.Threading.Tasks;

namespace task
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> task = Task.Run<int>(() => {
                int total = 0;
                for (int i=1; i<=100; ++i)
                    total += i;
                Thread.Sleep(1000);
                return total;
            });

            //error CS4033: The 'await' operator can only be used within an async method.
            //int result = await task;

            //In this case however, we don't want to make the Main() method async. In fact, we can't.
            //Option 1: Remove the await keyword, and wait for the task to complete by reading the task.Result property.
            //Option 2: Remove the await keyword, and wait for the task to complete by calling task.Wait().

            int result = task.Result;

            Console.WriteLine(result);
        }
    }
}
