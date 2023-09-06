using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathFinder : MonoBehaviour, IPathFinder
{
    public Vector2 StartPoint;
    public Vector2 EndPoint;

    public List<Edge> Edges;

    private ValidInputChecker _validInputChecker;

    private void Start()
    {
        var path = GetPath(StartPoint, EndPoint, Edges);

        /*
        if (path.Count() == 0)
        {
            Debug.Log("No path");
        }
        else
        {
            Debug.Log("There is path for sure");
            foreach(var edge in path)
            {
                Debug.Log(edge);
            }
        }
        */
    }

    public IEnumerable<Vector2> GetPath(Vector2 A, Vector2 C, IEnumerable<Edge> edges)
    {
        var path = new List<Vector2>();

        // Check if input is valid and all point can be reached through edges
        _validInputChecker = new ValidInputChecker();
        var rectangles = GetRectangles(edges);

        if(!_validInputChecker.IsPointInsideRectangles(A, rectangles) || 
                !_validInputChecker.IsPointInsideRectangles(C, rectangles))
        {
            return path;
        }

        // Get start and end edge since we can be sure that if point is inside rectangle, then it can be reached through edge on rectangle.
        // There is possibility that we can have more then one edge on rectangle with starting point, but in case of simplicity and since there
        // is no such condition that there should be more than one I made it like we can only have once
        var startEdge = GetPointEdge(A, edges);
        var endEdge = GetPointEdge(C, edges);

        
        // I'm using Dijkstra Alghoritm since it will have the most accurate way. And there is no need to take into account Vector distance so we don't have to use A*
        // I could use Greedy BFS here, but decided to stick with Dijkstra ALghoritm
        var distances = new Dictionary<Edge, int>();
        var previousEdge = new Dictionary<Edge, Edge>();

        foreach(var edge in edges)
        {
            if (!edge.Equals(startEdge))
            {
                distances[edge] = int.MaxValue;
            }
        }

        distances[startEdge] = 0;

        var queue = new SortedSet<Edge>(Comparer<Edge>.Create((a, b) => distances[a].CompareTo(distances[b])))
        {
            startEdge
        };

        while (queue.Count > 0)
        {
            var current = queue.First();
            queue.Remove(current);

            if (current.Equals(endEdge))
                break;

            // Neighbours
            var connectedEdges = edges.Where(e => !e.Equals(current) && (e.First.Equals(current.Second) || e.Second.Equals(current.Second)));

            foreach (var edge in connectedEdges)
            {
                var newDistance = distances[current] + 1;

                if (newDistance < distances[edge])
                {
                    distances[edge] = newDistance;
                    previousEdge[edge] = current;

                    queue.Add(edge);
                }
            }
        }

        var currentEdge = endEdge;

        while (!currentEdge.Equals(startEdge))
        {
            path.Add(currentEdge.Start);
            currentEdge = previousEdge[currentEdge];
        }

        path.Add(startEdge.Start);
        path.Reverse();

        return path;
    }

    // Get Rectangles to check if points are valid
    private IEnumerable<Rectangle> GetRectangles(IEnumerable<Edge> edges)
    {
        var rectangles = new HashSet<Rectangle>();

        foreach (var edge in edges)
        {
            rectangles.Add(edge.First);
            rectangles.Add(edge.Second);
        }

        return rectangles;
    }

    // Getting starting and ending edges
    private Edge GetPointEdge(Vector2 point, IEnumerable<Edge> edges)
    {
        var pointEdge = new Edge();

        foreach (var edge in edges)
        {
            if(_validInputChecker.IsPointInsideRectangles(point, new List<Rectangle>() { edge.First, edge.Second }))
            {
                pointEdge =edge;
            }
        }

        return pointEdge;
    }
}
