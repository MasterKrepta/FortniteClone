using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private State _currentState;

    private void Update()
    {
        _currentState?.Tick();
    }
    public void SwitchState(State newState)
    {
        _currentState?.Exit();
        _currentState = newState;
        _currentState?.Enter();
    }
}
