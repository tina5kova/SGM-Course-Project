using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    private GameObject clone;
    private float myTime = 0.0F;
    private float nextFire = 0.5F;
    [SerializeField] private float fireDelta = 0.5F;

    [SerializeField] private GameObject projectileR;
    [SerializeField] private GameObject projectileL;
    [SerializeField] private Transform shootingPointR;
    [SerializeField] private Transform shootingPointL;
    private int turn = 1;

    void Start()
    {
        
        StartCoroutine(Shoot());
    }


    

    IEnumerator Shoot()
    {
        while (true)
        {
            GameObject bulletL = ObjectPool.sharedInstance.GetPooledObjectL();
            if (bulletL != null)
            {
                bulletL.transform.position = shootingPointL.transform.position;
                bulletL.transform.rotation = shootingPointL.transform.rotation;

                bulletL.SetActive(true);
            }
            yield return new WaitForSeconds(0.5F);

            GameObject bulletR = ObjectPool.sharedInstance.GetPooledObjectR();
            if (bulletR != null)
            {
                bulletR.transform.position = shootingPointL.transform.position;
                bulletR.transform.rotation = shootingPointL.transform.rotation;

                bulletR.SetActive(true);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

   
}
