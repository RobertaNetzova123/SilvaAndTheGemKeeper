using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawArea : MonoBehaviour
{
    [SerializeField] GameObject objPrefab;
    [SerializeField] float respawnTime = 1.0f;
    [SerializeField] int distanceBetweenLeaves = 1;
    // Start is called before the first frame update

    private float width;
    private float height;
    private Vector3 areaPosition;

    private bool areaVisible = false;

    GameObject playerObject;
    AbilitiesController playerAbilities;

    void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
        areaPosition = this.gameObject.transform.position;
        print("Width " + width + " Height " + height);
        print("X " + areaPosition.x + " Y " + areaPosition.y);
        //StartCoroutine(leafWave());


        // Get player gliding controller
       playerObject = GameObject.Find("Player");
       playerAbilities = playerObject.GetComponent<AbilitiesController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutineFromDistance(15);
        AdjustGlidingAbility();
        
        
    }


    //Starts the leaf spawning coroutine once a specific distance between the camera
    // and the area is reached
    private void StartCoroutineFromDistance(int distance)
    {
        //StartCoroutineWhenVisible();
        if (areaPosition.x - Camera.main.transform.position.x < distance)
        {
            Debug.Log("Visible " + (areaPosition.x - Camera.main.transform.position.x));
            if (!areaVisible)
            {
                StartCoroutine(leafWave());
                areaVisible = true;
               
            }
        }
        else
        {
            Debug.Log("NOT Visible " + (areaPosition.x - Camera.main.transform.position.x));
            playerAbilities.gliding = false;
        }
    }

    //adjust the gliding abilty variable when the area is visible from the camera
    // the variable is used in the GlidingManager script
    private void AdjustGlidingAbility()
    {
        if (!IsVisibleFrom(Camera.main))
        {
            Debug.Log("Not visible");
            playerAbilities.gliding = false;
        }
        else
        {
            playerAbilities.gliding = true;
        }
    }
    bool IsVisibleFrom(Camera cam)
    {
        SpriteRenderer rend = GetComponent<SpriteRenderer>();
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);
        return GeometryUtility.TestPlanesAABB(planes, rend.bounds);
    }

    IEnumerator leafWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            PatternSpawnObject();
        }

    }
    //Spawns leaves in a pattern
    private void PatternSpawnObject()
    {
        float spawnPositionX = areaPosition.x - width/2;
        float spawnPositionY = areaPosition.y + height/2;
        float endOfSpawnAreaX = areaPosition.x + width / 2;
        float endOfSpawnAreaY = areaPosition.y - height;

        //GameObject obj = Instantiate(objPrefab) as GameObject;
        //obj.transform.position = new Vector2(areaPosition.x, areaPosition.y * 2);
        for (int i = 0; spawnPositionX < endOfSpawnAreaX; i++)
        {
           
            
            GameObject obj = Instantiate(objPrefab) as GameObject;
            obj.transform.position = new Vector2(spawnPositionX, spawnPositionY);

            spawnPositionX = spawnPositionX + distanceBetweenLeaves;
        }
        //float k = cameraPosition.x + cameraSizeX / 2;


        //float k = cameraPosition.x + cameraSizeX / 2;
        //float spawnPositionX = 0;
        //float spawnPositionY = 0;
        //for (int i = 0; spawnPositionX < k; i++)
        //{
        //    spawnPositionX = cameraPosition.x - (cameraSizeX / 2) + distanceBetweenLeaves * i;
        //    spawnPositionY = cameraPosition.y + (cameraSizeY);
        //    GameObject obj = Instantiate(objPrefab) as GameObject;
        //    //obj.transform.position = new Vector2(spawnPositionX, screenBounds.y * 2);
        //    obj.transform.position = new Vector2(spawnPositionX, spawnPositionY);
        //    //Debug.Log("Spawn Y: " + spawnPositionY);
        //}
    }
}
