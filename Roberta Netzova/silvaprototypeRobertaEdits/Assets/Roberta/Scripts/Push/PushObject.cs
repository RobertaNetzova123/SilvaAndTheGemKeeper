using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObject : MonoBehaviour
{
    private bool pushKeyPressed;
    private bool collisionIgnore = false;
    private float noMass = 0.0001f;
    private float mass = 1;

    // Start is called before the first frame update
    void Start()
    {
        pushKeyPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            //Debug.Log("E");
            pushKeyPressed = true;
        } else
        {
            pushKeyPressed = false;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        
        GameObject obj = collision.gameObject;
        if (collision.gameObject.tag == "object" && pushKeyPressed == false && !obj.GetComponent<objectChange>().objectChanged)
        {
            obj.GetComponent<BoxCollider2D>().isTrigger = true;
            Physics2D.IgnoreCollision(obj.GetComponent<PolygonCollider2D>(), GetComponent<BoxCollider2D>());
            Debug.Log("Collision Ignore from other Function");

            // add mass so the object and the player interact better
            changeObjMass(obj, mass);
        }
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject obj = other.gameObject;
        if (other.gameObject.tag == "object" && pushKeyPressed == false)
        {
            Physics2D.IgnoreCollision(obj.GetComponent<PolygonCollider2D>(), GetComponent<BoxCollider2D>());
            Debug.Log("Collision Ignore");
        }
        else if (other.gameObject.tag == "object" && pushKeyPressed == true)
        {
            //Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            //rb.
            obj.GetComponent<BoxCollider2D>().isTrigger = false;

            // remove mass so the object is sliding better
            changeObjMass(obj, noMass);
        }
    }

    private void changeObjMass (GameObject obj, float mass)
    {
        obj.GetComponent<Rigidbody2D>().mass = mass;
    }
}
