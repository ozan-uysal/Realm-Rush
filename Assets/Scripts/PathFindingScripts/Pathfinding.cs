using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    [SerializeField] Node currentSearchNode;
    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    GridManager GridManager;
    Dictionary<Vector2Int, Node> grid;
    

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
        ExploreNeighbors();
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

                //TODO Remove after testing
                grid[neigborCoords].isExplored = true;
                grid[currentSearchNode.coordinates].isPath = true;
            }
        }
    }
}
