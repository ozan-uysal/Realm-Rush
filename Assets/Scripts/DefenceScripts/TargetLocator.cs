using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TargetLocator : MonoBehaviour
{  
    [SerializeField] Transform weapon;
    [SerializeField] Transform target;
    //[SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float range = 15;

    public EnemyContainer container;

    public GameObject particleSpawner;

    Transform closestTarget;
    float maxDistance;
    float targetDistance;

    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }
    void FindClosestTarget()
    {
            closestTarget = null;
            maxDistance = Mathf.Infinity;

            foreach (Transform enemy in container.enemyListTransform)
            {
               targetDistance = Vector3.Distance(transform.position, enemy.position);
                
                if (targetDistance < range && targetDistance < maxDistance)
                {
                    closestTarget = enemy;
                    maxDistance = targetDistance;
                }
            }
            //targetDistance = maxDistance;
            target = closestTarget;
    }

     void AimWeapon()
    {
        if (target == null)
        {
            if (particleSpawner.activeSelf)
            {
                particleSpawner.SetActive(false);
            }
            //return;
        }
        else
        {
            if (!particleSpawner.activeSelf)
            {
                particleSpawner.SetActive(true);
            }
        }
        //Atack();
        weapon.LookAt(target);
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireSphere(transform.position,range);
    //}
    //void Atack()
    //{
    //    if (targetDistance < range)
    //    {
    //        projectileParticles.Play();
    //    }
    //    else
    //    {
    //        projectileParticles.Pause();
    //    }
    //}
}
