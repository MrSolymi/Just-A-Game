using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "nameRangedAttackStateData", menuName = "Data/State Data/Ranged Attack State")]

public class D_RangedAttackState : ScriptableObject
{
    public GameObject projectile;
    public float projectileDamage = 10.0f,
        projectileSpeed = 12.0f,
        projectileTravelDistance = 10.0f;
}
