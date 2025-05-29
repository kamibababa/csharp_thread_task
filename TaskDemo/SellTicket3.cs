//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TaskDemo
//{
//    using System;
//    using System.Threading;
//    using System.Threading.Tasks;

//    class Program
//    {
//        static int ticketCount = 50; // 总票数

//        static async Task Main()
//        {
//            Task[] sellers = new Task[3];

//            for (int i = 0; i < 3; i++)
//            {
//                int windowId = i + 1;
//                sellers[i] = Task.Run(() => SellTickets(windowId));
//            }

//            await Task.WhenAll(sellers);

//            Console.WriteLine("卖票任务结束");
//        }

//        static void SellTickets(int windowId)
//        {
//            while (true)
//            {
//                // 原子递减，返回递减后的结果
//                int newCount = Interlocked.Decrement(ref ticketCount);

//                if (newCount >= 0)
//                {
//                    Console.WriteLine($"窗口{windowId} 卖出第 {50 - newCount} 张票，还剩 {newCount} 张票");
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
