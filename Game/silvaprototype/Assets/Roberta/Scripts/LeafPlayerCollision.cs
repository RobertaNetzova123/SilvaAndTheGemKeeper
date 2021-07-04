using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafPlayerCollision : MonoBehaviour
{
    //    // Start is called before the first frame update
    Rigidbody2D rb;

    //    void Start()
    //    {
    //        //Debug.Log("In Collision script");
    //        //rb = GetComponent<Rigidbody2D>();
    //    }
    //    void OnCollisionStay2D(Collision2D collision)
    //    {
    //        GameObject obj = collision.gameObject;
    //        rb = obj.GetComponent<Rigidbody2D>();
    //        rb.velocity = Vector3.zero;

    //        Debug.Log("hit detected");
    //        //HandleMovementFromCollision(collision);
    //    }

    //    void OnCollisionExit2D(Collision2D collision)
    //    {

    //        Debug.Log("EXIT");

    //        rb.velocity = Vector3.zero;
    //        //HandleMovementFromCollision(collision);

    //    }

    //    // Prevents the object hit by the leaf from moving continiously because of the collision
    //   private void HandleMovementFromCollision(Collision2D collision)
    //    {
    //        GameObject obj = collision.gameObject;
    //        rb = obj.GetComponent<Rigidbody2D>();
    //        rb.velocity = Vector3.zero;
    //    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        GameObject obj = collision.gameObject;
        print(obj.name + " NAME");
        if (obj.CompareTag("Leaf"))
        {
            Debug.Log("hit detected");
            //Rigidbody.angularVelocity
            rb.velocity = Vector3.zero;
        }
    }


    void OnCollisionExit2D(Collision2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.CompareTag("Leaf"))
        {
            Debug.Log("EXIT");
            rb.velocity = Vector3.zero;
        }
    }
}
