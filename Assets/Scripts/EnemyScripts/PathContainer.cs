using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PathContainer : ScriptableObject
{
    public List<List<Waypoint>> paths = new List<List<Waypoint>>();
    public List<Waypoint> GetRandomPath()
        {
        return paths[Random.Range(0,paths.Count)];
        }

}
