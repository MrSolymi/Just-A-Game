using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newStunStateData", menuName = "Data/State Data/Stun State")]
public class D_StunState : ScriptableObject
{
    public float stunTime = 3.0f,
        stunKnockbackTime = 0.2f,
        stunKnockbackSpeed = 20.0f;
    public Vector2 stunKnockbackAngle;
}
