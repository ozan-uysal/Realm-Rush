using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] [Range(0,50)] int poolSize = 5;
    [SerializeField] [Range(0.1f,30f)] float spawnTimer = 2f;
    bool stopSpawning = false;

    GameObject[] pool;
    void Start()
    {
        PopulatePool();
        StartCoroutine(SpawnEnemy());
    }
    void PopulatePool()
    {
        if (poolSize<0)
        {
            return;
        }

        pool = new GameObject[poolSize];

        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }
    void EnableObjectPool()
    {
        foreach (GameObject enemy in pool)
        {
            if (enemy.activeInHierarchy == false)
            {
                enemy.SetActive(true);
                return;    
            }
        }
        //for (int i = 0; i < pool.Length; i++)
        //{
        //    if (pool[i].activeInHierarchy == false)
        //    {
        //        pool[i].SetActive(true);
        //        return;

        //    }
        //}
    }
    IEnumerator SpawnEnemy()
    {
        while (stopSpawning == false)
        {
            EnableObjectPool();
            yield return new WaitForSeconds(spawnTimer);

        }

    }
}
