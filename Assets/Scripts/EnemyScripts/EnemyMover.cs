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


    void OnEnable()
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
    private void OnDisable()
    {
        container.ramList.Remove(transform);
        startWaypoint = null;
        path.Clear();
    }
    void FindPath()
    {

        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Path");

        foreach (var waypoint in waypoints)

        {
            if (waypoint.TryGetComponent(out Waypoint w))
            {
                if (startWaypoint == null)
                {
                    startWaypoint = w;
                    continue;
                }
                path.Add(w);

            }
            else
            {
                Debug.LogError("Yanlýþ tag verilmiþ obje hatasý");
            }

        }
        //startWaypoint = waypoints[0].GetComponent<Waypoint>();
        //for (int i = 1; i < waypoints.Length; i++)
        //{
        //    if (waypoints[i].TryGetComponent(out Waypoint w))
        //    {
        //        path.Add(w);
        //    }
        //}
       

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
        gameObject.SetActive(false);
    }
}
