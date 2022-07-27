using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprintState : PlayerBaseState
{
    readonly int SPRINT_HASH = Animator.StringToHash("Sprint");
    const float CROSSFADE = .1f;

    public PlayerSprintState(PlayerStateMachine stateMachine) :
        base(stateMachine)
    {
    }

    public override void Enter()
    {
        _stateMachine.Anim.CrossFadeInFixedTime (SPRINT_HASH, CROSSFADE);
    }

    public override void Tick(float deltaTime)
    {        
        if (!_stateMachine.InputController.IsSprinting)
        {
            _stateMachine.SwitchState(new PlayerRifleCombatState(_stateMachine));
            return;
        } //TODO mulitple combat states

        Vector3 movement = CalculateMovement();
        Move(movement * _stateMachine.SprintMoveSpeed, deltaTime);


        

        FaceMovementDirection (movement, deltaTime);
    }

    public override void Exit()
    {
 
    }
}
