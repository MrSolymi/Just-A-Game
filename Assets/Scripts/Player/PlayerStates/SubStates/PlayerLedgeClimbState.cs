using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLedgeClimbState : PlayerState
{
    private Vector2 detectedPos,
        cornerPos,
        startPos,
        stopPos;
    private bool isHanging,
        isClimbing,
        jumpInput,
        isTouchingCeiling;
    private int xInput,
        yInput;
    public PlayerLedgeClimbState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBool) : base(player, stateMachine, playerData, animBool)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        player.Anim.SetBool("climbLedge", false);
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();

        isHanging = true;
    }

    public override void Enter()
    {
        base.Enter();

        player.SetVelocityZero();
        player.transform.position = detectedPos;
        cornerPos = player.DetermineCornerPosition();
        startPos.Set(cornerPos.x - (player.FacingDirection * playerData.startOffSet.x), cornerPos.y - playerData.startOffSet.y);
        stopPos.Set(cornerPos.x + (player.FacingDirection * playerData.stopOffSet.x), cornerPos.y + playerData.stopOffSet.y);

        player.transform.position = startPos;
    }

    public override void Exit()
    {
        base.Exit();

        isHanging = false;
        if (isClimbing)
        {
            player.transform.position = stopPos;
            isClimbing = false;
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAnimationFinished)
        {
            if (isTouchingCeiling)
            {
                stateMachine.ChangeState(player.CrouchIdleState);
            }
            else
            {
                stateMachine.ChangeState(player.IdleState);
            }
        }
        else
        {
            xInput = player.InputHandler.NormInputX;
            yInput = player.InputHandler.NormInputY;
            jumpInput = player.InputHandler.JumpInput;
            player.SetVelocityZero();
            player.transform.position = startPos;
            if (xInput == player.FacingDirection && isHanging && !isClimbing)
            {
                CheckForSpace();
                isClimbing = true;
                player.Anim.SetBool("climbLedge", true);
            }
            else if (yInput == -1 && isHanging && !isClimbing)
            {
                stateMachine.ChangeState(player.InAirState);
            }else if(jumpInput && !isClimbing)
            {
                player.WallJumpState.DetermineWallJumpDirection(true);
                stateMachine.ChangeState(player.WallJumpState);
            }

        }
    }

    public void SetDetectedPosition(Vector2 pos) => detectedPos = pos;
    private void CheckForSpace()
    {
        isTouchingCeiling = Physics2D.Raycast(cornerPos + (Vector2.up * 0.015f) + (Vector2.right * player.FacingDirection * 0.015f), Vector2.up, playerData.standColliderHeight, playerData.whatIsGround); ;
        player.Anim.SetBool("isTouchingCeiling", isTouchingCeiling);
    }
}
