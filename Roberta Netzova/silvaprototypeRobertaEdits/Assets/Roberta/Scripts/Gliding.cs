using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gliding : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float Speed;
    [SerializeField] float Acceleration;
    [SerializeField] float RotationControl;
    [SerializeField] float RotationBoundary;
    Rigidbody2D rb;
    private Vector2 screenBounds;


    //X = 1 so the player is moving
    float MovY, MovX = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Debug.Log("Screen width: " + Screen.width);
        Debug.Log("Screen height: " + Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        MovY = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector2 Velocity = transform.right * (MovX * Acceleration);
        rb.AddForce(Velocity);
        Debug.Log("Velocity " + Velocity);

        // https://docs.unity3d.com/ScriptReference/Vector2.Dot.html
        //Dot can give us if the vectors are perpendicular if >0 vector is going up, if <0 it is going down
        //velocity -  It represents the rate of change of Rigidbody position.
        // vector right == Vecotr2(1,0);
        float Direction = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.right));

        if (Acceleration > 0)
        {
            if (Direction > 0)
            {
                Debug.Log("Direction > 0 ->  " + Direction);
                //Put the rotation some boundaries
                float NewRotationVal = MovY * RotationControl * (rb.velocity.magnitude / Speed); 
                if (NewRotationVal + rb.rotation < RotationBoundary && NewRotationVal + rb.rotation > RotationBoundary * -1)
                {
                    rb.rotation += MovY * RotationControl * (rb.velocity.magnitude / Speed);
                    Debug.Log("Rotation " + rb.rotation);
                } else
                {
                    
                    Debug.Log("Rotation out of boundaries" + rb.rotation);
                }
            }
            else
            {
                Debug.Log("Direction < 0 ->  " + Direction);
                rb.rotation -= MovY * RotationControl * (rb.velocity.magnitude / Speed);
            }
        }
        //transform.position += new Vector3(MovX, MovY, 0) * Time.deltaTime * Speed;

        float thrustForce = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.down)) * 2.0f;
        Vector2 relForce = Vector2.up * thrustForce;

        rb.AddForce(rb.GetRelativeVector(relForce));

        if (rb.velocity.magnitude > Speed)
        {
            rb.velocity = rb.velocity.normalized * Speed;
        }

        //Vector2 viewpos = transform.position;
        //// before 
        //// viewpos.y = mathf.clamp(viewpos.y, screenbounds.y, screenbounds.y * -1);

        //viewpos.y = Mathf.Clamp(viewpos.y, screenBounds.y * -1, screenbounds.y);

        //transform.position = viewpos;
    }

}