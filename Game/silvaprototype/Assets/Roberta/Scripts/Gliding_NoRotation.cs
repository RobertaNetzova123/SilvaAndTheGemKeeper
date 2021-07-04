using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gliding_NoRotation : MonoBehaviour
{

    [SerializeField] float Speed =  1; 
    [SerializeField] float Acceleration;
    [SerializeField] Animator animator;

    Rigidbody2D rb;

    float MovY, MovX = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.velocity = Vector3.zero;
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MovY = Input.GetAxis("Vertical");
        MovX = Input.GetAxis("Horizontal");
        //if(MovX == 0)
        //{
        //    MovX = 1;
        //} 
        //always moving but the player also has some control over it
        animator.SetFloat("GlVertical", MovY);

        if (MovX < 0)
        {
            MovX -= 1;

        }
        else
        {
            MovX += 1;
        }

        //Debug.Log("MovX : " + MovX);
        //Debug.Log("MovY :_____ " + MovY);
    }

    private void FixedUpdate()
    {
        //transform.position += new Vector3(MovX, MovY, 0) * Time.deltaTime * Speed;

        // move also on the Y axis
        transform.position += new Vector3(MovX, MovY, 0) * Time.deltaTime * Speed;
    }

  
}
