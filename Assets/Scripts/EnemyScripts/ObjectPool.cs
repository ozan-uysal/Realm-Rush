using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject Ram;
    [SerializeField] float waitTimeForSpawningRam = 2f;
    bool stopSpawning = false;


    void Start()
    {
        StartCoroutine(InstantiateRam());
    }
   

    IEnumerator InstantiateRam()
    {
        while (stopSpawning==false)
        {
            GameObject.Instantiate(Ram);
            yield return new WaitForSeconds(waitTimeForSpawningRam);

        }

    }
}
