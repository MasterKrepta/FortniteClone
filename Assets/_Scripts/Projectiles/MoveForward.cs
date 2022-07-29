using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class MoveForward : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 1500;
    [SerializeField] float lifetime = 1f;
    
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //todo move towards aim point once aiming is configured
        rb.AddForce(transform.forward * bulletSpeed * Time.deltaTime);
        
        Destroy(this.gameObject, lifetime); //todo object pooling
    }
}

