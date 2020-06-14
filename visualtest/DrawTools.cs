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
        public void Selection(int deley)
        {
            int n = buttonArray.Length;

            // One by one move boundary of unsorted subarray 
            for (int i = 0; i < n - 1; i++)
            {
                // Find the minimum element in unsorted array 
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                {
                    //buttonArray[j].BackColor = Color.Red;
                    if (int.Parse(buttonArray[j].Text) < int.Parse(buttonArray[min_idx].Text))
                    {
                        
                        buttonArray[min_idx].BackColor = Color.White;
                        min_idx = j;
                        Thread.Sleep(deley);
                    }
                   // buttonArray[j].BackColor = Color.White;

                    buttonArray[min_idx].BackColor = Color.Yellow;
                }


                // Swap the found minimum element with the first 
                // element 
                buttonArray[min_idx].BackColor = Color.Red;
                SwapTwoElement(min_idx, i);
                
                buttonArray[min_idx].BackColor = Color.White;
            }
        }

        public void heapSort(int n)
        {
            for (int i = n / 2 - 1; i >= 0; i--)
                heapify( n, i);
            for (int i = n - 1; i >= 0; i--)
            {
                SwapTwoElement(0,i);
                heapify( i, 0);
            }
        }
         void heapify( int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < n && int.Parse(buttonArray[left].Text) > int.Parse(buttonArray[largest].Text))
                largest = left;
            if (right < n && int.Parse(buttonArray[right].Text) > int.Parse(buttonArray[largest].Text))
                largest = right;
            if (largest != i)
            {
                SwapTwoElement(i, largest);
                heapify(n, largest);
            }
        }

        public void InsertionSort(int deley)
        {
            for (int i = 0; i < buttonArray.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (int.Parse(buttonArray[j - 1].Text) > int.Parse(buttonArray[j].Text))
                    {
                        buttonArray[j].BackColor = Color.Red;
                        SwapTwoElement(j -1, j);
                        Thread.Sleep(deley);
                        buttonArray[j].BackColor = Color.White;
                    }
                }
            }
        }

            public void CoctaiSort(int deley)
        {
            bool isSwapped = true;
            int start = 0;
            int end = buttonArray.Length;

            while (isSwapped == true)
            {

                //Reset this flag.  It is possible for this to be true from a prior iteration.
                isSwapped = false;

                //Do a bubble sort on this array, from low to high.  If something changed, make isSwapped true.
                for (int i = start; i < end - 1; i++)
                {
                    if (int.Parse(buttonArray[i].Text) > int.Parse(buttonArray[i + 1].Text))
                    {
                       
                        SwapTwoElement(i, i + 1);
                        buttonArray[i].BackColor = Color.Red;
                        isSwapped = true;
                        buttonArray[i].BackColor = Color.White;
                    }
                }

                //If no swaps are made, the array is sorted.
                if (isSwapped == false)
                    return;

                //We need to reset the isSwapped flag for the high-to-low pass
                isSwapped = false;

                //The item we just moved is in its rightful place, so we no longer need to consider it unsorted.
                end = end - 1;

                //Now we bubble sort from high to low
                for (int i = end - 1; i > start; i--)
                {
                    if (int.Parse(buttonArray[i].Text) < int.Parse(buttonArray[i - 1].Text))
                    {
                        buttonArray[i].BackColor = Color.Red;
                        SwapTwoElement(i, i - 1);
                        
                        isSwapped = true;
                        buttonArray[i].BackColor = Color.White;
                    }
                }

                //Finally, we need to increase the starting point for the next low-to-high pass.
                start = start + 1;
                Thread.Sleep(deley);
            }
        }

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
        public void QuickSort(int start, int end,int deley)
        {
            int i;
            if (start < end)
            {
                i = Partition( start, end,deley);

                QuickSort( start, i - 1,deley);
                QuickSort(i + 1, end,deley);
            }
        }

        private int Partition(int start, int end,int deley)
        {
           
            int p = int.Parse(buttonArray[end].Text);
            int i = start - 1;

            for (int j = start; j <= end - 1; j++)
            {
                if (int.Parse(buttonArray[j].Text) <= p)
                {
                    i++;

                    buttonArray[j].BackColor = Color.Red;
                    SwapTwoElement(i, j);
                    
                    Thread.Sleep(deley);
                    buttonArray[j].BackColor = Color.White;
                }
            }

            SwapTwoElement(i + 1, end);
            return i + 1;
        }

        public void BubbleSort(int deley)
        {

            int count = 1;
            bool swaped = false;
            while (true)
            {
                for (int i = 0; i < buttonArray.Length-count; i++)
                {
                    try
                    {
                        if (int.Parse(buttonArray[i].Text) > int.Parse(buttonArray[i + 1].Text))
                        {
                            buttonArray[i].BackColor = Color.Red;
                            SwapTwoElement(i, i + 1);
                            
                            swaped = true;
                           
                            Thread.Sleep(deley);
                            buttonArray[i].BackColor = Color.White;
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


        public Panel forms { get; set; }
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
            Control.CheckForIllegalCrossThreadCalls = false;

        }

        public DrawTools(Panel form)
        {
            this.forms = form;
            Control.CheckForIllegalCrossThreadCalls = false;

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
            SetValueOfElement(index1, temp2);
            // buttonArray[int.Parse(temp2)].BackColor = SystemColors.Control;
            SetValueOfElement(index2, temp);


        }
       public void SetValueOfElement(int x,string value)
        {
            buttonArray[x].Text = value.ToString();
            //buttonArray[x].Height = (int.Parse(buttonArray[x].Text)+1);
            buttonArray[x].BackColor = Color.Red;
            SetHeightOfButton(buttonArray[x], int.Parse(buttonArray[x].Text));
            buttonArray[x].BackColor = Color.White;
           // buttonArray[x].Focus();
           // buttonArray[x].Select();
         
            
           
            
            

        }

        private void SetHeightOfButton(Button button,int value)
        {

            button.Height = (value + 1) + (int)((1.0/buttonArray.Length)*1000);
            
        }
        public void Perform(int n)
        {
            buttonArray = new Button[n];
            double wid = (1.0/n)*1000;
            //wid = 100;

            wid = Math.Round(wid);

            Button oldBtn = new Button
            {
                Location = new Point(0, 10),
                Width = int.Parse(wid.ToString()),
                //BackColor = Color.Blue
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White,




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
                SetHeightOfButton(button, a);
                ButtonArray[i] = button;
                //forms.Controls.Add(button);
                oldBtn = button;
            }
            

        }

    }
}

