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
//        static async Task Main()
//        {
//            var cts = new CancellationTokenSource(); // 控制器
//            var token = cts.Token; // 信号

//            var task = Task.Run(async () =>
//            {
//                for (int i = 1; i <= 10; i++)
//                {
//                    if (token.IsCancellationRequested)
//                    {
//                        Console.WriteLine("任务检测到取消请求，准备中止...");
//                        token.ThrowIfCancellationRequested(); // 抛出异常
//                    }

//                    Console.WriteLine($"任务执行中，第 {i} 次...");
//                    await Task.Delay(500); // 模拟耗时工作
//                }

//                Console.WriteLine("任务正常完成");
//            }, token); // 把 token 传给任务，允许任务被取消

//            // 模拟 2 秒后用户点击取消按钮
//            await Task.Delay(2000);
//            cts.Cancel(); // 发出“取消”请求

//            try
//            {
//                await task; // 等待任务完成（成功 or 异常）
//            }
//            catch (OperationCanceledException)
//            {
//                Console.WriteLine("主线程：任务已取消");
//            }
//            finally
//            {
//                cts.Dispose();
//            }
//        }
//    }

//}
