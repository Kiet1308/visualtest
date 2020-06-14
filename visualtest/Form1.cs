using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace visualtest
{
    
    public partial class Form1 : Form
    {
       
        DrawTools Tools;
        Button[] arr;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Tools = new DrawTools(this.panel1);
            Console.WriteLine();
           
            
        }

     

        private void Form1_Load(object sender, EventArgs e)
        {
          
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = 0; int.TryParse(indexx.Text, out x);
            int value = 0; int.TryParse(val.Text, out value);

            Tools.SwapTwoElement(x, value);
        }

        private void Scramble_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => { Tools.Shuffle(); MessageBox.Show("Done"); });
            thread.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => { Tools.BubbleSort(int.Parse(DeleyTime.Text)); MessageBox.Show("Done"); });
            thread.Start();
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => { Tools.QuickSort(0,Tools.ButtonArray.Length-1, int.Parse(DeleyTime.Text)); MessageBox.Show("Done"); });
            thread.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {


            this.panel1.Controls.Clear();
            //Thread.Sleep(1);
           
                Tools.Perform(int.Parse(num.Text));
                arr = Tools.ButtonArray;
            Tools.Draw();
            
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => { Tools.Reverse(); MessageBox.Show("Done"); });
            thread.Start();
            //Tools.Reverse();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            this.panel1.Size = new Size(this.Width,this.Height-this.pnl.Height);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => { Tools.CoctaiSort(int.Parse(DeleyTime.Text)); MessageBox.Show("Done"); });
            thread.Start();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => { Tools.InsertionSort(int.Parse(DeleyTime.Text)); MessageBox.Show("Done"); });
            thread.Start();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => { Tools.heapSort(arr.Length); MessageBox.Show("Done"); });
            thread.Start();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => { Tools.Selection(int.Parse(DeleyTime.Text)); MessageBox.Show("Done"); });
            thread.Start();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => { Tools.shellSort(); MessageBox.Show("Done"); });
            thread.Start();
        }
    }
}
