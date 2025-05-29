//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TaskDemo
//{
//    using System;
//    using System.Threading.Tasks;

//    class Program
//    {
//        static async Task Main()
//        {
//            try
//            {
//                // 创建一个任务，它会抛出未处理异常
//                Task task = Task.Run(() =>
//                {
//                    Console.WriteLine("任务开始运行...");
//                    int x = 0;
//                    int result = 10 / x; // 这里会抛出 DivideByZeroException
//                    Console.WriteLine($"结果是：{result}");
//                });

//                await task; // 异常会在这里重新抛出
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"捕获到异常：{ex.GetType().Name} - {ex.Message}");
//            }
//        }
//    }

//}
