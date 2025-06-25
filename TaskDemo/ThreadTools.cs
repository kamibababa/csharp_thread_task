using System;
using System.Threading;

class Program
{

    static void Main()
    {

        // 等待子线程执行完毕（通过 ManualResetEvent）
        ManualResetEvent done1 = new ManualResetEvent(false);
        ManualResetEvent done2 = new ManualResetEvent(false);
        //AutoResetEvent

        // 包装任务，传入 ManualResetEvent 用于通知完成
        ThreadPool.QueueUserWorkItem(state =>
        {
            PrintNumbers(state);
            done1.Set();
        }, "hello");//多个参数可以传一个自定义类型的对象

        ThreadPool.QueueUserWorkItem(state =>
        {
            PrintLetters(state);
            done2.Set();
        }, "nihao");

        // 等待两个任务完成
        WaitHandle.WaitAll(new WaitHandle[] { done1, done2 });

        Console.WriteLine("所有线程池任务执行完毕。");
    }

    static void PrintNumbers(object state)
    {
        Console.WriteLine("PrintNumbers" + state);
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"[线程池-数字] {i}");
            Thread.Sleep(500);
        }
    }

    static void PrintLetters(object state)
    {
        Console.WriteLine("PrintLetters" + state);
        for (char c = 'A'; c <= 'E'; c++)
        {
            Console.WriteLine($"[线程池-字母] {c}");
            Thread.Sleep(700);
        }
    }
}
