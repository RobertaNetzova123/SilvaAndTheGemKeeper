/*using System.Collections;
using System.Collections.Generic;*/
using UnityEngine;

public class SliderScript : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float forwardForce;
    [SerializeField] private float sidewaysForce;
    private float horizontalInput;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        forwardForce = 20f;
        sidewaysForce = 500f;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal") * sidewaysForce* Time.deltaTime;
    }

    // Added "Fixed update" because we are using it to mess with physics
    void FixedUpdate()
    {
        //time.deltatime is in order to even out the difference between systems update frequences
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        /*if(Input.GetKeyDown("d"))
        {
            rb.AddForce
        }*/

        //rigidbodyComponent.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
        // Create new vector3 and assign the x to horizontalInput
        rb.velocity = new Vector3(horizontalInput, rb.velocity.y, rb.velocity.z);
    }
   
}
