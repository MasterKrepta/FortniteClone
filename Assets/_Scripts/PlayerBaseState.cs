using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{

    protected PlayerStateMachine _stateMachine;

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
}
