namespace Problems
{
    public class ConnectedComponentsProblem
    {
        public int CountComponents(int n, int[][] edges) {
            if(edges != null && edges.Length ==0)
            {
                return n;
            }
            
            if(n < 1 || edges == null || edges.Length ==0 || edges[0].Length != 2)
            {
                return 0;
            }
            int[, ] graph = new int[n,n];
            for(int i=0;i<edges.Length;i++)
            {
                graph[edges[i][0], edges[i][1]] = 1;
                graph[edges[i][1], edges[i][0]] = 1;
            }
            
            State[] states = new State[n];
            for(int v=0;v<n;v++)
            {
                states[v] = State.NotVisited;
            }
            
            int connected = 0;
            for(int v=0;v<n;v++)
            {
                if(states[v] == State.NotVisited)
                {
                    connected++;
                    DfsVisit(graph, v, states);
                }
                    
            }
            
            return connected;
        }
        
        private void DfsVisit(int[,] graph, int vertex, State[] states)
        {
            if(graph == null || graph.Length ==0 || graph.Rank != 2 
            || graph.GetLength(0) != graph.GetLength(1)
            || states == null || states.Length !=graph.GetLength(0) || vertex <0 || vertex>= graph.GetLength(0) )
            {
                return ;
            }
            if(states[vertex] != State.NotVisited)
            {
                return ;
            }
            
            states[vertex] = State.Visiting;
            for(int n=0;n<graph.GetLength(0);n++)
            {
                if(graph[vertex,n] ==1 && states[n] == State.NotVisited)
                {
                    DfsVisit(graph, n, states);
                }
            }
            states[vertex] = State.Visited;
        } 
        private enum State {NotVisited =0, Visiting = 1, Visited = 2}
    }
}