using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Vector2Int startCoordinates;
    [SerializeField] Vector2Int DestinationCoordinates;

    Node startNode;
    Node destinationNode;
    Node currentSearchNode;

    Queue<Node> frontier = new Queue<Node>();
    Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>();

    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    GridManager GridManager;

    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    void Awake()
    {
        GridManager = FindObjectOfType<GridManager>();
        if (GridManager != null)
        {
            grid = GridManager.Grid;
        }
    }
    void Start()
    {
        startNode = GridManager.Grid[startCoordinates];
        destinationNode = GridManager.Grid[DestinationCoordinates];
        BreadthFirstSearch();
        BuildPath();
    }
    void ExploreNeighbors()
    {
        List<Node> neighbors = new List<Node>();
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neigborCoords = currentSearchNode.coordinates + direction;
            if (grid.ContainsKey(neigborCoords))
            {
                neighbors.Add(grid[neigborCoords]);
            }
        }
        foreach (Node neighbor in neighbors)
        {
            if (!reached.ContainsKey(neighbor.coordinates) && neighbor.isWalkable)
            {
                neighbor.connectedTo = currentSearchNode;
                reached.Add(neighbor.coordinates, neighbor);
                frontier.Enqueue(neighbor);
            }
        }
    }
    void BreadthFirstSearch()
    {
        bool isRunning = true;
        frontier.Enqueue(startNode);
        reached.Add(startCoordinates, startNode);

        while (frontier.Count>0 && isRunning)
        {
            currentSearchNode = frontier.Dequeue();
            currentSearchNode.isExplored = true;
            ExploreNeighbors();
            if (currentSearchNode.coordinates == DestinationCoordinates)
            {
                isRunning = false;
            }
        }
    }
    List<Node> BuildPath()
    {
        List<Node> path = new List<Node>();
        Node currentNode = destinationNode;
        path.Add(currentNode);
        currentNode.isPath = true;
        while (currentNode.connectedTo !=null) 
        {
            currentNode = currentNode.connectedTo;
            path.Add(currentNode);
            currentNode.isPath = true;
        }
        path.Reverse();
        return path;
    }
}