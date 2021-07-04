using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public Vector2 LastCheckpointPos;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CompleteLevel()
    {
        Debug.Log("LEVEL WON");
        LastCheckpointPos = new Vector2(-4, 1);
        Debug.Log("Checkpoint Set");
    }
}
