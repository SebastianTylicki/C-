namespace drzewo_binarne
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var db = new DrzewoBinarne(5);
            db.Add(16);
            db.Add(13);
            db.Add(10);
            db.Add(20);
            db.Add(3);
            db.Add(16);
            db.Add(18);
            db.Add(15);
            db.Add(14);
            db.Add(13);

            int wynik = db.ZnajdzMin();
            MessageBox.Show(wynik.ToString());

            int wynik2 = db.ZnajdzMax();
            MessageBox.Show(wynik2.ToString());


            int szukanaLiczba = 1;

            Wezel3 znalezionyWezel = db.Znajdz(szukanaLiczba);

        }




        public class Wezel3
        {
            public int wartosc;
            public Wezel3 rodzic;
            public Wezel3 lewe;
            public Wezel3 prawe;
            public List<Wezel3> dzieci = new List<Wezel3>();
            public Wezel3(int liczba)
            {
                this.wartosc = liczba;
            }

            public override string ToString()
            {
                return this.wartosc.ToString();
            }

            internal void Add(int liczba)
            {
                var dziecko = new Wezel3(liczba);
                dziecko.rodzic = this;
                if (liczba < this.wartosc)
                {
                    this.lewe = dziecko;
                }
                else
                {
                    this.prawe = dziecko;
                }
            }

            internal int GetLiczbaDzieci()
            {
                int wynik = 0;
                if (this.lewe != null)
                    ++wynik;
                if (this.prawe != null)
                    ++wynik;
                return wynik;
            }
        }


        public class DrzewoBinarne
        {
            public Wezel3 korzen;
            public DrzewoBinarne(int liczba)
            {
                this.korzen = new Wezel3(liczba);
            }

            public void Add(int liczba)
            {
                Wezel3 rodzic = this.ZnajdzRodzica(liczba);
                rodzic.Add(liczba);
            }


            private Wezel3 ZnajdzRodzica(int liczba)
            {
                var w = this.korzen;
                while (true)
                {
                    if (liczba < w.wartosc)
                    {
                        if (w.lewe == null) return w;
                        else w = w.lewe;
                    }
                    else
                    {
                        if (w.prawe == null) return w;
                        else w = w.prawe;
                    }
                }
            }

            public int ZnajdzMin()
            {
                return Min(korzen);
            }

            private int Min(Wezel3 wezel)
            {
                while (wezel.lewe != null)
                {
                    wezel = wezel.lewe;
                }

                return wezel.wartosc;
            }

            public int ZnajdzMax()
            {
                return Max(korzen);
            }

            private int Max(Wezel3 wezel)
            {
                while (wezel.prawe != null)
                {
                    wezel = wezel.prawe;
                }

                return wezel.wartosc;
            }

            public Wezel3 Znajdz(int liczba)
            {
                return Znajdz1(korzen, liczba);
            }

            private Wezel3 Znajdz1(Wezel3 wezel, int liczba)
            {
                if (wezel == null || wezel.wartosc == liczba)
                {
                    return wezel;
                }

                if (liczba < wezel.wartosc)
                {
                    return Znajdz1(wezel.lewe, liczba);
                }
                else
                {
                    return Znajdz1(wezel.prawe, liczba);
                }
            }

            public Wezel3 Usun(Wezel3 w)
            {
                switch(w.GetLiczbaDzieci())
                {
                    case 0:
                        w = this.UsunGdy0Dzieci(w);
                        break;
                    case 1:
                        w = this.UsunGdy1Dziecko(w);
                        break;
                    case 2:
                        w = this.UsunGdy2Dzieci(w);
                        break;
                }

            }

            private Wezel3 UsunGdy2Dzieci(Wezel3 w)
            {
                var zamiennik = this.Nastepnik(w);
                zamiennik = this.Usun(zamiennik);

            }

            private Wezel3 UsunGdy1Dziecko(Wezel3 w)
            {
                Wezel3 dziecko = null;
                if(w.lewe != null)
                {
                    dziecko = w.lewe;
                    w.lewe = null;
                }
                else
                {
                    dziecko = w.prawe;
                    w.prawe = null;
                }
                dziecko.rodzic = w.rodzic;
                if (w.rodzic == null)
                    this.korzen = dziecko;
                else
                {
                    if (w.rodzic.lewe == null)
                        w.rodzic.lewe = dziecko;
                    else w.rodzic.prawe = dziecko;
                }
                w.rodzic = null;
                return w;
            }

            private Wezel3 UsunGdy0Dzieci(Wezel3 w)
            {
                if(w.rodzic == null)
                {
                    this.korzen = null;
                    return w;
                }
                if (w.rodzic.lewe == w)
                    w.rodzic.lewe = null;
                else w.rodzic.prawe = null;
                w.rodzic = null;
                return w;
            }
        }
    }
}