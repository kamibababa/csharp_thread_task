//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TaskDemo
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;
//    using System.Threading;
//    using System.Threading.Tasks;

//    class BankAccount
//    {
//        public int Id { get; }
//        public decimal Balance { get; private set; }
//        private readonly object _lock = new object();

//        public BankAccount(int id, decimal initialBalance)
//        {
//            Id = id;
//            Balance = initialBalance;
//        }

//        public object Lock => _lock;

//        public void Deposit(decimal amount)
//        {
//            Balance += amount;
//        }

//        public void Withdraw(decimal amount)
//        {
//            if (amount > Balance)
//                throw new InvalidOperationException("Insufficient funds.");
//            Balance -= amount;
//        }
//    }

//    class Bank
//    {
//        private readonly List<BankAccount> _accounts;
//        private readonly Random _random = new Random();
//        private readonly object _randLock = new object(); // Random 线程不安全

//        public Bank(int count, decimal initialBalance)
//        {
//            _accounts = Enumerable.Range(1, count)
//                .Select(id => new BankAccount(id, initialBalance)).ToList();
//        }

//        public decimal GetTotalBalance()
//        {
//            return _accounts.Sum(acc => acc.Balance);
//        }

//        public async Task StartTransfersAsync(int taskCount, int transferPerTask)
//        {
//            var tasks = new List<Task>();

//            for (int i = 0; i < taskCount; i++)
//            {
//                tasks.Add(Task.Run(() =>
//                {
//                    for (int j = 0; j < transferPerTask; j++)
//                    {
//                        int fromId, toId;
//                        lock (_randLock)
//                        {
//                            fromId = _random.Next(_accounts.Count);
//                            do
//                            {
//                                toId = _random.Next(_accounts.Count);
//                            } while (toId == fromId);
//                        }

//                        var from = _accounts[fromId];
//                        var to = _accounts[toId];
//                        var amount = (decimal)_random.Next(1, 100);

//                        // 死锁预防：按账户 ID 顺序加锁
//                        BankAccount first = from.Id < to.Id ? from : to;
//                        BankAccount second = from.Id < to.Id ? to : from;

//                        BankAccount first =to;
//                        BankAccount second = from;

//                        lock (first.Lock)
//                        {
//                            lock (second.Lock)
//                            {
//                                if (from.Balance >= amount)
//                                {
//                                    from.Withdraw(amount);
//                                    to.Deposit(amount);
//                                    Console.WriteLine($"转账 {amount:C} 从账户 {from.Id} 到 {to.Id}");
//                                }
//                            }
//                        }
//                    }
//                }));
//            }

//            await Task.WhenAll(tasks);
//        }

//        public void PrintAccounts()
//        {
//            foreach (var acc in _accounts)
//            {
//                Console.WriteLine($"账户 {acc.Id} 余额: {acc.Balance:C}");
//            }
//            Console.WriteLine($"总余额校验：{GetTotalBalance():C}");
//        }
//    }

//    class Program
//    {
//        static async Task Main()
//        {
//            const int accountCount = 10;
//            const decimal initialBalance = 1000m;
//            const int tasks = 5;
//            const int transfersPerTask = 100;

//            var bank = new Bank(accountCount, initialBalance);
//            Console.WriteLine($"初始总余额：{bank.GetTotalBalance():C}");

//            await bank.StartTransfersAsync(tasks, transfersPerTask);

//            Console.WriteLine("\n转账结束，账户信息：");
//            bank.PrintAccounts();
//        }
//    }

//}
