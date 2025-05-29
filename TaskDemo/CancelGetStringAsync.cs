using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDemo
{
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    class Program
    {
        static async Task Main()
        {
            using var cts = new CancellationTokenSource();

            Console.WriteLine("按任意键在3秒内取消请求...");
            var cancelTask = Task.Run(() =>
            {
                Console.ReadKey();
                cts.Cancel();
            });

            try
            {
                using var client = new HttpClient();
                var requestTask = client.GetStringAsync("https://httpbin.org/delay/5", cts.Token); // 服务器延迟5秒

                string result = await requestTask;
                Console.WriteLine("请求成功，内容前50字：");
                Console.WriteLine(result.Substring(0, 50));
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("请求已取消。");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"发生错误：{ex.Message}");
            }
        }
    }

}
