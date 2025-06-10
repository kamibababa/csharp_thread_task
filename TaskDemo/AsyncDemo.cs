using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDemo
{
    internal class AsyncDemo
    {
        public static async Task<int> GetValueAsync()
        {
            return 42;  // 编译器会自动包装成 Task.FromResult(42)
        }
        public static async Task DoSomethingAsync()
        {
            int value = await GetValueAsync();  // value == 42 隐式转换 Task<int> 为 int
            Console.WriteLine($"获取的值是：{value}");
        }

        static async Task Main(string[] args)
        {
            await DoSomethingAsync();
            await Console.Out.WriteLineAsync("dsf");
        }
    }
}
