using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingLeaf : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    private float cameraSizeY;
    private Vector3 cameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        cameraPosition = Camera.main.transform.position;
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
        //rb.velocity = new Vector2(-speed, 0);
        //screen bounds defined -. size of the screen
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        cameraSizeY = Camera.main.orthographicSize * 2f;

    }

    // Update is called once per frame
    void Update()
    {
        // screen bounds are positive and since we are moving to the left our position will be negative when we get out of the screen
        //*2 so the object disappears outside of the screen
        //if (transform.position.y < screenBounds.y * - 2)
        //{
        //    Destroy(this.gameObject);
        //}
        //Debug.Log("Screen bounds: " + screenBounds.y * -2 + "\nObject: " + transform.position.y);

        
        if (transform.position.y < cameraPosition.y - cameraSizeY)
        {
            Destroy(this.gameObject);
            //Debug.Log("DESTROY");
        }
        //Debug.Log("Bounds: " + screenBounds.y * -2);
        //Debug.Log("Camera y " +( cameraPosition.y - cameraSizeY) + "\nObject: " + transform.position.y);
    }

}

//horizontal movement
//if (transform.position.x < screenBounds.x - 1 * 2)
//{
//    Destroy(this.gameObject);
//}