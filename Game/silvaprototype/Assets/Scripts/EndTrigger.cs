using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    public GameMaster gm;

    bool endMessageOpen = false;
    public GameObject endMessage;

    void OnTriggerEnter2D(Collider2D collision)
    {
        endMessage.SetActive(true);
        endMessageOpen = true;
        gm.CompleteLevel();
        collision.GetComponent<Character2DController>().enabled = false;
    }

    private void Update()
    {
        if (endMessageOpen && Input.anyKeyDown)
        {
            if (SceneManager.GetActiveScene().buildIndex < 2)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            else
                SceneManager.LoadScene("Menu");
        }
    }
}
