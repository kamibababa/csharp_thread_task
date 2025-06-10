//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TaskDemo
//{
//    using System;
//    using System.Diagnostics;
//    using System.IO;
//    using System.Threading;
//    using System.Threading.Tasks;

//    class TaskRunSizeCalculator
//    {
//        private static long totalSize = 0;
//        private static readonly object sizeLock = new object();
//        private static int pending = 0;
//        private static AutoResetEvent doneEvent = new AutoResetEvent(false);

//        static void Main(string[] args)
//        {
//            Console.WriteLine("请输入要统计的目录路径：");
//            string rootPath = Console.ReadLine();

//            if (!Directory.Exists(rootPath))
//            {
//                Console.WriteLine("目录不存在！");
//                return;
//            }
//            var stopwatch = Stopwatch.StartNew();
//            Interlocked.Increment(ref pending); // 根目录任务
//            Task.Run(() => ProcessDirectory(rootPath));
//            doneEvent.WaitOne();
//            stopwatch.Stop();
//            Console.WriteLine($"目录总大小为：{totalSize:N0} 字节");
//            Console.WriteLine($"耗时：{stopwatch.Elapsed.TotalSeconds:F2} 秒");
//        }

//        static void ProcessDirectory(string path)
//        {
//            try
//            {
//                foreach (var file in Directory.GetFiles(path))
//                {
//                    try
//                    {
//                        long size = new FileInfo(file).Length;
//                        lock (sizeLock)
//                        {
//                            totalSize += size;

//                            //Console.WriteLine($"访问文件：{file}，大小：{size:N0} 字节");
//                        }

//                    }
//                    catch { }
//                }

//                foreach (var dir in Directory.GetDirectories(path))
//                {
//                    Interlocked.Increment(ref pending);
//                    Task.Run(() => ProcessDirectory(dir));
//                }
//            }
//            catch { }

//            if (Interlocked.Decrement(ref pending) == 0)
//            {
//                doneEvent.Set();
//            }
//        }
//    }

//}
