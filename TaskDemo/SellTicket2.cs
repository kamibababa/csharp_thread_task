//using System;
//using System.Threading;
//using System.Threading.Tasks;

//class Program
//{
//    static int ticketCount = 30; // 总票数

//    static async Task Main()
//    {
//        Task[] sellers = new Task[4];

//        for (int i = 0; i < 4; i++)
//        {
//            int windowId = i + 1;
//            sellers[i] = Task.Run(() => SellTickets(windowId));
//        }

//        await Task.WhenAll(sellers);

//        Console.WriteLine("卖票任务结束");
//    }

//    static void SellTickets(int windowId)
//    {
//        while (true)
//        {
//            if (ticketCount > 0)
//            {
//                Thread.Sleep(10);
//                // 没有锁，可能出现重复卖票或超卖
//                Console.WriteLine($"窗口{windowId} 卖出第 {31 - ticketCount} 张票，还剩 {ticketCount - 1} 张票");
//                ticketCount--;

//            }
//            else
//            {
//                Console.WriteLine($"窗口{windowId}：票已售完");
//                break;
//            }
//        }
//    }
//}
