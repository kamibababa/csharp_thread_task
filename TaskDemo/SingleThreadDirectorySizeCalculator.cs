//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TaskDemo
//{
//    using System;
//    using System.IO;
//    using System.Diagnostics;

//    class SingleThreadDirectorySizeCalculator
//    {
//        private static long totalSize = 0;


//        static void Main()
//        {
//            Console.WriteLine("请输入要统计的目录路径：");
//            string rootPath = Console.ReadLine();

//            if (!Directory.Exists(rootPath))
//            {
//                Console.WriteLine("目录不存在！");
//                return;
//            }

//            var stopwatch = Stopwatch.StartNew();

//            ProcessDirectory(rootPath);

//            stopwatch.Stop();

//            Console.WriteLine("\n统计完成！");
//            Console.WriteLine($"文件总大小：{totalSize:N0} 字节");

//            Console.WriteLine($"耗时：{stopwatch.Elapsed.TotalSeconds:F2} 秒");
//        }

//        static void ProcessDirectory(string path)
//        {
//            //Console.WriteLine($"进入目录：{path}");

//            try
//            {
//                foreach (var file in Directory.GetFiles(path))
//                {
//                    try
//                    {
//                        long size = new FileInfo(file).Length;
//                        totalSize += size;
//                        //Console.WriteLine($"访问文件：{file}，大小：{size:N0} 字节");
//                    }
//                    catch (Exception ex)
//                    {
//                        Console.WriteLine($"访问文件失败：{file}，错误：{ex.Message}");
//                    }
//                }

//                foreach (var dir in Directory.GetDirectories(path))
//                {
//                    ProcessDirectory(dir);
//                }
//            }
//            catch (Exception ex)
//            {
//                //Console.WriteLine($"访问目录失败：{path}，错误：{ex.Message}");
//            }
//        }
//    }

//}
