using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRifleCombatState : PlayerBaseState
{
    readonly int LOCOMOTION_HASH = Animator.StringToHash("Locomotion_Rifle");
    const float CROSSFADE = .1f;

    public PlayerRifleCombatState(PlayerStateMachine stateMachine) :
        base(stateMachine)
    {
    }

    public override void Enter()
    {
        _stateMachine.Anim.CrossFadeInFixedTime (LOCOMOTION_HASH, CROSSFADE);
    }

    public override void Tick(float deltaTime)
    {
        Debug.Log(_stateMachine.InputController.MovementValue);
        Vector3 movement = CalculateMovement();
        Debug.Log(movement);
        Move(movement * _stateMachine.BaseMoveSpeed, deltaTime);

        FaceMovementDirection(movement, deltaTime);
    }

    public override void Exit()
    {
    }
}
