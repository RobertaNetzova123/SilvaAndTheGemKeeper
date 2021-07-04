using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingLeafBackup : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
        //rb.velocity = new Vector2(-speed, 0);
        //screen bounds defined -. size of the screen
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

    }

    // Update is called once per frame
    void Update()
    {
        // screen bounds are positive and since we are moving to the left our position will be negative when we get out of the screen
        //*2 so the object disappears outside of the screen
        if (transform.position.y < screenBounds.y * - 2)
        {
            Destroy(this.gameObject);
        }
        //Debug.Log("Screen bounds: " + screenBounds.y * -2 + "\nObject: " + transform.position.y);
    }
    
}

//horizontal movement
//if (transform.position.x < screenBounds.x - 1 * 2)
//{
//    Destroy(this.gameObject);
//}