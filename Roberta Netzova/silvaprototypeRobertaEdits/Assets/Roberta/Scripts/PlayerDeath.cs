using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= screenBounds.y*-1)
        {
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);

            //StartCoroutine(RestartScene());
            LoadScene();
        }
        //Debug.Log("Position: " + transform.position.y + " Screen: " + screenBounds.y);
    }

    private void LoadScene()
    {
        Scene thisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(thisScene.name);
    }
    IEnumerator RestartScene()
    {
        Debug.Log("In COROUTINE");
            yield return new WaitForSeconds(1.0f);
            LoadScene();  
    }

  
}
