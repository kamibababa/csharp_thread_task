//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TaskDemo
//{
//    using System;
//    using System.Threading;

//    class Program
//    {
//        static void Main()
//        {
//            // 获取并打印线程池最大线程数
//            ThreadPool.GetMaxThreads(out int maxWorkerThreads, out int maxIOThreads);
//            Console.WriteLine($"[初始] 最大工作线程数: {maxWorkerThreads}, 最大IO线程数: {maxIOThreads}");

//            // 提交大量任务，观察线程池行为
//            int taskCount = 100;
//            CountdownEvent countdown = new CountdownEvent(taskCount);

//            for (int i = 0; i < taskCount; i++)
//            {
//                ThreadPool.QueueUserWorkItem(state =>
//                {
//                    // 模拟任务工作时间
                  

//                    // 每个任务中打印当前可用线程数
//                    ThreadPool.GetAvailableThreads(out int availableWorkers, out int availableIO);
//                    Console.WriteLine($"[线程池状态] 可用工作线程: {availableWorkers}, 可用IO线程: {availableIO}, 线程ID: {Thread.CurrentThread.ManagedThreadId}");
//                    Thread.Sleep(10000);
//                    countdown.Signal(); // 完成一个任务
//                });
//            }

//            // 等待所有任务完成
//            countdown.Wait();
//            Console.WriteLine("所有任务完成。");
//        }
//    }

//}
