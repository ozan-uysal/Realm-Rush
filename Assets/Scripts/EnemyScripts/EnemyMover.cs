using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f,5f)] float speed =1f;
    Waypoint startWaypoint;
    public RamContainer container;

    void Start()
    {
        FindPath();
        ReturnToStart();

        container.ramList.Add(transform);
        StartCoroutine(FollowPath());
    }
    void ReturnToStart()
    {
        transform.position = startWaypoint.transform.position;
    }
    private void OnDestroy()
    {
        container.ramList.Remove(transform);
    }
    void FindPath()
    {
        path.Clear();

        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");

        foreach (var waypoint in waypoints)
        {
            if (waypoint.TryGetComponent(out Waypoint w))
            {
                if (startWaypoint==null)
                {
                    startWaypoint = w;
                    continue;
                }
                path.Add(w);

            }
            else
            {
                Debug.LogError("Yanl�� tag verilmi� obje hatas�");
            }
          
        }
    }
    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            //Debug.Log(waypoint.name);
            Vector3 startPosition =transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime*speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }  
        }
        Destroy(gameObject);
    }
}