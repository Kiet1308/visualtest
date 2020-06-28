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
        public void MergeSortMuti(
                         int l, int r)
        {
            if (l < r)
            {

                // Same as (l+r)/2 but avoids  
                // overflow for large l & h 
                int m = l + (r - l) / 2;
                Thread thread = new Thread(() => { MergeSortMuti(l, m); });
                thread.Start();
                MergeSortMuti(m + 1, r);
                Merge(l, m, r);
            }
        }
        public void MutiQuick(int l, int r)
        {
            if (l > r)
            {
                return;
            }
            int p = MyPr(l, r);
             MutiQuick( l, p - 1); 
             MutiQuick(p + 1, r); 
            



        }
            
            
            

           

           

            

           // MutiQuick(p + 1, r);
        

        private void IntroMaxHeap(int i, int heapN, int begin)
        {
            int temp = int.Parse(buttonArray[begin + i - 1].Text);
            int child;

            while (i <= heapN / 2)
            {
                child = 2 * i;

                if (child < heapN
                    && int.Parse(buttonArray[begin + child - 1].Text) < int.Parse(buttonArray[begin + child].Text))
                    child++;

                if (temp >= int.Parse(buttonArray[begin + child - 1].Text))
                    break;

              //  a[begin + i - 1] = a[begin + child - 1];
                SetValueOfElement(begin + i - 1, buttonArray[begin + child - 1].Text);
                i = child;
            }
            SetValueOfElement(begin + i - 1, temp.ToString());
          //  a[begin + i - 1] = temp; 
        }

        // Function to build the heap (rearranging the array) 
        private void Introheapify(int begin, int end, int heapN)
        {
            for (int i = (heapN) / 2; i >= 1; i--)
                IntroMaxHeap(i, heapN, begin);
        }

        // main function to do heapsort 
        public void IntroheapSort(int begin, int end)
        {
            int heapN = end - begin;

            // Build heap (rearrange array) 
            Introheapify(begin, end, heapN);

            // One by one extract an element from heap 
            for (int i = heapN; i >= 1; i--)
            {

                // Move current root to end 
                SwapTwoElement(begin, begin + i);

                // call maxHeap() on the reduced heap 
                IntroMaxHeap(1, i, begin);
            }
        }

        // function that implements insertion sort 
        private void IntroSelect(int left, int right)
        {

            for (int i = left; i <= right; i++)
            {
                int key = int.Parse(buttonArray[i].Text);
                int j = i;

                // Move elements of arr[0..i-1], that are 
                // greater than the key, to one position ahead 
                // of their current position 
                while (j > left && int.Parse(buttonArray[j-1].Text) > key)
                {
                    SetValueOfElement(j, buttonArray[j - 1].Text);
                   //[j] = a[j - 1];
                    j--;
                }
                SetValueOfElement(j, key.ToString());
            }
        }

        // Function for finding the median of the three elements 
        private int IntrofindPivot(int a1, int b1, int c1)
        {
            int max = Math.Max(Math.Max(int.Parse(buttonArray[a1].Text), int.Parse(buttonArray[b1].Text)), int.Parse(buttonArray[c1].Text));
            int min = Math.Min(Math.Min(int.Parse(buttonArray[a1].Text), int.Parse(buttonArray[b1].Text)), int.Parse(buttonArray[c1].Text));
            int median = max ^ min ^ int.Parse(buttonArray[a1].Text) ^ int.Parse(buttonArray[b1].Text) ^ int.Parse(buttonArray[c1].Text);
            if (median == int.Parse(buttonArray[a1].Text))
                return a1;
            if (median == int.Parse(buttonArray[b1].Text))
                return b1;
            return c1;
        }

        // This function takes the last element as pivot, places 
        // the pivot element at its correct position in sorted 
        // array, and places all smaller (smaller than pivot) 
        // to the left of the pivot 
        // and greater elements to the right of the pivot 
        private int IntroPartition(int low, int high)
        {

            // pivot 
            int pivot = int.Parse(buttonArray[high].Text);

            // Index of smaller element 
            int i = (low - 1);
            for (int j = low; j <= high - 1; j++)
            {

                // If the current element is smaller 
                // than or equal to the pivot 
                if (int.Parse(buttonArray[j].Text) <= pivot)
                {

                    // increment index of smaller element 
                    i++;
                    SwapTwoElement(i, j);
                }
            }
            SwapTwoElement(i + 1, high);
            return (i + 1);
        }

        // The main function that implements Introsort 
        // low  --> Starting index, 
        // high  --> Ending index, 
        // depthLimit  --> recursion level 
        private void sortDataUtil(int begin, int end, int depthLimit)
        {
            if (end - begin > 16)
            {
                if (depthLimit == 0)
                {

                    // if the recursion limit is 
                    // occurred call heap sort 
                    IntroheapSort(begin, end);
                    return;
                }

                depthLimit = depthLimit - 1;
                int pivot = IntrofindPivot(begin,
                    begin + ((end - begin) / 2) + 1,
                                               end);
                SwapTwoElement(pivot, end);

                // p is partitioning index, 
                // arr[p] is now at right place 
                int p = IntroPartition(begin, end);

                // Separately sort elements before 
                // partition and after partition 
                sortDataUtil(begin, p - 1, depthLimit);
                sortDataUtil(p + 1, end, depthLimit);
            }

            else
            {
                // if the data set is small, 
                // call insertion sort 
                IntroSelect(begin, end);
            }
        }

        // A utility function to begin the 
        // Introsort module 
        public void sortData()
        {

            // Initialise the depthLimit  
            // as 2*log(length(data)) 
            int n = buttonArray.Length-1;
            int depthLimit
                = (int)(2 * Math.Floor(Math.Log(n) /
                                      Math.Log(2)));

            sortDataUtil(0, n - 1, depthLimit);
        }

        // A utility function to print the array data 
        

        public void BringToLast(int l,int r)
        {
            for (int i = l; i < r; i++)
            {

            }

        }
        public void MyQuick(int l, int r)
        {
            int p;
            if (l>=r)
            {
                return;
            }
           

           p = MyPr(l,r);
           
           
            MyQuick(l,p-1);
            MyQuick(p + 1, r);


        }
        int MyPr(int l, int r)
        {
            int p = r;
            int piv = int.Parse(buttonArray[p].Text);
            
            int i = l-1;
            while (true)
            {
                if (l>r)
                {
                    break;
                }
                while (int.Parse(buttonArray[l].Text)<=piv&&l<r)
                {
                    l++;
                }
                while (int.Parse(buttonArray[r].Text) >= piv && l < r)
                {
                    r++;
                }
                if (int.Parse(buttonArray[l].Text)< int.Parse(buttonArray[r].Text))
                {
                    SwapTwoElement(l, r);
                }

            }
            //buttonArray[i+1].BackColor = Color.Purple;
            SwapTwoElement(p, l);
            return l;

        }

      public void RadixMSD()
        {
            
            int numberOfDigits = getMax(int.Parse(buttonArray[buttonArray.Length-1].Text));
            int placeValue = 1;
            for (int i = 0; i < numberOfDigits; i++)
            {
                applyCountingSortOns(placeValue);
                placeValue *= 10;
            }
          
        }

        void applyCountingSortOns(int placeValue)
        {

            int range = 10; // decimal system, numbers from 0-9

            // ...
            int length = buttonArray.Length;
            int[] frequency = new int[range];
            int[] sortedValues = new int[length];
            // calculate the frequency of digits
            for (int i = 0; i < buttonArray.Length; i++)
            {
                int digit = 0;
                try
                {
                    digit = (int.Parse(buttonArray[i].Text) / placeValue) % range;
                }
                catch (Exception)
                {

                    
                }
                
                frequency[digit]++;
            }

            for (int i = 1; i < range; i++)
            {
                frequency[i] += frequency[i - 1];
            }

            for (int i = length - 1; i >= 0; i--)
            {
                int digit = 0;
                try
                {
                    digit = (int.Parse(buttonArray[i].Text) / placeValue) % range;
                }
                catch(Exception)
                {


                }
                sortedValues[frequency[digit] - 1] = int.Parse(buttonArray[i].Text);
                frequency[digit]--;
            }

            for (int i = 0; i < sortedValues.Length; i++)
            {
                SetValueOfElement(i, sortedValues[i].ToString());
            }

        }
        int getMax(int n)
        {
            int mx = int.Parse(buttonArray[0].Text);
            for (int i = 1; i < n; i++)
                if (int.Parse(buttonArray[i].Text) > mx)
                    mx = int.Parse(buttonArray[i].Text);
            return mx;
        }

        // A function to do counting sort of arr[] according to  
        // the digit represented by exp.  
        void countSort(int n, int exp)
        {
            int[] output = new int[n]; // output array  
            int i;
            int[] count = new int[10];

            //initializing all elements of count to 0 
            for (i = 0; i < 10; i++)
                count[i] = 0;

            // Store count of occurrences in count[]  
            for (i = 0; i < n; i++)
                count[(int.Parse(buttonArray[i].Text) / exp) % 10]++;

            // Change count[i] so that count[i] now contains actual  
            //  position of this digit in output[]  
            for (i = 1; i < 10; i++)
                count[i] += count[i - 1];

            // Build the output array  
            for (i = n - 1; i >= 0; i--)
            {
                output[count[(int.Parse(buttonArray[i].Text) / exp) % 10] - 1] = int.Parse(buttonArray[i].Text);
                count[(int.Parse(buttonArray[i].Text) / exp) % 10]--;
            }

            // Copy the output array to arr[], so that arr[] now  
            // contains sorted numbers according to current digit  
            for (i = 0; i < n; i++)
            {
               // arr[i] = output[i];
                SetValueOfElement(i, output[i].ToString());
            }
                
        }

        // The main function to that sorts arr[] of size n using   
        // Radix Sort  
        public void radixsort(int n,int bbase)
        {
            // Find the maximum number to know number of digits  
            int m = getMax(n);

            // Do counting sort for every digit. Note that instead  
            // of passing digit number, exp is passed. exp is 10^i  
            // where i is current digit number  
            for (int exp = 1; m / exp > 0; exp *= bbase)
            {
               
                countSort(n, exp);
                
            }
                
        }

        void mergeInplace(int start, int mid, int end)
        {
            if (start>end || end <mid)
            {
                return;
            }
            int start2 = mid + 1;

            // If the direct merge is already sorted 
            try
            {
                if (int.Parse(buttonArray[mid].Text) <= int.Parse(buttonArray[start2].Text))
                {
                    return;
                }

            }
            catch (Exception)
            {

                
            }
           
            // Two pointers to maintain start 
            // of both arrays to merge 
            while (start <= mid && start2 <= end)
            {

                try
                {
                    if (int.Parse(buttonArray[start].Text) <= int.Parse(buttonArray[start2].Text))
                    {
                        start++;
                    }
                    else
                    {
                        int value = int.Parse(buttonArray[start2].Text);
                        int index = start2;

                        // Shift all the elements between element 1 
                        // element 2, right by 1. 
                        while (index != start)
                        {
                            //arr[index] = arr[index - 1];
                            SetValueOfElement(index, buttonArray[index - 1].Text);
                            index--;
                        }
                        SetValueOfElement(start, value.ToString());

                        // Update all the pointers 
                        start++;
                        mid++;
                        start2++;
                    }
                }
                catch (Exception)
                {

                    
                }
                // If element 1 is in right place 
                
            }
        }

        /* l is for left index and r is right index of the  
        sub-array of arr to be sorted */
        public void mergeSortInplace( int l, int r)
        {
            if (l < r)
            {

                // Same as (l + r) / 2, but avoids overflow 
                // for large l and r 
                int m = l + (r - l) / 2;

                // Sort first and second halves 
                mergeSortInplace( l, m);
                mergeSortInplace( m + 1, r);

                mergeInplace( l, m, r);
            }
        }


        public void Test()
        {
            int mid = (buttonArray.Length-1) / 4;
            Quicksort3way(0,mid);
            MergeSort(mid+1,mid*2);
            Merge(0,mid,mid*2);

            mid = (buttonArray.Length-1)/2;
            int a = (buttonArray.Length) - (mid / 2);
            Quicksort3way(mid, a);
           MergeSort(a, buttonArray.Length - 1);
            // Thread.Sleep(1000);
           // a = (mid + (buttonArray.Length - 1)) / 2;
            Merge(mid,a,buttonArray.Length-1);
           // Merge(0, mid, buttonArray.Length - 1);
            int r = 32;
            //for (int i = 0; i < buttonArray.Length; i+=r)
            //{
            //    try
            //    {
            //       // mid = mid / 2;
            //        Quicksort3way(i, i+(r-1));
            //    }
            //    catch (Exception)
            //    {

                    
            //    }
                
            //    //Quicksort3way(mid, i+4);
            //}
           

        }
        public void BeadSort()
        {
            int i, j, max, sum;
            byte[] beads;

            for (i = 1, max = int.Parse(buttonArray[0].Text); i < buttonArray.Length; ++i)
                if (int.Parse(buttonArray[i].Text) > max)
                    max = int.Parse(buttonArray[i].Text);

            beads = new byte[max * buttonArray.Length];

            for (i = 0; i < buttonArray.Length; ++i)
                for (j = 0; j < int.Parse(buttonArray[i].Text); ++j)
                    beads[i * max + j] = 1;

            for (j = 0; j < max; ++j)
            {
                for (sum = i = 0; i < buttonArray.Length; ++i)
                {
                    sum += beads[i * max + j];
                    beads[i * max + j] = 0;
                }

                for (i = buttonArray.Length - sum; i < buttonArray.Length; ++i)
                    beads[i * max + j] = 1;
            }

            for (i = 0; i < buttonArray.Length; ++i)
            {
                for (j = 0; j < max && Convert.ToBoolean(beads[i * max + j]); ++j) ;
                SetValueOfElement(i, j.ToString());
            }
        }
        void CoctaiSortTim(int start,int end)
        {
            bool isSwapped = true;
           

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
                
            }
        }
         void OddEvenSortTim(int l, int r)
        {
            bool isSorted = false;
            if (l>r)
            {
                return;
            }
            int length = (r + 1) - l;                                             ;

            while (!isSorted)
            {
                isSorted = true;

                //Swap i and i+1 if they are out of order, for i == odd numbers
                for (int i = l+1; i <= r - 2; i = i + 2)
                {
                    if (int.Parse(buttonArray[i].Text) > int.Parse(buttonArray[i + 1].Text))
                    {
                        SwapTwoElement(i, i + 1);
                        isSorted = false;
                    }
                }

                //Swap i and i+1 if they are out of order, for i == even numbers
                for (int i = l; i <= r - 2; i = i + 2)
                {
                    if (int.Parse(buttonArray[i].Text) > int.Parse(buttonArray[i + 1].Text))
                    {
                        SwapTwoElement(i, i + 1);
                        isSorted = false;

                    }
                }
            }
            return;
        }
         void BubbleSortTim(int l,int r)
        {
            if (l>r)
            {
                return;
            }
            int count = 1;
            bool swaped = false;
            while (true)
            {
                for (int i = l+1; i <= r; i++)
                {
                    try
                    {
                        if (int.Parse(buttonArray[i].Text) > int.Parse(buttonArray[i + 1].Text))
                        {
                            
                            SwapTwoElement(i, i + 1);

                            swaped = true;

                            
                            
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
        public void BuildHeap()
        {
            for (int i = buttonArray.Length / 2 - 1; i >= 0; i--)
                heapify(buttonArray.Length, i);
            

           
        }
        public int RUN { get; set; } = 8;

        // this function sorts array from left index to  
        // to right index which is of size atmost RUN  
        public void insertionSortTim(int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                int temp = int.Parse(buttonArray[i].Text);
                int j = i - 1;
                while (j >= left && int.Parse(buttonArray[j].Text) > temp)
                {
                    SetValueOfElement(j + 1, buttonArray[j].Text);
                    
                    j--;
                }
                SetValueOfElement(j + 1, temp.ToString());
            }
        }

        // merge function merges the sorted runs  
        public void mergeTim(int l, int m, int r)
        {
            // original array is broken in two parts  
            // left and right array  
            if (r < l || m>r)
            {
                return;
            }
            int len1 = m - l + 1, len2 = r - m;
            int[] left = new int[len1];
            int[] right = new int[len2];
            for (int x = 0; x < len1; x++)
                left[x] = int.Parse(buttonArray[l + x].Text);
            for (int x = 0; x < len2; x++)
                right[x] = int.Parse(buttonArray[m + 1 + x].Text);

            int i = 0;
            int j = 0;
            int k = l;
           
            // after comparing, we merge those two array  
            // in larger sub array  
            while (i < len1 && j < len2)
            {
                if (left[i] <= right[j])
                {
                    SetValueOfElement(k, left[i].ToString());
                   
                    i++;
                }
                else
                {
                    SetValueOfElement(k, right[j].ToString());
                   // arr[k] = right[j];
                    j++;
                }
                k++;
            }

            // copy remaining elements of left, if any  
            while (i < len1)
            {
                SetValueOfElement(k, left[i].ToString());
                k++;
                i++;
            }

            // copy remaining element of right, if any  
            while (j < len2)
            {
                SetValueOfElement(k, right[j].ToString());
                k++;
                j++;
            }
        }

        // iterative Timsort function to sort the  
        // array[0...n-1] (similar to merge sort)  
        public void timSort(int n)
        {
            // Sort individual subarrays of size RUN  
            for (int i = 0; i < n; i += RUN)
            {
                Quicksort3way(i, Math.Min((i + (RUN-1)), (n - 1)));

            }

            // start merging from size RUN (or 32). It will merge  
            // to form size 64, then 128, 256 and so on ....  
            for (int size = RUN; size < n; size = 2 * size)
            {
                // pick starting point of left sub array. We  
                // are going to merge arr[left..left+size-1]  
                // and arr[left+size, left+2*size-1]  
                // After every merge, we increase left by 2*size  
                for (int left = 0; left < n; left += 2 * size)
                {
                    // find ending point of left sub array  
                    // mid+1 is starting point of right sub array  
                    int mid = left + size - 1;
                    int right = Math.Min((left + 2 * size - 1), (n - 1));

                    // merge sub array arr[left.....mid] &  
                    // arr[mid+1....right]  
                     Merge(left, mid, right);
                   // Quicksort3way(left,right);                
                }
            }
        }
        public void BubbleSort2(int n)
        {
            // Base case 
            if (n == 1)
                return;

            // One pass of bubble  
            // sort. After this pass, 
            // the largest element 
            // is moved (or bubbled)  
            // to end. 
            for (int i = 0; i < n - 1; i++)
                if (int.Parse(buttonArray[i].Text) > int.Parse(buttonArray[i + 1].Text))
                {
                    // swap arr[i], arr[i+1] 
                    SwapTwoElement(i, i + 1);
                }

            // Largest element is fixed, 
            // recur for remaining array 
            BubbleSort2( n - 1);
        }
        public void MergeSort(
                           int l, int r)
        {
            if (l < r)
            {

                // Same as (l+r)/2 but avoids  
                // overflow for large l & h 
                int m = l + (r - l) / 2;
                MergeSort( l, m);
                MergeSort( m + 1, r);
                Merge( l, m, r);
            }
        }

        /* Function to merge the two haves 
        arr[l..m] and arr[m+1..r] of array  
        arr[] */
        public void Merge(int l,
                               int m, int r)
        {
            
            if (l > r || m > r) return;
            int i, j, k;
            int n1 = m - l + 1;
            int n2 = r - m;
            
            /* create temp arrays */
            int[] L = new int[n1];
            int[] R = new int[n2];

            /* Copy data to temp arrays 
            L[] and R[] */
            for (i = 0; i < n1; i++)

                L[i] = int.Parse(buttonArray[l + i].Text);
            for (j = 0; j < n2; j++)
                R[j] = int.Parse(buttonArray[m + 1 + j].Text);

            /* Merge the temp arrays back  
            into arr[l..r]*/
            i = 0;
            j = 0;
            k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    SetValueOfElement(k, L[i].ToString());
                    i++;
                }
                else
                {
                    SetValueOfElement(k, R[j].ToString());
                    //arr[k] = R[j];
                    j++;
                }
                k++;
            }

            /* Copy the remaining elements of 
            L[], if there are any */
            while (i < n1)
            {
                SetValueOfElement(k, L[i].ToString());
                i++;
                k++;
            }

            /* Copy the remaining elements of 
            R[], if there are any */
            while (j < n2)
            {
                SetValueOfElement(k, R[j].ToString());
                j++;
                k++;
            }
        }

       
        private void Reverse1(int s, int e)
        {
            int i = s, j = e;

            while (i < j)
            {
                SwapTwoElement(i++,j--);
            }
        }

        static void Swap(ref int x, ref int y)
        {
            x ^= y;
            y ^= x;
            x ^= y;
        }
        public void partition3(int l, int r, ref int i, ref int j)
        {
            i = l - 1; j = r;
            int p = l - 1, q = r;
            int v = int.Parse(buttonArray[r].Text);

            while (true)
            {
                // From left, find the first element greater than  
                // or equal to v. This loop will definitely terminate  
                // as v is last element  
                while (int.Parse(buttonArray[++i].Text) < v) ;

                // From right, find the first element smaller than or  
                // equal to v  
                while (v < int.Parse(buttonArray[--j].Text))
                    if (j == l)
                        break;

                // If i and j cross, then we are done  
                if (i >= j) break;

                // Swap, so that smaller goes on left greater goes on right  
                SwapTwoElement(i, j);

                // Move all same left occurrence of pivot to beginning of  
                // array and keep count using p  
                if (int.Parse(buttonArray[i].Text) == v)
                {
                    p++;
                    SwapTwoElement(p, i);
                }

                // Move all same right occurrence of pivot to end of array  
                // and keep count using q  
                if (int.Parse(buttonArray[j].Text) == v)
                {
                    q--;
                    SwapTwoElement(j,q);
                }
            }

            // Move pivot element to its correct index  
            SwapTwoElement(i, r);

            // Move all left same occurrences from beginning  
            // to adjacent to arr[i]  
            j = i - 1;
            for (int k = l; k < p; k++, j--)
                SwapTwoElement(k, j);

            // Move all right same occurrences from end  
            // to adjacent to arr[i]  
            i = i + 1;
            for (int k = r - 1; k > q; k--, i++)
                SwapTwoElement(i, k);
        }

        // 3-way partition based quick sort  
        public void Quicksort3way(int l, int r)
        {
            if (r <= l) return;

            int i = 0, j = 0;

            // Note that i and j are passed as reference  
            partition3( l, r, ref i, ref j);

            // Recur  
            Quicksort3way( l, j);
            Quicksort3way( i, r);
        }

        public void Quick_Sort2(int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition2(left, right);

                if (pivot > 1)
                {
                    Quick_Sort2( left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    Quick_Sort2( pivot + 1, right);
                }
            }

        }

        private int Partition2( int left, int right)
        {
            int pivot = int.Parse(buttonArray[left].Text);
            while (true)
            {

                while (int.Parse(buttonArray[left].Text) < pivot)
                {
                    left++;
                }

                while (int.Parse(buttonArray[right].Text) > pivot)
                {
                    right--;
                }
                Console.WriteLine();
                if (left < right)
                {
                    if (int.Parse(buttonArray[left].Text) == int.Parse(buttonArray[right].Text)) return right;

                    SwapTwoElement(left, right);


                }
                else
                {
                    return right;
                }
            }
        }
        int binarySearch(int item, int low, int high)
        {
            if (high <= low)
                return (item > int.Parse(buttonArray[low].Text)) ? (low + 1) : low;

            int mid = (low + high) / 2;

            if (item == int.Parse(buttonArray[mid].Text))
                return mid + 1;

            if (item > int.Parse(buttonArray[mid].Text))
                return binarySearch( item, mid + 1, high);
            return binarySearch( item, low, mid - 1);
        }

       public void BinaryIns(int deley)
        {
            int i, loc, j, k, selected;
            int n = buttonArray.Length;

            for (i = 1; i < n; ++i)
            {
                j = i - 1;
                selected = int.Parse(buttonArray[i].Text);

                // find location where selected sould be inseretd 
                loc = binarySearch(selected, 0, j);
                buttonArray[loc].BackColor = Color.Purple;

                // Move all elements after location to create space 

                //SwapTwoElement(i, loc);
                while (j >= loc)
                {
                    
                    SetValueOfElement(j + 1, buttonArray[j].Text);
                    buttonArray[j].BackColor = Color.Red;
                    Thread.Sleep(deley);
                    buttonArray[j].BackColor = Color.White;
                    j--;    

                }
                SetValueOfElement(j + 1, selected.ToString());
                buttonArray[loc].BackColor = Color.White;
            }
        }
        public int GetNextGap(int gap)
        {
            //The "shrink factor", empirically shown to be 1.3
            gap = (gap * 10) / 13;
            if (gap < 1)
            {
                return 1;
            }
            return gap;
        }

        public void CombSort()
        {
            int length = buttonArray.Length;

            int gap = length;

            //We initialize this as true to enter the while loop.
            bool swapped = true;

            while (gap != 1 || swapped == true)
            {
                gap = GetNextGap(gap);

                //Set swapped as false.  Will go to true when two values are swapped.
                swapped = false;

                //Compare all elements with current gap 
                for (int i = 0; i < length - gap; i++)
                {
                    if (int.Parse(buttonArray[i].Text) > int.Parse(buttonArray[i + gap].Text))
                    {
                        //Swap
                        SwapTwoElement(i, i + gap);

                        swapped = true;
                    }
                }
            }
        }
        public void OddEvenSort()
        {
            bool isSorted = false;
            int length = buttonArray.Length;

            while (!isSorted)
            {
                isSorted = true;

                //Swap i and i+1 if they are out of order, for i == odd numbers
                for (int i = 1; i <= length - 2; i = i + 2)
                {
                    if (int.Parse(buttonArray[i].Text) > int.Parse(buttonArray[i + 1].Text))
                    {
                        SwapTwoElement(i, i + 1);
                        isSorted = false;
                    }
                }

                //Swap i and i+1 if they are out of order, for i == even numbers
                for (int i = 0; i <= length - 2; i = i + 2)
                {
                    if (int.Parse(buttonArray[i].Text) > int.Parse(buttonArray[i + 1].Text))
                    {
                        SwapTwoElement(i, i + 1);
                        isSorted = false;
                        
                    }
                }
            }
            return;
        }
        public void BinaryInse()
        {
            for (int i = 1; i < buttonArray.Length; i++)
            {
                int low = 0;
                int high = i - 1;
                Button temp = buttonArray[i];
                //Find
                while (low <= high)
                {
                    int mid = (low + high) / 2;
                    if (int.Parse(temp.Text) < int.Parse(buttonArray[mid].Text))
                        high = mid - 1;
                    else
                        low = mid + 1;
                }
                //backward shift
                for (int j = i - 1; j >= low; j--)
                {
                    SetValueOfElement(j + 1, buttonArray[j].Text);
                }

                SetValueOfElement(low, temp.Text);


            }
           
        }
    
       public int[] arr;
    public void Set()
        {
            for (int i = 0; i < buttonArray.Length; i++)
            {
                SetValueOfElement(i, buttonArray[i].Text);
            }

        }
         
        public void DoubleSelect(int deley)
        {
            int n = buttonArray.Length;
            for (int i = 0, j = n - 1;
                     i < j; i++, j--)
            {
                int min = int.Parse(buttonArray[i].Text), max = int.Parse(buttonArray[i].Text);
                int min_i = i, max_i = i;
                for (int k = i; k <= j; k++)
                {
                    if (int.Parse(buttonArray[k].Text) > max)
                    {
                        max = int.Parse(buttonArray[k].Text);
                        max_i = k;
                    }

                    else if (int.Parse(buttonArray[k].Text) < min)
                    {
                        min = int.Parse(buttonArray[k].Text);
                        min_i = k;
                    }
                }

                // shifting the min. 
                SwapTwoElement(i, min_i);

                // Shifting the max. The equal condition 
                // happens if we shifted the max to arr[min_i]  
                // in the previous swap. 
                if (int.Parse(buttonArray[min_i].Text) == max)
                    SwapTwoElement(j, min_i);
                else
                SwapTwoElement( j, max_i);
                Thread.Sleep(deley);
            }
        }

        public void MySort(int deley)
        {
            int n = buttonArray.Length;
            for (int i = 0; i < n-1; i++)
            {
                for (int j = i; j < n; j++)
                {
                    if (int.Parse(buttonArray[j].Text) < int.Parse(buttonArray[i].Text))
                    {
                        buttonArray[j].BackColor = Color.Red;
                        SwapTwoElement(i, j);
                        Thread.Sleep(deley);
                        buttonArray[j].BackColor = Color.White;
                    }
                }
            }

        }
        public void shellSort()
        {
            int n = buttonArray.Length;

            // Start with a big gap,  
            // then reduce the gap 
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                // Do a gapped insertion sort for this gap size. 
                // The first gap elements a[0..gap-1] are already 
                // in gapped order keep adding one more element 
                // until the entire array is gap sorted 
                for (int i = gap; i < n; i += 1)
                {
                    // add a[i] to the elements that have 
                    // been gap sorted save a[i] in temp and 
                    // make a hole at position i 
                    int temp = int.Parse(buttonArray[i].Text);

                    // shift earlier gap-sorted elements up until 
                    // the correct location for a[i] is found 
                    int j;
                    for (j = i; j >= gap && int.Parse(buttonArray[j-gap].Text) > temp; j -= gap)
                    {
                        SetValueOfElement(j, buttonArray[j - gap].Text);
                       // arr[j] = arr[j - gap];
                    }


                    // put temp (the original a[i])  
                    // in its correct location 
                    SetValueOfElement(j, temp.ToString());
                   //
                    arr[j] = temp;
                }
            }
        }

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
                    buttonArray[j].BackColor = Color.Red;
                    if (int.Parse(buttonArray[j].Text) < int.Parse(buttonArray[min_idx].Text))
                    {
                        
                        buttonArray[min_idx].BackColor = Color.White;
                        min_idx = j;
                        
                    }
                   

                    buttonArray[min_idx].BackColor = Color.Purple;
                    Thread.Sleep(deley);
                    buttonArray[j].BackColor = Color.White;
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
                        
                        SwapTwoElement(j -1, j);
                        buttonArray[j-1].BackColor = Color.Red;
                        Thread.Sleep(deley);
                        buttonArray[j-1].BackColor = Color.White;
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
            buttonArray[p].BackColor = Color.Purple;
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
            buttonArray[p].BackColor = Color.White;
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
            
            button.BackColor = button.BackColor == Color.Red?Color.White:Color.Red;
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
           // arr[x] = int.Parse(value);
           // buttonArray[x].Focus();
           // buttonArray[x].Select();
         
            
           
            
            

        }

        private void SetHeightOfButton(Button button,int value)
        {

            button.Height = (value + 1) + (int)((1.0/buttonArray.Length)*1000);
            
        }
        public void Perform(int n)
        {
            arr = new int[n];
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

