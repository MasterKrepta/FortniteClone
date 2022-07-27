using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [field:SerializeField] float TurnSpeed = 60;
    [SerializeField]PlayerStateMachine stateMachine;
    void FixedUpdate() {
        float yawCam = stateMachine.MainCamera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCam, 0), Time.deltaTime * TurnSpeed);
    }
}
