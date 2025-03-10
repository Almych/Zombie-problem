using System;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageDefense
{
    float Defense(Damage damage);
}
[Serializable]
public struct DefenseData
{
    public DamageType damageType;
    [Header("Reduce damage by procents")]
    [Range(0,1)]public float resistence;
}

[CreateAssetMenu(fileName = "New DamageDefense", menuName = "DamageDefense")]
public class EnemyUniqDefense : ScriptableObject
{
    [SerializeField] private List<DefenseData> damagesToStayPercents = new List<DefenseData>();

    public float Defense(Damage damage)
    {
        return -damage.GetDamage() * (1-FindDamage(damage));
    }

    private float FindDamage(Damage damage)
    {
        if (damagesToStayPercents.Count == 0)
            return 0f;

        for (int i = 0; i < damagesToStayPercents.Count; i++)
        {
            if (damagesToStayPercents[i].damageType == damage.damageType)
            {
                return damagesToStayPercents[i].resistence;
            }
        }
        return 0f;
    }
}
