using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CollectableConfig config;




    void Awake()
    {
        CollectablesSpawn.Init(config);
    }
}
