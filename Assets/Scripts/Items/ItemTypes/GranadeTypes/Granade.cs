using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Granade : MonoBehaviour
{
    [SerializeField]protected float radius;

    public abstract void Throw();
}
