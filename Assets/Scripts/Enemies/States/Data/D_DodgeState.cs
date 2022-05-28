using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "nameDodgeStateData", menuName = "Data/State Data/Dodge State")]
public class D_DodgeState : ScriptableObject
{
    public float dodgeSpeed = 10.0f,
        dodgeTime = 0.2f,
        dodgeCoolDown = 2.0f;
    public Vector2 dodgeAngle;
}
