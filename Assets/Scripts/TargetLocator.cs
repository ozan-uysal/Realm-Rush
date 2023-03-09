using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TargetLocator : MonoBehaviour
{  
    [SerializeField] Transform weapon;
    [SerializeField] Transform target;
    public RamContainer container;
    public GameObject particleSpawner;
    

    private void Update()
    {

    AimWeapon();
        
    }

    private void AimWeapon()
    {
        if (container.ramList.Count <= 0)
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
         weapon.LookAt(container.ramList[0]);  
    }
}
