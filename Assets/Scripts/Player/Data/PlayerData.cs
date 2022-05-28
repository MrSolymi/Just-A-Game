using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementVelocity = 10.0f;
    [Header("Jump State")]
    public float jumpVelocity = 15.0f;
    public int amountOfJumps = 1;
    [Header("Check Variables")]
    public float groundCheckRadius = 0.3f;
    public LayerMask whatIsGround;
    public float wallCheckDistance = 0.5f;
    [Header("In Air State")]
    public float coyoteTime = 0.2f,
        variableJumpHeightMultiplier = 0.5f;
    [Header("Wall Slide State")]
    public float wallSlideVelocity = 3.0f;
    [Header("Wall Climb State")]
    public float wallClimbVelocity = 3.0f;
    [Header("Wall Jump State")]
    public float wallJumpVelocity = 20.0f,
        wallJumpTime = 0.4f;
    public Vector2 wallJumpAngle = new Vector2(1, 2);
}
