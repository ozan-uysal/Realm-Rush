using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public PathContainer pathContainer;
    List<Waypoint> path;
    
    private void Awake()
    {
        CreatePath(); 
    }
    private void OnEnable()
    {
        pathContainer.paths.Add(path);   
    }
    private void OnDisable()
    {
        pathContainer.paths.Remove(path);
    }
    void CreatePath()
    {
        //GameObject parent = GameObject.FindGameObjectWithTag("Path");
            path = new List<Waypoint>();

            foreach (Transform wayPointChild in transform)
            {
                if (wayPointChild.TryGetComponent(out Waypoint w))
                {
                    path.Add(w);
                }
                else
                {
                    Debug.LogError("Yanlýþ tag verilmiþ obje hatasý");
                }
            }
    }
}
