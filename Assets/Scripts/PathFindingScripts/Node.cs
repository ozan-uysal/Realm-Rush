using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node
{
    public Vector2Int coordinates;
    public bool isWalkable;
    public bool isExplored;
    public Node connectedTo;
    public bool isPath;

    public Node(Vector2Int coordinates,bool isWalkable)
    {
        this.coordinates = coordinates;
        this.isWalkable = isWalkable;
        
    }
}
