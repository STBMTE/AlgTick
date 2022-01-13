public class Node
{
    public List<Node> fromMe = new();    // Входящие и выходящие вершины
}
// Класс вершины, которая образует граф с весом ребер. Вершина знает сколько стоит дойти ребра, на которое она указывает
public class WeightNode
{
    public List<WeightNode> fromMe = new();
    readonly Dictionary<WeightNode, int> edgeWeights = new();
    public void SetWeight(WeightNode node, int newWeight) => edgeWeights[node] = newWeight;
    public int GetWeight(WeightNode node) => edgeWeights[node];
}
public static class Graph
{
    // Обход в ширину с помощью очереди
    public static Node[] BreadFirstAlgorithm(Node start)
    {
        var visited = new List<Node> { start };
        var queue = new Queue<Node>();
        queue.Enqueue(start);
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            var neighbours = node.fromMe;
            foreach (var n in neighbours)
                if (!visited.Contains(n))
                {
                    queue.Enqueue(n);
                    visited.Add(n);
                }
        }
        return visited.ToArray();
    }
    // Обход в глубину с помощью стека.
    public static Node[] DeapthFirstAlgorithm(Node start)
    {
        var visited = new List<Node> { start };
        var stack = new Stack<Node>();
        stack.Push(start);
        while (stack.Count > 0)
        {
            var node = stack.Pop();
            var neighbours = node.fromMe;
            foreach (var n in neighbours)
                if (!visited.Contains(n))
                {
                    stack.Push(n);
                    visited.Add(n);
                }
        }
        return visited.ToArray();
    }
    // Дейкстра. 
    public static void AlgorithmDeikstra(WeightNode start, WeightNode end, out int minCost, out WeightNode[] minPath)
    {
        var minCostGetThere = new Dictionary<WeightNode, int>();
        var allChecked = new List<WeightNode>();
        minCostGetThere.Add(start, 0);
        RecSearch(start);
        minCost = minCostGetThere[end];
        minPath = null;

        void RecSearch(WeightNode current)
        {
            foreach (var next in current.fromMe)
            {
                if (!allChecked.Contains(next))
                {
                    if (!minCostGetThere.ContainsKey(next))
                        minCostGetThere.Add(next, minCostGetThere[current] + current.GetWeight(next));
                    else if (minCostGetThere[current] + current.GetWeight(next) < minCostGetThere[next])
                        minCostGetThere[next] = minCostGetThere[current] + current.GetWeight(next);
                }
            }
            allChecked.Add(current);
            foreach (var next in current.fromMe.OrderBy(x => current.GetWeight(x)))
            {
                if (!allChecked.Contains(next))
                    RecSearch(next);
            }
        }
    }
}