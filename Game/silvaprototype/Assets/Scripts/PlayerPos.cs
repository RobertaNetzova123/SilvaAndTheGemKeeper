using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPos : MonoBehaviour
{
    private GameMaster gm;

    //variables for ground check
    public bool isInWater;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsWater;


    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.LastCheckpointPos;
    }

    private void Update()
    {
        isInWater = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsWater);

        if (isInWater || transform.position.y < -60)
        {
          // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void CompleteLevel ()
    {
        Debug.Log("LEVEL WON");
    }
}
