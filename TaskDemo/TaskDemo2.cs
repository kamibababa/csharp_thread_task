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
//            Console.WriteLine("主线程开始");

//            int a = 3;
//            int b = 4;

//            启动两个带返回值的任务
//            Task<int> addTask = Task.Run(() => Add(a, b));   // 3 + 4 = 7
//            Task<int> mulTask = Task.Run(() => Multiply(a, b)); // 3 * 4 = 12

//            并发等待两个任务完成
//           await Task.WhenAll(addTask, mulTask);

//            获取结果并求和
//            int addResult = await addTask;
//            int mulResult = await mulTask;
//            int total = addResult + mulResult;

//            Console.WriteLine($"加法结果：{addResult}");
//            Console.WriteLine($"乘法结果：{mulResult}");
//            Console.WriteLine($"总和（加 + 乘）：{total}");
//        }

//        static int Add(int x, int y)
//        {
//            Console.WriteLine($"正在执行加法：{x} + {y}");
//            Task.Delay(500).Wait(); // 模拟耗时操作
//            return x + y;
//        }

//        static int Multiply(int x, int y)
//        {
//            Console.WriteLine($"正在执行乘法：{x} * {y}");
//            Task.Delay(800).Wait(); // 模拟耗时操作
//            return x * y;
//        }
//    }

//}
