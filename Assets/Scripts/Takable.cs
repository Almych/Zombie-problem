using System;
using UnityEngine;
public abstract class Takable : MonoBehaviour, ICollectable
{
    protected SpriteRenderer render;
    public void Init()
    {
        render = GetComponent<SpriteRenderer>();
    }
    public virtual void OnCollect()
    {
        gameObject.SetActive(false);
    }
}