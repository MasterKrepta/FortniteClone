using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
#region VARS

    protected PlayerStateMachine _stateMachine;

    
#endregion


    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void Move(Vector3 motion, float deltaTime)
    {
        _stateMachine.Controller.Move(motion * deltaTime);
    }

    public Vector3 CalculateMovement()
    {
        Vector3 fwd = _stateMachine.MainCameraTransform.forward;
        Vector3 right = _stateMachine.MainCameraTransform.right;

        fwd.y = 0f;
        right.y = 0f;

        fwd.Normalize();
        right.Normalize();

        return fwd * _stateMachine.InputController.MovementValue.y +
        right * _stateMachine.InputController.MovementValue.x;
    }

    public void FaceMovementDirection(Vector3 movement, float deltaTime)
    {
        if (movement == Vector3.zero) return;
        {
        }

        _stateMachine.transform.rotation =
            Quaternion
                .Lerp(_stateMachine.transform.rotation,
                Quaternion.LookRotation(movement),
                deltaTime * _stateMachine.RotationDamping);
    }

//   public void HandleSprint(){
  
//     _stateMachine.SwitchState(new PlayerSprintState(_stateMachine));
//   }
}
