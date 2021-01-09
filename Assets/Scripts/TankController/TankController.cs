using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{

    public float mov = 5f;
    public float rot = 40f;
    public Transform emitter;
    public Transform cannon;
    public Transform prefab;
    public Rigidbody rb;
    public float explo;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //transform.Translate(new Vector3(0, 0, mov) * Time.deltaTime) ;
            rb.AddForce(transform.forward * mov, ForceMode.Impulse);
        
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, -mov) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -rot, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, rot, 0) * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Period))
        {
            Instantiate(prefab, emitter.position, emitter.rotation);
            Destroy(prefab, 5);
            rb.AddForce(transform.forward * -explo, ForceMode.Impulse);
        }
    }
}
