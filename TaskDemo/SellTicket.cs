//using System;
//using System.Threading;
//using System.Threading.Tasks;

//class Program
//{
//    static int ticketCount = 10;          // 总票数
//    static object lockObj = new object(); // 锁对象保证线程安全

//    static async Task Main()
//    {
//        // 创建3个卖票窗口任务
//        Task[] sellers = new Task[3];
//        for (int i = 0; i < 3; i++)
//        {
//            int windowId = i + 1;
//            sellers[i] = Task.Run(() => SellTickets(windowId));
//        }

//        // 等待所有卖票任务完成
//        await Task.WhenAll(sellers);

//        Console.WriteLine("所有票已售完，程序结束");
//    }

//    static void SellTickets(int windowId)
//    {
//        while (true)
//        {
//            lock (lockObj)
//            {
//                if (ticketCount > 0)
//                {
//                    Console.WriteLine($"窗口{windowId} 卖出第 {11 - ticketCount} 张票，还剩 {ticketCount - 1} 张票");
//                    ticketCount--;
//                    Thread.Sleep(100); // 模拟卖票耗时
//                }
//                else
//                {
//                    Console.WriteLine($"窗口{windowId}：票已售完");
//                    break;
//                }
//            }
//        }
//    }
//}
