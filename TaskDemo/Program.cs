//using System;
//using System.Threading;

//class Program
//{
//    static void Main()
//    {
//        // 创建两个线程执行不同的方法
//        Thread thread1 = new Thread(PrintNumbers);
//        Thread thread2 = new Thread(PrintLetters);

//        // 启动线程
//        thread1.Start();
//        thread2.Start();

//        // 主线程继续执行
//        Console.WriteLine("主线程继续执行中...");

//        // 等待两个线程结束
//        thread1.Join();
//        thread2.Join();

//        Console.WriteLine("所有线程执行完毕。");
//    }

//    static void PrintNumbers()
//    {
//        for (int i = 1; i <= 5; i++)
//        {
//            Console.WriteLine($"[数字线程] {i}");
//            Thread.Sleep(500); // 模拟耗时操作
//        }
//    }

//    static void PrintLetters()
//    {
//        for (char c = 'A'; c <= 'E'; c++)
//        {
//            Console.WriteLine($"[字母线程] {c}");
//            Thread.Sleep(700); // 模拟耗时操作
//        }
//    }
//}
