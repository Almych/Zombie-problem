using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Instance;
    [SerializeField] private int amountBullet;
    [SerializeField] private BulletBehaivior bulletPrefab;
    private List<BulletBehaivior> pooledObjects = new List<BulletBehaivior>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }else
        {
            Destroy(Instance);
        }
    }

    private void Start()
    {
        for (int i = 0; i < amountBullet; i++)
        {
            BulletBehaivior obj = Instantiate(bulletPrefab);
            obj.gameObject.SetActive(false);
            pooledObjects.Add(obj);
        }
    }


    public BulletBehaivior GetPoolObject()
    {
        for(int i =0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].gameObject.activeInHierarchy)
            {
                pooledObjects[i].gameObject.SetActive(true);
                return pooledObjects[i];
            }
        }
        return null;
    }
}
