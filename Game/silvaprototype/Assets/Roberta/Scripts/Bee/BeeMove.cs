using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeeMove : MonoBehaviour
{
    [SerializeField] int MovementSpeed = 1;
    [SerializeField] int Range = 3;
    //private int movDirection = 1;
    private int rotationVal;
    private float turnPlace;
    private float currentPlace;
    // Start is called before the first frame update
    void Start()
    {
        turnPlace = transform.position.x;
        currentPlace = transform.position.x;
       
        rotateSprite();
    }

    // Update is called once per frame
    void Update()
    {
        

        print("TURN " + (turnPlace) + " Current " +currentPlace );
        if (Mathf.Abs(turnPlace - currentPlace) > Range)
        {
            print("TURN");
            turnPlace = transform.position.x;
            //movDirection *= -1;
            MovementSpeed *= -1;
            rotateSprite();
        }
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(Time.deltaTime * MovementSpeed, 0, 0);
        currentPlace = transform.position.x;

       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void rotateSprite()
    {
        if (MovementSpeed < 0)
        {
            rotationVal = 0;
        }
        else
        {
            rotationVal = 180;
        }

        //transform.localRotation = movDirection < 0 ? Quaternion.Euler(0, , 0) : Quaternion.identity;
        transform.localRotation = Quaternion.Euler(0, rotationVal, 0);
    }
}
