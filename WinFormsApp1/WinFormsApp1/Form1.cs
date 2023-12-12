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


        private void button3_Click(object sender, EventArgs e)
        {
            d = new DrzewoBinarne(5);
            d.Add(3);
            d.Add(8);
            d.Add(7);
            d.Add(10);
            d.Add(7);

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

        public Wezel3 ZnajdzMin(Wezel3 w)
        {
            while (w.lewedziecko != null) 
            {
                w = w.lewedziecko;
            }
            return w;
        }
        public Wezel3 ZnajdzMax(Wezel3 w)
        {
            while (w.prawedziecko != null)
            {
                w = w.prawedziecko;
            }
            return w;
        }
        public Wezel3 Nastepnik(Wezel3 w)
        {
            if (w.prawedziecko != null)
            {
                return this.ZnajdzMin(w.prawedziecko);
            }
            while (w.rodzic != null) 
            {
                if (w.rodzic.lewedziecko == w)
                {
                    return w.rodzic;
                }
                w = w.rodzic;
            }
            return null;
        }
       
        public Wezel3 Usun(Wezel3 w)
        {
            // 1 Gdy nie ma dzieci odwi¹zuje wêze³
            // 2 Gdy jest 1 dziecko, to dziecko wchodzi w miejsce odwi¹zanego wez³a
            // 3 Gdy s¹ 2 dzieci, to bierzemy nastêpnik
            // Nastêpnik mo¿e mieæ jedno lub 0 dzieci zmieniamy nastêpnik wg (1) lub (2)

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