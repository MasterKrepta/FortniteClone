using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public InputController InputController { get; private set; }
    private void Start()
    {
        InputController = GetComponent<InputController>();
    }

}
