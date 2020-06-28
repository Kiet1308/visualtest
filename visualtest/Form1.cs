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
            boxTim.DropDownStyle = ComboBoxStyle.DropDownList;
            boxTim.Items.Add(1);
            boxTim.Items.Add(2);
            boxTim.Items.Add(4);
            boxTim.Items.Add(8);
            boxTim.Items.Add(16);
            boxTim.Items.Add(32);
            boxTim.SelectedIndex = 3;
            Tools.RUN = int.Parse(boxTim.SelectedItem.ToString());

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
            Thread thread = new Thread(() => { Tools.IntroheapSort(0,arr.Length-1); MessageBox.Show("Done"); });
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

        private void Button11_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => { Tools.MySort(int.Parse(DeleyTime.Text)); MessageBox.Show("Done"); });
            thread.Start();
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => { Tools.DoubleSelect(int.Parse(DeleyTime.Text)); MessageBox.Show("Done"); });
            thread.Start();
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => { Tools.MergeSort(0,arr.Length-1); MessageBox.Show("Done"); });
            thread.Start();
        }

        private void Button14_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => { Tools.Set(); MessageBox.Show("Done"); });
            thread.Start();
        }

        private void Button15_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => { Tools.BinaryInse(); MessageBox.Show("Done"); });
            thread.Start();
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => { Tools.OddEvenSort(); MessageBox.Show("Done"); });
            thread.Start();
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => { Tools.CombSort(); MessageBox.Show("Done"); });
            thread.Start();
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => { Tools.BinaryIns(int.Parse(DeleyTime.Text)); MessageBox.Show("Done"); });
            thread.Start();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => { Tools.Quick_Sort2(0,arr.Length-1); MessageBox.Show("Done"); });
            thread.Start();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => { Tools.Quicksort3way(0, arr.Length - 1); MessageBox.Show("Done"); });
            thread.Start();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => { Tools.BubbleSort2(arr.Length); MessageBox.Show("Done"); });
            thread.Start();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => { Tools.timSort(arr.Length); MessageBox.Show("Done"); });
            thread.Start();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => { Tools.BuildHeap(); MessageBox.Show("Done"); });
            thread.Start();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => { Tools.BeadSort(); MessageBox.Show("Done"); });
            thread.Start();
        }

        private void boxTim_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tools.RUN = int.Parse(boxTim.SelectedItem.ToString());
            
        }

        private void button22_Click_1(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => { Tools.MergeSortMuti(0,arr.Length-1); MessageBox.Show("Done"); });
            thread.Start();
        }

        private void a_Click(object sender, EventArgs e)
        {
            int m = (int.Parse(m1.Text) + (int.Parse(m2.Text)-1)) / 2;
            Thread thread = new Thread(() => { Tools.Merge(int.Parse(m1.Text),m,int.Parse(m2.Text)); MessageBox.Show("Done"); });
            thread.Start();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => { Tools.mergeSortInplace(0,arr.Length-1); MessageBox.Show("Done"); });
            thread.Start();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => { Tools.radixsort(arr.Length,int.Parse(textBoxBase.Text)); MessageBox.Show("Done"); });
            thread.Start();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => { Tools.RadixMSD(); MessageBox.Show("Done"); });
            thread.Start();
        }

        private void button25_Click_1(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => { Tools.MutiQuick(0,arr.Length-1); MessageBox.Show("Done"); });
            thread.Start();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => { Tools.sortData(); MessageBox.Show("Done"); });
            thread.Start();
        }
    }
}
