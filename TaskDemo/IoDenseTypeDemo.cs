using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDemo
{
    internal class IoDenseTypeDemo
    {
        static async Task Main(string[] args)
        {
            using var client = new HttpClient();
            Task[] tasks = new Task[50];
            for (int i = 0; i < 50; i++)
            {
                tasks[i] = Task.Run(async () =>
                {
                    await Task.Delay(10);
                    var requestTask = client.GetStringAsync("https://httpbin.org/delay/5"); // 服务器延迟5秒
                    await Console.Out.WriteLineAsync($"{Thread.CurrentThread.ManagedThreadId} send req");
                    string result = await requestTask;
                    Console.WriteLine("请求成功，内容前50字：");
                    Console.WriteLine(result.Substring(0, 50));
                });
            }

            Task.WaitAll(tasks);
            await Console.Out.WriteLineAsync("over");

        }
    }
}
