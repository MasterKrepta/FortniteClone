using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRifleCombatState : PlayerBaseState
{
    readonly int LOCOMOTION_HASH = Animator.StringToHash("Locomotion_Rifle");
    readonly int FWD_HASH = Animator.StringToHash("Fwd");
    readonly int HOR_HASH = Animator.StringToHash("Hor");

    const float CROSSFADE = .1f;
  
  

    public PlayerRifleCombatState(PlayerStateMachine stateMachine) :
        base(stateMachine)
    {
    }

    public override void Enter()
    {
          _stateMachine.Anim.CrossFadeInFixedTime (LOCOMOTION_HASH, CROSSFADE);
          _stateMachine.InputController.OnShootEvent += _stateMachine.Weapon.Fire;
          Cursor.lockState = CursorLockMode.Locked;
    }

    public override void Tick(float deltaTime)
    {
        if (_stateMachine.InputController.IsSprinting)
        {
            _stateMachine.SwitchState(new PlayerSprintState(_stateMachine));
            return;
        }
        Vector3 movement = CalculateMovement();

        Move(movement * _stateMachine.BaseMoveSpeed, deltaTime);

        //FaceMovementDirection (movement, deltaTime);

        if (movement == Vector3.zero)
        {
            _stateMachine.Anim.SetFloat(FWD_HASH, 0, .1f, deltaTime);
            _stateMachine.Anim.SetFloat(HOR_HASH, 0, .1f, deltaTime);
            return;
        }
        _stateMachine.Anim.SetFloat(FWD_HASH, movement.z, 0.1f, deltaTime);
        _stateMachine.Anim.SetFloat(HOR_HASH, movement.x, 0.1f, deltaTime);
    }

    public override void Exit()
    {
_stateMachine.InputController.OnShootEvent -= _stateMachine.Weapon.Fire;
    }
}
