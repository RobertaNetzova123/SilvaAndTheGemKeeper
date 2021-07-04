using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioClip splashSound;

    public AudioSource audioS;
    public bool inWater = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //bool water = this.gameObject.GetComponent<PlayerPos>().isInWater;

        //if (water)
        //{
        //    audioS.PlayOneShot(splashSound);
        //}


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("In water");
        if (collision.gameObject.layer == LayerMask.GetMask("Ground"))
        {
            audioS.PlayOneShot(splashSound);
        }
    }
}
