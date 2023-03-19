using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f,5f)] float speed =1f;
    Waypoint startWaypoint;
    public EnemyContainer container;
    Enemy enemy;

    Vector3 endPosition;
    Vector3 startPosition;

     void Start()
    {
        enemy =GetComponent<Enemy>();
    }
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        container.enemyListTransform.Add(transform);
        StartCoroutine(FollowPath());
    }
    void ReturnToStart()
    {
        transform.position = startWaypoint.transform.position;
    }
     void OnDisable()
    {
        container.enemyListTransform.Remove(transform);
    }

    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }
    void FindPath()
    {
        startWaypoint = null;
        path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach (Transform wayPointChild in parent.transform)

        {
            
            if (wayPointChild.TryGetComponent(out Waypoint w))
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
            startPosition =transform.position;
            endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime*speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }  
        }
        FinishPath();
    }
}
