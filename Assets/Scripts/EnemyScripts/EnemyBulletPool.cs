using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletPool : MonoBehaviour
{
    public static EnemyBulletPool instance;
    [SerializeField]private EnemyBulletBehaivior bulletEnemy;
    [SerializeField]private int amount;
    private List<EnemyBulletBehaivior> pooledBullet = new List<EnemyBulletBehaivior>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        for (int i = 0; i < amount; i++)
        {
            var bullet = Instantiate(bulletEnemy);
            bullet.gameObject.SetActive(false);
            pooledBullet.Add(bullet);
        }
    }

    public EnemyBulletBehaivior GetBullet()
    {
        for (int i = 0; i < pooledBullet.Count; i++)
        {
            if (!pooledBullet[i].gameObject.activeInHierarchy)
            {
                return pooledBullet[i];
            }
        }
        return null;
    }
}
