using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class collisionsPlayer : MonoBehaviour
{

    Rigidbody2D rb;

    void Start()
    {
        //Debug.Log("In Collision script");
        rb = GetComponent<Rigidbody2D>();
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        GameObject obj = collision.gameObject;
        //if (collision.gameObject.layer == 0)
        //{

        //    Physics2D.IgnoreCollision(obj.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        //    Debug.Log("Collision Ignore from other Function");
        //}
        //else
        //if (!obj.CompareTag("Leaf"))
        //{
        //    Physics2D.IgnoreCollision(obj.GetComponent<TilemapCollider2D>(), GetComponent<BoxCollider2D>());
        //    Debug.Log("Collision Ignore from other Function");
        //}

        if (obj.CompareTag("Leaf"))
        {
            print("NAME " + obj.name);
            Debug.Log("hit detected");
            //Rigidbody.angularVelocity
            rb.velocity = Vector3.zero;
        } 
       
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        GameObject obj = collision.gameObject;
       
            Debug.Log("EXIT");

        if (obj.CompareTag("Leaf"))
        {
            rb.velocity = Vector3.zero;
        }


    }
}
