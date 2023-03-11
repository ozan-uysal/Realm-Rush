using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int poolSize = 5;
    //[SerializeField] float spawnTimer = 2f;
    //bool stopSpawning = false;

    GameObject[] pool;

    void Awake()
    {
        PopulatePool();
    }


    //void Start()
    //{
    //    StartCoroutine(InstantiateRam());
    //}
    
    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    //IEnumerator InstantiateRam()
    //{
    //    while (stopSpawning==false)
    //    {
    //        GameObject.Instantiate(enemyPrefab);
    //        yield return new WaitForSeconds(spawnTimer);

    //    }

    //}
}
