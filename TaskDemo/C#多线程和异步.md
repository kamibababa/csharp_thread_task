### C#用Task启动线程(一定是从线程池取得线程)

1.延迟运行

`Task.Run(...)` 或new Task的返回值 **一定是 `Task` 或 `Task<T>`**，根据运行的任务是否有返回值。

```
// 创建一个返回 int 的 Task，但任务还没启动
Task<int> task = new Task<int>(() =>
{
    Console.WriteLine("带返回值任务执行中");
    return 123;
});

Console.WriteLine("任务创建完成，但尚未启动");

// 启动任务
task.Start();

// 等待任务完成并获取结果
int result = task.Result;
Console.WriteLine($"任务结果：{result}");

```

主线程等待任务完成的方法

```
var task1 = new Task(() => Console.WriteLine("任务1执行"));
Console.WriteLine("任务1创建但未启动");
task1.Start();

task1.Wait();  // 主线程在这里阻塞，直到任务完成

Console.WriteLine("任务1已完成，主线程继续执行");

```

2.Task.run()

运行的方法返回普通类型T，Task.Run的返回值用Task<T>包装。await Task<T>类型的变量，返回一定是T类型的数据.

```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDemo
{
    using System;
    using System.Threading.Tasks;

    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("主线程开始");

            int a = 3;
            int b = 4;

            // 启动两个带返回值的任务
            Task<int> addTask = Task.Run(() => Add(a, b));   // 3 + 4 = 7
            Task<int> mulTask = Task.Run(() => Multiply(a, b)); // 3 * 4 = 12

            // 并发等待两个任务完成
            await Task.WhenAll(addTask, mulTask);

            // 获取结果并求和
            int addResult = await addTask;
            int mulResult = await mulTask;
            int total = addResult + mulResult;

            Console.WriteLine($"加法结果：{addResult}");
            Console.WriteLine($"乘法结果：{mulResult}");
            Console.WriteLine($"总和（加 + 乘）：{total}");
        }

        static int Add(int x, int y)
        {
            Console.WriteLine($"正在执行加法：{x} + {y}");
            Task.Delay(500).Wait(); // 模拟耗时操作
            return x + y;
        }

        static int Multiply(int x, int y)
        {
            Console.WriteLine($"正在执行乘法：{x} * {y}");
            Task.Delay(800).Wait(); // 模拟耗时操作
            return x * y;
        }
    }

}

```

### C#异步

async方法的返回值绝大多数是 `Task` 或 `Task<T>`， 偶尔是void。方法内部可以直接返回基本类型T，系统会自动包装成Task<T>,外面调用时，如果外面的方法也是async，并且await了，可以直接用基本类型T。

```
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

```

