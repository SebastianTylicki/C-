using System;
using System.Diagnostics;
using System.Net;

namespace Sort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            napisgen = Generate();

        }
        int[] napisgen;

        private void button1_Click(object sender, EventArgs e)
        {
            int[] napis;
            if (textBox1.Enabled == true)
            {
                napis = Convert();
            }
            else
            {
                napis = napisgen;
            }
            var timer = new Stopwatch();
            timer.Start();
            var odp = BubbleSort(napis);
            timer.Stop();

            double elapsedSeconds = timer.Elapsed.TotalSeconds;
            timer.Reset();
            label2.Text = elapsedSeconds.ToString();
            textBox2.Text = String.Join(",", odp);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] napis;
            if (textBox1.Enabled == true)
            {
                napis = Convert();
            }
            else
            {
                napis = napisgen;
            }
            var timer = new Stopwatch();
            timer.Start();
            var odp = SelectSort(napis);
            timer.Stop();

            double elapsedSeconds = timer.Elapsed.TotalSeconds;
            timer.Reset();
            label2.Text = elapsedSeconds.ToString("0.00");
            textBox2.Text = String.Join(",", odp);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] napis;
            if (textBox1.Enabled == true)
            {
                napis = Convert();
            }
            else
            {
                napis = napisgen;
            }
            var timer = new Stopwatch();
            timer.Start();
            var odp = InsertSort(napis);
            timer.Stop();

            double elapsedSeconds = timer.Elapsed.TotalSeconds;
            timer.Reset();
            label2.Text = elapsedSeconds.ToString();
            textBox2.Text = String.Join(",", odp);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int[] napis;
            if (textBox1.Enabled == true)
            {
                napis = Convert();
            }
            else
            {
                napis = napisgen;
            }
            var timer = new Stopwatch();
            timer.Start();
            var odp = SortArray(napis, 0, napis.Length - 1);
            timer.Stop();

            double elapsedSeconds = timer.Elapsed.TotalSeconds;
            timer.Reset();
            label2.Text = elapsedSeconds.ToString();
            textBox2.Text = String.Join(",", odp);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int[] napis;
            if (textBox1.Enabled == true)
            {
                napis = Convert();
            }
            else
            {
                napis = napisgen;
            }
            var timer = new Stopwatch();
            timer.Start();
            var odp = QuickSort(napis, 0, napis.Length - 1);
            timer.Stop();

            double elapsedSeconds = timer.Elapsed.TotalSeconds;
            timer.Reset();
            label2.Text = elapsedSeconds.ToString();
            textBox2.Text = String.Join(",", odp);

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.Enabled = false;
                numericUpDown1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = true;
                numericUpDown1.Enabled = false;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        int[] Generate()
        {
            int x = (int)numericUpDown1.Value;
            var liczby = new int[x];
            for (int i = 0; i < x; i++)
            {
                Random rnd = new Random();
                liczby[i] = rnd.Next(1, x);
            }
            return liczby;
        }
        int[] Convert()
        {
            string napis = textBox1.Text;
            var liczbyS = napis.Trim().Split(' ');
            var liczby = new int[liczbyS.Length];
            for (int i = 0; i < liczbyS.Length; i++)
            {
                liczby[i] = int.Parse(liczbyS[i]);
            }
            return liczby;
        }
        int[] BubbleSort(int[] napis)
        {
            var n = napis.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (napis[j] > napis[j + 1])
                    {
                        var tempVar = napis[j];
                        napis[j] = napis[j + 1];
                        napis[j + 1] = tempVar;
                    }
            return napis;
        }
        int[] SelectSort(int[] napis)
        {
            int n = napis.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (napis[j] < napis[min])
                    {
                        min = j;
                    }
                }
                int temp = napis[min];
                napis[min] = napis[i];
                napis[i] = temp;
            }
            return napis;
        }
        int[] InsertSort(int[] napis)
        {
            int n = napis.Length;
            for (int i = 1; i < n; i++)
            {
                int key = napis[i];
                int j = i - 1;

                while (j >= 0 && napis[j] > key)
                {
                    napis[j + 1] = napis[j];
                    j = j - 1;
                }
                napis[j + 1] = key;
            }
            return napis;
        }
        public int[] SortArray(int[] array, int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;
                SortArray(array, left, middle);
                SortArray(array, middle + 1, right);
                MergeArray(array, left, middle, right);
            }
            return array;
        }
        public void MergeArray(int[] array, int left, int middle, int right)
        {
            var leftArrayLength = middle - left + 1;
            var rightArrayLength = right - middle;
            var leftTempArray = new int[leftArrayLength];
            var rightTempArray = new int[rightArrayLength];
            int i, j;
            for (i = 0; i < leftArrayLength; ++i)
                leftTempArray[i] = array[left + i];
            for (j = 0; j < rightArrayLength; ++j)
                rightTempArray[j] = array[middle + 1 + j];
            i = 0;
            j = 0;
            int k = left;
            while (i < leftArrayLength && j < rightArrayLength)
            {
                if (leftTempArray[i] <= rightTempArray[j])
                {
                    array[k++] = leftTempArray[i++];
                }
                else
                {
                    array[k++] = rightTempArray[j++];
                }
            }
            while (i < leftArrayLength)
            {
                array[k++] = leftTempArray[i++];
            }
            while (j < rightArrayLength)
            {
                array[k++] = rightTempArray[j++];
            }
        }
        public int[] QuickSort(int[] array, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex];
            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }

                while (array[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
                QuickSort(array, leftIndex, j);
            if (i < rightIndex)
                QuickSort(array, i, rightIndex);
            return array;
        }

    }

}