using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class MoveForward : MonoBehaviour
{
    [SerializeField]
    float bulletSpeed = 50f;

    public Transform decal;

    [SerializeField]
    float lifetime = 1f;

    Rigidbody rb;

    public Vector3 target { get; set; }

    public bool hit { get; set; }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =
            Vector3
                .MoveTowards(transform.position,
                target,
                bulletSpeed * Time.deltaTime);
        if (!hit && Vector3.Distance(transform.position, target) < .01f)
        {
            Destroy (gameObject); //TODO pooling
        }
        // //todo move towards aim point once aiming is configured
        // rb.AddForce(transform.forward * bulletSpeed * Time.deltaTime);

        // Destroy(this.gameObject, lifetime); //todo object pooling
    }

    private void OnCollisionEnter(Collision other)
    {
        ContactPoint contact = other.GetContact(0);
        GameObject
            .Instantiate(decal,
            contact.point + contact.normal * .0001f,
            Quaternion.LookRotation(contact.normal));
        Destroy (gameObject);
    }
}
