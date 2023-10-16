namespace AiSD_io_4
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

        private void button1_Click(object sender, EventArgs e)
        {
            int liczbaN = (int)nudFIB.Value;

            bw.RunWorkerAsync(liczbaN);

            //int wynik = Fib(liczbaN);

            //MessageBox.Show(wynik.ToString());
        }

        int Fib(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }
            else {
                return Fib(n - 1) + Fib(n - 2);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
        private void bw_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var liczbaN = int.Parse(e.Argument.ToString());

            int wynik = Fib(liczbaN);

            e.Result = wynik;
        }

        private void bw_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show(e.Result.ToString());
        }
    }
}