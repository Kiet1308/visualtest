using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace visualtest
{
    public class DrawTools
    {
        public void Reverse()
        {
            int a = buttonArray.Length-1;
            for (int i = 0; i < buttonArray.Length/2; i++)
            {
                SwapTwoElement(i, a);
                a--;
                Thread.Sleep(10);
            }

        }
        public void QuickSort(int start, int end)
        {
            int i;
            if (start < end)
            {
                i = Partition( start, end);

                QuickSort( start, i - 1);
                QuickSort(i + 1, end);
            }
        }

        private int Partition(int start, int end)
        {
           
            int p = int.Parse(buttonArray[end].Text);
            int i = start - 1;

            for (int j = start; j <= end - 1; j++)
            {
                if (int.Parse(buttonArray[j].Text) <= p)
                {
                    i++;
                    SwapTwoElement(i, j);
                   // Thread.Sleep(10);
                }
            }

            SwapTwoElement(i + 1, end);
            return i + 1;
        }

        public void BubbleSort()
        {

            int count = 0;
            bool swaped = false;
            while (true)
            {
                for (int i = 0; i < buttonArray.Length-count; i++)
                {
                    try
                    {
                        if (int.Parse(buttonArray[i].Text) > int.Parse(buttonArray[i + 1].Text))
                        {
                            SwapTwoElement(i, i + 1);
                            swaped = true;
                            //  Thread.Sleep(1);
                        }
                    }
                    catch (Exception)
                    {

                        
                    }
                   
                }
                if (swaped == true)
                {
                    swaped = false;
                }
                else
                {
                    return;
                }
                count++;
                
            }

                
           
                

            
        }
       public void Shuffle(int sleep)
        {
            Random r = new Random();
            //Step 1: For each unshuffled item in the collection
            for (int n = buttonArray.Length - 1; n > 0; --n)
            {
                //Step 2: Randomly pick an item which has not been shuffled
                int k = r.Next(n + 1);

                //Step 3: Swap the selected item with the last "unstruck" item in the collection
                SwapTwoElement(k, n);
                if(sleep !=-1)
                Thread.Sleep(sleep);
            }
            
        }
        public void Shuffle()
        {
            Shuffle(-1);

        }


        public Form forms { get; set; }
        private Button[] buttonArray;
       public Button[] ButtonArray { 
            get
            {
                return buttonArray;

            }
            set
            {
                buttonArray = value;

            }
       }
        public DrawTools()
        {
            

        }

        public DrawTools(Form form)
        {
            this.forms = form;

        }
        public void Draw()
        {
            foreach (var item in ButtonArray)
            {
                forms.Controls.Add(item);
                item.Click += Item_Click;
                
            }
        }

        private void Item_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            MessageBox.Show(button.Text);
        }

        public void SwapTwoElement(int index1,int index2)
        {
            var temp = buttonArray[index1].Text;
            var temp2 = buttonArray[index2].Text;
           // buttonArray[index1].BackColor = Color.Red;
            SetHeightOfElement(index1, temp2);
           // buttonArray[int.Parse(temp2)].BackColor = SystemColors.Control;
            SetHeightOfElement(index2, temp);


        }
       public void SetHeightOfElement(int x,string value)
        {
            buttonArray[x].Text = value.ToString();
            buttonArray[x].Height = (int.Parse(buttonArray[x].Text)+1);
            buttonArray[x].Focus();
            
            buttonArray[x].Select();
            
            

        }
        public void Perform(int n)
        {
            buttonArray = new Button[n];
            double wid = (1.0/n)*1000;
            wid = Math.Round(wid);

            Button oldBtn = new Button
            {
                Location = new Point(0, 100),
                Width = int.Parse(wid.ToString()),
                //BackColor = Color.Blue
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Yellow,




            };
            oldBtn.FlatAppearance.BorderSize = 0;
            //Button[] arr = new Button[n];
            for (int i = 0; i < n; i++)
            {
                Button button = new Button();
                button.Location = new Point((oldBtn.Location.X + oldBtn.Width), oldBtn.Location.Y);
                button.Text = i.ToString();
                button.Width = oldBtn.Width;
                button.BackColor = oldBtn.BackColor;
                button.FlatStyle = oldBtn.FlatStyle;
                button.FlatAppearance.BorderSize = 0;
                button.Tag = "C";
                int a = 0;
                int.TryParse(button.Text, out a);
                button.Height = (a + 1);
                ButtonArray[i] = button;
                //forms.Controls.Add(button);
                oldBtn = button;
            }
            

        }

    }
}

