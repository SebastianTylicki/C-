namespace BFS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graph g = new Graph(7);

            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 3);
            g.AddEdge(1, 4);
            g.AddEdge(2, 5);
            g.AddEdge(2, 6);

            g.BFS(0);
        }
    }
    class Graph
    {
        private int V; 
        private List<int>[] adj; 

        public Graph(int v)
        {
            V = v;
            adj = new List<int>[v];
            for (int i = 0; i < v; ++i)
            {
                adj[i] = new List<int>();
            }
        }

        public void AddEdge(int v, int w)
        {
            adj[v].Add(w);
            adj[w].Add(v); 
        }

        public void BFS(int startVertex)
        {
            
            bool[] visited = new bool[V];

            
            Queue<int> queue = new Queue<int>();

            
            visited[startVertex] = true;
            queue.Enqueue(startVertex);

            while (queue.Count != 0)
            {
                
                startVertex = queue.Dequeue();
                MessageBox.Show(startVertex.ToString());

                
                foreach (var neighbor in adj[startVertex])
                {
                    if (!visited[neighbor])
                    {
                        visited[neighbor] = true;
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }
    }
//     0
//    / \
//   1   2
//  / \ / \
// 3   45  6
}