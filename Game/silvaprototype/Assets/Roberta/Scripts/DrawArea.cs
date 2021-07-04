using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawArea : MonoBehaviour
{
    [SerializeField] GameObject objPrefab;
    [SerializeField] float respawnTime = 1.0f;
    [SerializeField] int distanceBetweenLeaves = 1;
    [SerializeField] int distnceToStartSpawning = 30;
    // Start is called before the first frame update

    private float width;
    private float height;
    private Vector3 areaPosition;

    private bool areaVisible = false;

    GameObject playerObject;
    AbilitiesController playerAbilities;

    float areaStart;
    private GameMaster gm;

    void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
        areaPosition = this.gameObject.transform.position;
        areaStart = areaPosition.x - width / 2;
        print("Width " + width + " Height " + height + "areaStart " +areaStart);
        //print("X " + areaPosition.x + " Y " + areaPosition.y);
        //StartCoroutine(leafWave());

        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        // Get player gliding controller
        playerObject = GameObject.Find("Player");
        playerAbilities = playerObject.GetComponent<AbilitiesController>();

        
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutineFromDistance(distnceToStartSpawning);
        AdjustGlidingAbility();
       
    }


    //Starts the leaf spawning coroutine once a specific distance between the camera
    // and the area is reached
    private void StartCoroutineFromDistance(int distance)
    {
        //StartCoroutineWhenVisible();
        //print("!!!!!!! " + (areaPosition.x - gm.LastCheckpointPos.x));
        if (areaStart - gm.LastCheckpointPos.x < distance && areaPosition.x - gm.LastCheckpointPos.x > 0)
            //if (Mathf.Abs(areaPosition.x - Camera.main.transform.position.x) < distance)
        {
            //Debug.Log("Visible " + Mathf.Abs(areaPosition.x - Camera.main.transform.position.x));
            if (!areaVisible)
            {
                print("START_____");
                areaVisible = true;
                StartCoroutine(leafWave());
                
               
            }
        }
        else
        {
            //Debug.Log("NOT Visible " + Mathf.Abs(areaPosition.x - Camera.main.transform.position.x));
            playerAbilities.gliding = false;
            areaVisible = false;
            StopCoroutine(leafWave());
        }
    }
    //private void StopCoroutineWhenNotVisible()
    //{
    //    print("In stp function");
    //    if (!areaVisible)
    //    {

    //        StopCoroutine(leafWave());
    //    }
    //}
    //adjust the gliding abilty variable when the area is visible from the camera
    // the variable is used in the GlidingManager script

    private void AdjustGlidingAbility()
    {
        if (!IsVisibleFrom(Camera.main))
        {
            Debug.Log(" NO");
            playerAbilities.gliding = false;
        }
        else
        {
            Debug.Log(" YES");
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
        while (areaVisible)
        {
            yield return new WaitForSeconds(respawnTime);
            PatternSpawnObject();
            //RandomSpawn();
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


    private void RandomSpawn ()
    {
        //radom spawn
        float spawnPositionX = areaPosition.x - width / 2;
        float spawnPositionY = areaPosition.y + height / 2;
        float endOfSpawnAreaX = areaPosition.x + width / 2;
        float endOfSpawnAreaY = areaPosition.y - height;

        for (int i = 0; i < 5; i++)
        {

            // add the object to the scene
            GameObject obj = Instantiate(objPrefab) as GameObject;
            //place on the screen random at x and outside of y
            //obj.transform.position = new Vector2(Random.Range (screenBounds.x, -screenBounds.x), screenBounds.y * 2);
            obj.transform.position = new Vector2(Random.Range(spawnPositionX, endOfSpawnAreaX), spawnPositionY);

            //Vector3 viewPos = transform.position;
            //viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1, screenBounds.y);
            //transform.position = viewPos;

        }
    }
}
