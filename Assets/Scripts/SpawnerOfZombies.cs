using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class SpawnerOfZombies : MonoBehaviour
{
    [SerializeField] private List<AverageZombie> allowedZombie;
    [SerializeField] private int averageZombie, longZombie, speedyZombie, bigZombie;
    private float randomY;
    private void Start()
    {
        ChangePosition();
        for (int i = 0; i < averageZombie; i++)
        {
            ChangePosition();
            Instantiate(allowedZombie[0], new Vector3(transform.position.x, randomY, transform.position.z), Quaternion.identity);
        }

        for (int i = 0; i < longZombie; i++)
        {
            ChangePosition();
            Instantiate(allowedZombie[1], new Vector3(transform.position.x, randomY, transform.position.z), Quaternion.identity);
        }

        for (int i = 0; i < speedyZombie; i++)
        {
            ChangePosition();
            Instantiate(allowedZombie[2], new Vector3(transform.position.x, randomY, transform.position.z), Quaternion.identity);
        }

        for (int i = 0; i < bigZombie; i++)
        {
            ChangePosition();
            Instantiate(allowedZombie[3],new Vector3(transform.position.x, randomY, transform.position.z), Quaternion.identity);
            ChangePosition();
        }
    }

    private void ChangePosition ()
    {
        var randomPos = Random.Range(3f, transform.position.y);
        randomY = randomPos;
    }

}
