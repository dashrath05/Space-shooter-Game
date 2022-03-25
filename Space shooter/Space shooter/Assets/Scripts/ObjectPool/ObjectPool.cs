using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    public int score = 0;
    private List<GameObject> pooledBulletObjects = new List<GameObject>();
    private int AmountToPool = 40;
    [SerializeField] private GameObject bulletPrefab;
    
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //bullet Instantiate and add to list
        for (int i = 0; i < AmountToPool; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            pooledBulletObjects.Add(bullet);
        }
    }

    public GameObject GetBulletPooledObject()
    {
        for (int i = 0; i < pooledBulletObjects.Count; i++)
        {
            if (!pooledBulletObjects[i].activeInHierarchy)
            {
                return pooledBulletObjects[i];

            }
        }
        return null;
    }

  
}
