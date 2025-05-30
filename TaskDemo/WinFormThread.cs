//namespace WinFormsThreadBlockDemo
//{
//    public partial class Form1 : Form
//    {
//        public Form1()
//        {
//            InitializeComponent();
//        }

//        private void button2_Click(object sender, EventArgs e)
//        {
//            this.textBox1.Text = "hello";
//        }

//        private async void button1_Click(object sender, EventArgs e)
//        {
//            //long sum = 0;
//            //for (long i = 1; i < 1000000000; i++)
//            //{
//            //    sum += (long)(Math.Sqrt(i) * i % i);
//            //}
//            //this.textBox1.Text = ""+sum;

//            long sum = await Task.Run(comp);
//            this.textBox1.Text = "" + sum;

//        }

//        Task<long> comp()
//        {
//            long sum = 0;
//            for (long i = 1; i < 1000000000; i++)
//            {
//                sum += (long)(Math.Sqrt(i) * i % i);
//            }

//            return Task.FromResult(sum);
//        }
//    }
//}
