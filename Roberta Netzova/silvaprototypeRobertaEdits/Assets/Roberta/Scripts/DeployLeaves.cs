using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployLeaves: MonoBehaviour
{
    [SerializeField] GameObject objPrefab;
    [SerializeField] float respawnTime = 1.0f;
    [SerializeField] int distanceBetweenLeaves = 1;

    private Vector2 screenBounds;
    private Vector3 cameraPosition;
    private float cameraSizeX;
    private float cameraSizeY;
    
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(leafWave());

    }

    // Update is called once per frame
    void Update()
    {
        //screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
         cameraPosition = Camera.main.transform.position;

        //Debug.Log("Bounds x: " + screenBounds.x + " Bounds -x: " + -screenBounds.x);
        //Debug.Log("CAMERA X:" + cameraPosition.x);
        //Debug.Log("Bounds x: " + screenBounds.x + " Bounds y: " + screenBounds.y);
        cameraSizeX = Camera.main.aspect * 2f * Camera.main.orthographicSize;
        cameraSizeY = Camera.main.orthographicSize * 2f;
        //Debug.Log ("CAMERA SIZE X:" +  cameraSizeX);

    }
    
    private void spawnObject()
    {
        //precise spawn
        PatternSpawn();

        //radom spawn

        //for (int i = 0; i < 5; i++)
        //{

        //    // add the object to the scene
        //    GameObject obj = Instantiate(objPrefab) as GameObject;
        //    //place on the screen random at x and outside of y
        //    //obj.transform.position = new Vector2(Random.Range (screenBounds.x, -screenBounds.x), screenBounds.y * 2);
        //    obj.transform.position = new Vector2(Random.Range(cameraPosition.x , cameraPosition.x + cameraSizeX), screenBounds.y * 2);

        //    //Vector3 viewPos = transform.position;
        //    //viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1, screenBounds.y);
        //    //transform.position = viewPos;

        //}

        //// add the object to the scene
        //GameObject obj = Instantiate(objPrefab) as GameObject;
        ////place on the screen random at x and outside of y
        ////obj.transform.position = new Vector2(Random.Range (screenBounds.x, -screenBounds.x), screenBounds.y * 2);
        //obj.transform.position = new Vector2(Random.Range(cameraPosition.x - (cameraSizeX / 2), cameraPosition.x + cameraSizeX), screenBounds.y * 2);

        ////Vector3 viewPos = transform.position;
        ////viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1, screenBounds.y);
        ////transform.position = viewPos;

    }

    IEnumerator leafWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnObject();
        }

    }

    //Spawns leaves in a pattern
    private void PatternSpawn()
    {
        float k = cameraPosition.x + cameraSizeX / 2;
        float spawnPositionX = 0;
        float spawnPositionY = 0;
        for (int i = 0; spawnPositionX < k; i++)
        {
            spawnPositionX = cameraPosition.x - (cameraSizeX / 2) + distanceBetweenLeaves * i;
            spawnPositionY = cameraPosition.y + (cameraSizeY);
            GameObject obj = Instantiate(objPrefab) as GameObject;
            //obj.transform.position = new Vector2(spawnPositionX, screenBounds.y * 2);
            obj.transform.position = new Vector2(spawnPositionX, spawnPositionY);
            //Debug.Log("Spawn Y: " + spawnPositionY);
        }
    }
}
