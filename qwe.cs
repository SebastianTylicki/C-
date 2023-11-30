
namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void A(Wezel w)
        {
            MessageBox.Show(w.wartosc.ToString());
            foreach (var dziecko in w.dzieci)
            {
                A(dziecko);
            }
        }
        List<Wezel2> visited = new List<Wezel2>();

        void A(Wezel2 w, List<Wezel2> visited)
        {

            visited.Add(w);
            MessageBox.Show(w.wartosc.ToString());

            foreach (var somsiad in w.somsiedzi)
            {
                if (!visited.Contains(w))
                    A(somsiad, visited);
            }
            visited.Clear();
        }


        void BFS(Wezel root)
        {
            Queue<Wezel> queue = new Queue<Wezel>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Wezel current = queue.Dequeue();
                MessageBox.Show(current.wartosc.ToString());

                foreach (var dziecko in current.dzieci)
                {
                    queue.Enqueue(dziecko);
                }
            }
        }

        private void TraverseGraph(object sender, EventArgs e)
        {
            var w1 = new Wezel(1);
            var w2 = new Wezel(2);
            var w3 = new Wezel(3);
            var w4 = new Wezel(4);
            var w5 = new Wezel(5);
            var w6 = new Wezel(6);

            w5.dzieci.Add(w2);
            w5.dzieci.Add(w1);
            w5.dzieci.Add(w3);
            w2.dzieci.Add(w4);
            w2.dzieci.Add(w6);

            MessageBox.Show("A Traversal:");
            A(w5);

            MessageBox.Show("BFS Traversal:");
            BFS(w5);

            var w1b = new Wezel2(1);
            var w2b = new Wezel2(2);
            var w3b = new Wezel2(3);
            var w4b = new Wezel2(4);
            var w5b = new Wezel2(5);
            var w6b = new Wezel2(6);
            var w7b = new Wezel2(7);

            w5b.Add(w3b);
            w3b.Add(w2b);
            w3b.Add(w4b);
            w2b.Add(w6b);
            w2b.Add(w7b);
            w7b.Add(w1b);
            w1b.Add(w5b);

            MessageBox.Show("A Traversal:");
            A(w5b, visited);
        }
    }

    public class Wezel
    {
        public int wartosc;
        public List<Wezel> dzieci = new List<Wezel>();

        public Wezel(int liczba)
        {
            this.wartosc = liczba;
        }
    }

    public class Wezel2
    {
        public int wartosc;
        public List<Wezel2> somsiedzi = new List<Wezel2>();

        public Wezel2(int liczba)
        {
            this.wartosc = liczba;
        }

        public void Add(Wezel2 w)
        {
            this.somsiedzi.Add(w);
            w.somsiedzi.Add(this);
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
            this.Add(w);
        }

    }

    public class DrzewoBinarne
    {
        Wezel3 korzen;
        int liczbaWezlow;
        DrzewoBinarne(int liczba)
        {
            this.korzen = new Wezel3(liczba);
            this.liczbaWezlow = 1;
        }

        // 1 Węzeł3 Znajdź(int liczba)

        // 2 Węzeł3 ZnajdźMin(Węzeł w)

        // 3 Węzeł3 ZnajdźMax(Węzeł3 w)
        
        // 4 Węzeł3 Następnik(Węzeł3 w)

        //      a) jeżeli jest prawe dziecko ZnajdźMin(w.praweDziecko) -> następnik
        //      b) jeżeli nie ma prawego dziecka idź do góry tak długo aż wyjdziesz w rodzicu jako lewe dziecko Następnikiem jest rodzic
        //      c) jeżeli nie ma prawego dziecka i nie zachodzi (b) ale już nie ma rodzica, bo jestem w korzeniu wtedy nie ma następnika

        // 5 Węzeł3 Poprzednik(Węzeł3 w)

        void Add(Wezel3 korzen, int liczba)
        {
            if (liczba < korzen.wartosc)
            {
                if (korzen.lewedziecko == null)
                {
                    korzen.lewedziecko = new Wezel3(liczba);
                    korzen.lewedziecko.rodzic = korzen;
                    liczbaWezlow++;
                }
                else
                {
                    Add(korzen.lewedziecko, liczba);
                }
            }
            else if (liczba >= korzen.wartosc)
            {
                if (korzen.prawedziecko == null)
                {
                    korzen.prawedziecko = new Wezel3(liczba);
                    korzen.prawedziecko.rodzic = korzen;
                    liczbaWezlow++;
                }
                else
                {
                    Add(korzen.prawedziecko, liczba);
                }
            }
        }
    }
}