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
    public float coyoteTime = 0.2f;
    public float variableJumpHeightMultiplier = 0.5f;
    [Header("Wall Slide State")]
    public float wallSlideVelocity = 3.0f;
    [Header("Wall Climb State")]
    public float wallClimbVelocity = 3.0f;
    [Header("Wall Jump State")]
    public float wallJumpVelocity = 20.0f;
    public float wallJumpTime = 0.4f;
    public Vector2 wallJumpAngle = new Vector2(1, 2);
    [Header("Ledge Climb State")]
    public Vector2 startOffSet;
    public Vector2 stopOffSet;
    [Header("Dash State")]
    public float dashCoolDown = 1.0f;
    public float maxHoldTime = 1.0f;
    public float holdTimeScale = 0.25f;
    public float dashTime = 0.2f;
    public float dashVelocity = 30.0f;
    public float drag = 10.0f;
    public float dashEndYMultiplier = 0.2f;
    public float distanceBetweenAfterImages = 0.5f;
}
