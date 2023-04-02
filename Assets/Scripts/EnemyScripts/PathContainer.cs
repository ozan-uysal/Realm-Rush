using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PathContainer : ScriptableObject
{
    public List<List<Tile>> paths = new List<List<Tile>>();
    public List<Tile> GetRandomPath()
        {
        return paths[Random.Range(0,paths.Count)];
        }

}
