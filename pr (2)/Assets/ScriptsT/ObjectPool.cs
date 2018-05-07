using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool sharedInstance;
    public List<GameObject> pooledObjectsL;
    public GameObject objectToPoolL;

    public List<GameObject> pooledObjectsR;
    public GameObject objectToPoolR;
    public int amountToPool;

    void Awake()
    {
        if (sharedInstance == null)
            sharedInstance = this;

    }

    void Start()
    {

        pooledObjectsL = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPoolL);
            obj.SetActive(false);
            pooledObjectsL.Add(obj);

            DontDestroyOnLoad(pooledObjectsL[i]);
        }

        pooledObjectsR = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPoolR);
            obj.SetActive(false);
            pooledObjectsR.Add(obj);

           DontDestroyOnLoad(pooledObjectsR[i]);
        }

    }

    public GameObject GetPooledObjectL()
    {
        for (int i = 0; i < pooledObjectsL.Count; i++)
        {
            if (!pooledObjectsL[i].activeInHierarchy)
            {
                return pooledObjectsL[i];
            }
        }  
        return null;
    }

    public GameObject GetPooledObjectR()
    {
        for (int i = 0; i < pooledObjectsR.Count; i++)
        {
            if (!pooledObjectsR[i].activeInHierarchy)
            {
                return pooledObjectsR[i];
            }
        }  
        return null;
    }

}
