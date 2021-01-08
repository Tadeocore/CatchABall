using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    Vector3 dir;
   
    public Rigidbody rb;
    public float speed = 5f;
    public float maxSpeed = 5f;
    public float minSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.forward * speed);
            Debug.Log(rb.velocity);

        }
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(GetComponent<Rigidbody>().velocity, maxSpeed);
        }
        if (rb.velocity.magnitude < minSpeed)
        {
            rb.velocity = Vector3.ClampMagnitude(GetComponent<Rigidbody>().velocity, minSpeed);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Map"))
        {
            Vector3 wallNormal = other.contacts[0].normal;
            dir = Vector3.Reflect(rb.velocity, wallNormal);
            rb.velocity = dir * speed;
        }
    }
}
