//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TaskDemo
//{
//    internal class FakeAsync
//    {
//        static async Task Main()
//        {
//            Console.WriteLine("模拟启动 100 个任务：");

//            // 切换 true 使用“假异步”，false 使用“真异步”
//            bool useFakeAsync = true;

//            var tasks = new Task[100];

//            var sw = Stopwatch.StartNew();

//            for (int i = 0; i < 100; i++)
//            {
//                if (useFakeAsync)
//                {
//                    // 假异步：占线程池线程
//                    tasks[i] = Task.Run(() =>
//                    {
//                        Thread.Sleep(1000); // 同步阻塞
//                    });
//                }
//                else
//                {
//                    // 真异步：不占线程，等待异步完成
//                    tasks[i] = Task.Delay(1000); // 真正异步等待
//                }
//            }

//            // 检查当前活动线程数
//            int threadCount = Process.GetCurrentProcess().Threads.Count;
//            Console.WriteLine($"启动后线程数：{threadCount}");

//            await Task.WhenAll(tasks);

//            sw.Stop();
//            Console.WriteLine($"全部完成，用时 {sw.ElapsedMilliseconds} ms");
//        }
//    }
//}
