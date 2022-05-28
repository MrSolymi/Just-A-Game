using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data/Base Data")]
public class D_Entity : ScriptableObject
{
    public float maxHealth = 30.0f,
        wallCheckDistance = 0.2f,
        ledgeCheckDistance = 0.4f,
        maxAgroDistance = 4.0f,
        minAgroDistance = 3.0f,
        closeRangeActionDistance = 1,
        damageHopSpeed = 3.0f,
        groundCheckRadius = 0.3f,
        stunResistance = 3.0f,
        stunRecoveryTime = 2.0f;

    public GameObject hitParticle;

    public LayerMask whatIsGround,
        whatIsPlayer;
}
