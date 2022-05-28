using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public PlayerInput playerInput;
    private Camera cam;
    public Vector2 RawMovementIntput { get; private set; }
    public Vector2 RawDashDirectionInput { get; private set; }
    public Vector2Int DashDirectionInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }
    public bool JumpInput { get; private set; }
    public bool JumpInputStop { get; private set; }
    public bool GrabInput { get; private set; }
    public bool DashInput { get; private set; }
    public bool DashInputStop { get; private set; }
    
    [SerializeField]
    private float inputHoldTime = 0.2f;

    private float jumpInputStartTime,
        dashInputStartTime;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        cam = Camera.main;
    }
    private void Update()
    {
        CheckJumpInputHoldTime();
        CheckDashInputHoldTime();
    }
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementIntput = context.ReadValue<Vector2>();
        if (Mathf.Abs(RawMovementIntput.x) > 0.5f)
        {
            NormInputX = (int)(RawMovementIntput * Vector2.right).normalized.x;
        }
        else
        {
            NormInputX = 0;
        }
        if (Mathf.Abs(RawMovementIntput.y) > 0.5f)
        {
            NormInputY = (int)(RawMovementIntput * Vector2.up).normalized.y;
        }
        else
        {
            NormInputY = 0;
        }
    }
    public void OnDashInput(InputAction.CallbackContext contex)
    {
        if (contex.started)
        {
            DashInput = true;
            DashInputStop = false;
            dashInputStartTime = Time.time;
        }
        else if (contex.canceled)
        {
            DashInputStop = true;
        }
    }
    public void OnDashDirectionInput(InputAction.CallbackContext contex)
    {
        RawDashDirectionInput = contex.ReadValue<Vector2>();

        if (playerInput.currentControlScheme == "Keyboard")
        {
            RawDashDirectionInput = cam.ScreenToWorldPoint((Vector3)RawDashDirectionInput) - transform.position;
        }
        DashDirectionInput = Vector2Int.RoundToInt(RawDashDirectionInput.normalized);
    }
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpInput = true;
            JumpInputStop = false;
            jumpInputStartTime = Time.time;
        }
        if (context.canceled)
        {
            JumpInputStop = true;
        }
    }
    public void OnGrabInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            GrabInput = true;
        }
        if (context.canceled)
        {
            GrabInput = false;
        }
    }
    public void UseJumpInput() => JumpInput = false;
    public void UseDashInput() => DashInput = false;
    private void CheckJumpInputHoldTime()
    {
        if (Time.time >= jumpInputStartTime + inputHoldTime)
        {
            JumpInput = false;
        }
    }
    private void CheckDashInputHoldTime()
    {
        if (Time.time >= dashInputStartTime + inputHoldTime)
        {
            DashInput = false;
        }
    }
}
