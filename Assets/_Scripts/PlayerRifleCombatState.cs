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
        Vector3 movement = CalculateMovement();

        Move(movement * _stateMachine.BaseMoveSpeed, deltaTime);

        FaceMovementDirection (movement, deltaTime);

        if (movement == Vector3.zero)
        {
            _stateMachine.Anim.SetFloat("Blend", 0, .1f, deltaTime);
            return;
        }
        _stateMachine.Anim.SetFloat("Blend", 1, 0.1f, deltaTime);
    }

    public override void Exit()
    {
    }
}
