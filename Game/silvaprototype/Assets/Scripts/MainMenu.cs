using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject ControlMenuUI;
    
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void Controls()
    {
        ControlMenuUI.SetActive(true);
    }

    public void GoBack()
    {
        ControlMenuUI.SetActive(false);
    }
}
