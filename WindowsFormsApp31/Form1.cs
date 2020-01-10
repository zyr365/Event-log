using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using System.IO;


namespace WindowsFormsApp31
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private string str = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            Thread th1 = new Thread(test1);
            th1.Start();

            Thread th2 = new Thread(test2);
            th2.Start();

            timer1.Enabled = true;


        }
        public void test1()
        {
            try
            {
                if (!Directory.Exists(@"d:\test"))
                    Directory.CreateDirectory(@"d:\test");
                if (!File.Exists(@"d:\test\1.txt"))
                    File.Create(@"d:\test\1.txt").Close();

                StreamWriter sw = new StreamWriter(@"d:\test\1.txt", true);

                for (int i = 0; i < 100; i++)
                {
                    sw.WriteLine(i.ToString());

                }
                sw.Close();
                int k = 0;
                k = k / 0;//引发异常，写入事件log
            }
            catch(Exception ex)
            {
                StreamWriter sw = new StreamWriter(@"d:\test\1.txt", true);
                sw.WriteLine(ex.ToString());
                sw.Close();
            }
            
        }
        public void test2()
        {
            try
            {
                if (!Directory.Exists(@"d:\test"))
                    Directory.CreateDirectory(@"d:\test");
                if (!File.Exists(@"d:\test\2.txt"))
                    File.Create(@"d:\test\2.txt").Close();

                StreamWriter sw = new StreamWriter(@"d:\test\2.txt", true);

                for (int i = 0; i < 100; i++)
                {
                    sw.WriteLine(i.ToString());

                }
                sw.Close();
            }
            catch(Exception ex)
            {
                StreamWriter sw = new StreamWriter(@"d:\test\2.txt", true);
                sw.WriteLine(ex.ToString());
                sw.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            str += "1";
            richTextBox1.Text = str;
        }
    }
}
