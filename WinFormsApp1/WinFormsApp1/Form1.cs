namespace WinFormsApp1

{
    public partial class Form1 : Form
    {
        private DrzewoBinarne d;

        public Form1()
        {
            InitializeComponent();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            d = new DrzewoBinarne(5);
            d.Add(8);
            d.Add(4);
            d.Add(2);
            d.Add(3);
            d.Add(1);

        }
    }

    public class Wezel3
    {
        public int wartosc;
        public Wezel3 rodzic;
        public Wezel3 lewedziecko;
        public Wezel3 prawedziecko;

        public Wezel3(int liczba)
        {
            this.wartosc = liczba;
        }

        public void Add(Wezel3 w)
        {
            if (w.wartosc < this.wartosc)
            {
                if (this.lewedziecko == null)
                {
                    this.lewedziecko = w;
                    w.rodzic = this;
                }
                else
                {
                    this.lewedziecko.Add(w);
                }
            }
            else
            {
                if (this.prawedziecko == null)
                {
                    this.prawedziecko = w;
                    w.rodzic = this;
                }
                else
                {
                    this.prawedziecko.Add(w);
                }
            }
        }

        public void Add(int liczba)
        {
            var dziecko = new Wezel3(liczba);
            dziecko.rodzic = this;
            if (liczba < this.wartosc)
            {
                this.lewedziecko = dziecko;
            }
            else
            {
                this.prawedziecko = dziecko;
            }
        }

        public override string ToString()
        {
            return wartosc.ToString();
        }
        

    }



    public class DrzewoBinarne
    {
        private Wezel3 korzen;

        public DrzewoBinarne(int liczba)
        {
            this.korzen = new Wezel3(liczba);
        }

        public void Add(int liczba)
        {
            var rodzic = this.ZnajdzWezel(liczba);
            rodzic.Add(liczba);
        }


        private Wezel3 ZnajdzWezel(int liczba)
        {
            var w = this.korzen;
            while (true)
            {
                if (liczba < w.wartosc)
                {
                    if (w.lewedziecko == null)
                    {
                        return w;
                    }
                    else
                    {
                        w = w.lewedziecko;
                    }
                }
                else
                {
                    if (w.prawedziecko == null)
                    {
                        return w;
                    }
                    else
                    {
                        w = w.prawedziecko;
                    }
                }
            }
        }
    }
}