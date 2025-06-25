using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDemo
{


    class Program
    {
        static async Task Main()
        {


            Console.WriteLine("主线程开始执行");

            //启动两个异步任务
            Task task1 = Task.Run(() => PrintNumbers(7));
            Task task2 = Task.Run(() => PrintLetters());

            //等待两个任务完成
            await Task.WhenAll(task1, task2);

            Console.WriteLine("所有任务执行完毕");
        }

        static void PrintNumbers(int num)
        {
            for (int i = 1; i <= num; i++)
            {
                Console.WriteLine($"[Task-数字] {i}");
                Thread.Sleep(500); // 模拟耗时
            }
        }

        static void PrintLetters()
        {
            for (char c = 'A'; c <= 'E'; c++)
            {
                Console.WriteLine($"[Task-字母] {c}");
                Thread.Sleep(700); // 模拟耗时
            }
        }
    }

}
