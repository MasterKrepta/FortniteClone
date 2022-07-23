using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
     [field: SerializeField] public float RotationDamping { get; private set; }
      [field: SerializeField] public float BaseMoveSpeed { get; private set; }
        [field: SerializeField] public float SprintMoveSpeed { get; private set; }
    [field: SerializeField]public Transform MainCameraTransform { get; private set; }

    [field: SerializeField]
    public InputController InputController { get; private set; }

    [field: SerializeField]
    public CharacterController Controller { get; private set; }

    [field: SerializeField]
    public Animator Anim { get; private set; }

    private void Start()
    {
        InputController = GetComponent<InputController>();
        SwitchState(new PlayerRifleCombatState(this));
    }
    
}
