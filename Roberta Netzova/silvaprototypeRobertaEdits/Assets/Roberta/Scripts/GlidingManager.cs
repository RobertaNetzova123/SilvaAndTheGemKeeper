using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlidingManager : MonoBehaviour
{
    private Camera CameraMain;
    private Rigidbody2D rb;
    private int n = 0;
    private float lastTime;
    private bool glidingActivated = false;

    private bool glidingAbility;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        n = 0;
        lastTime = -1.0f;
        CameraMain = Camera.main;

        glidingAbility = gameObject.GetComponent<AbilitiesController>().gliding;

        ActivateCharacterController();
        ActivateCameraFollow();
        DisableScreenBoundaries();
       
       
    }

    // Update is called once per frame
    void Update()
    {
        //get the gliding status
        glidingAbility = gameObject.GetComponent<AbilitiesController>().gliding;

        if (Input.GetButtonDown("Jump"))
        {
           if (Time.time - lastTime < 0.2f )
           {
                lastTime = Time.time;
                Debug.Log("____DOUBLE____");
                if (!glidingActivated && glidingAbility)
                {
                    Debug.Log("Glide");
                    ActivateGliding();
                } else
                {
                    Debug.Log("Character");
                    ActivateCharacterController();
                }

               
            }
            else
            {
                lastTime = Time.time;
            }
            Debug.Log("Time:" + lastTime);
            //Debug.Log("Tap " + ++n);

        }
      
    }

    //private void switchActivatedComponents (Object component1, Component component2)
    //{
    //    this.gameObject.GetComponent<component1>()
    //}

    private void ActivateGliding()
    {
        //set normal movement cotroller to not active
        this.gameObject.GetComponent<Character2DController>().enabled = false;
        //set gliding script to active 
        this.gameObject.GetComponent<Gliding_NoRotation>().enabled = true;
        //cancels any current movement from the last activated script

        rb.freezeRotation = true;
        rb.velocity = Vector3.zero;
        rb.gravityScale = 0;

        glidingActivated = true;

        //change cameraFollowGlide
        ActivateCameraFollowGlide();

        EnableScreenBoundaries();
        //EnableGlidingCollisions();
    }

    private void ActivateCharacterController()
    {
        //set gliding script to active 
        this.gameObject.GetComponent<Gliding_NoRotation>().enabled = false;
        //set normal movement cotroller to not active
        this.gameObject.GetComponent<Character2DController>().enabled = true;
        //cancels any current movement from the last activated script
        rb.velocity = Vector3.zero;
        //gravity needs to be introduced back maybe we need to add it to the script of Vlad
        rb.gravityScale = 1;
        glidingActivated = false;

        //change cameraFollow
        ActivateCameraFollow();
        DisableScreenBoundaries();
        //DisableGlidingCollisions();

    }

    private void EnableGlidingCollisions()
    {
        this.gameObject.GetComponent<collisionsPlayer>().enabled = true;
    }

    private void DisableGlidingCollisions()
    {
        this.gameObject.GetComponent<collisionsPlayer>().enabled = false;
    }
    private void EnableScreenBoundaries()
    {
        this.gameObject.GetComponent<ScreenBoundaries>().enabled = true;
    }
    private void DisableScreenBoundaries()
    {
        this.gameObject.GetComponent<ScreenBoundaries>().enabled = false;
    }
    private void ActivateCameraFollow()
    {
        CameraMain.GetComponent<CameraFollow>().enabled = true;
        CameraMain.GetComponent<CameraFollowGlide>().enabled = false;
    }

    private void ActivateCameraFollowGlide()
    {
        CameraMain.GetComponent<CameraFollow>().enabled = false;
        CameraMain.GetComponent<CameraFollowGlide>().enabled = true;
    }
}
