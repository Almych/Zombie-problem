using System;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageDefense
{
    float Defense(Damage damage);
    void GetDefenses();
}

[CreateAssetMenu(fileName = "New DamageDefense", menuName = "DamageDefense")]
public class EnemyUniqDefense : ScriptableObject
{
    //[SerializeField] private List<DefenseData> damagesToStayPercents = new List<DefenseData>();

    //public float Defense(Damage damage)
    //{
    //    float defense =  FindDamage(damage);
    //    return defense - damage.GetDamage();
    //}

    //public void GetDefenses()
    //{
       
    //}

    //private float FindDamage(Damage damage)
    //{
    //    for(int i = 0; i <  damagesToStayPercents.Count; i++)
    //    {
    //        if (damagesToStayPercents[i].damage.GetType() == damage.GetType())
    //        {
    //            return damagesToStayPercents[i].resistence;
    //        }
    //    }
    //    return 0f;
    //}
}
