using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    public List<Waypoint> path;
    public PathContainer pathContainer;
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
        path = pathContainer.GetRandomPath();
        startWaypoint = path[0];
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
  
       
        
        //startWaypoint = waypoints[0].GetComponent<Waypoint>();
        //for (int i = 1; i < waypoints.Length; i++)
        //{
        //    if (waypoints[i].TryGetComponent(out Waypoint w))
        //    {
        //        path.Add(w);
        //    }
        //}
       

    

    IEnumerator FollowPath()
    {

        for (int i = 1; i < path.Count; i++)
        {
            startPosition = transform.position;
            endPosition = path[i].transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }  
        FinishPath();
    }
}
