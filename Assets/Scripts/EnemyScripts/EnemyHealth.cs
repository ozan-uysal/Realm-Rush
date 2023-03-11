using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    int currentHitPoints = 0;

    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }


    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }
    void ProcessHit()
    {
        currentHitPoints--;
        if (currentHitPoints<=0)
        {
            gameObject.SetActive(false);
        }
    }
}
