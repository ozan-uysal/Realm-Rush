using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TargetLocator : MonoBehaviour
{  
    [SerializeField] Transform weapon;
    [SerializeField] Transform target;
    public EnemyContainer container;
    public GameObject particleSpawner;
    


    private void Update()
    {
        AimWeapon();
    }
    void FindClosestTarget()
    {
            Transform closestTarget = null;
            float maxDistance = Mathf.Infinity;

            foreach (Transform enemy in container.enemyList)
            {
                float targetDistance = Vector3.Distance(transform.position, enemy.position);

                if (targetDistance < maxDistance)
                {
                    closestTarget = enemy; 
                    maxDistance = targetDistance;
                }
            }
            target = closestTarget;
    }

    private void AimWeapon()
    {
        if (container.enemyList.Count <= 0)
        {
            if (particleSpawner.activeSelf)
            {
                particleSpawner.SetActive(false);
            }
            return;
        }
        else
        {
            if (!particleSpawner.activeSelf)
            {
                particleSpawner.SetActive(true);
            }
        }
        FindClosestTarget();
        weapon.LookAt(target);
    }
}
