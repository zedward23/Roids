using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public GameObject objToSpawn;
    public float timer;
    public float spawnPeriod;
    public int numberSpawnedEachPeriod;
    public Vector3 originInScreenCoords;
    public int score;

    // Use this for initialization 
    void Start()
    {
        score = 0;
        timer = 0;
        spawnPeriod = 5.0f;
        numberSpawnedEachPeriod = 3;
        originInScreenCoords = Camera.main.WorldToScreenPoint(new Vector3(0, 0, 0));
    }

    void Update()
    {
        timer += Time.deltaTime;
        float width = Screen.width;
        float height = Screen.height;
        if (timer > spawnPeriod)
        {
            timer = 0;
            
            for (int i = 0; i < numberSpawnedEachPeriod; i++)
            {
                float horizontalPos = Random.Range(0.0f, width);
                float verticalPos = Random.Range(0.0f, height);
                Instantiate(objToSpawn,
                Camera.main.ScreenToWorldPoint(
                new Vector3(horizontalPos,
                verticalPos, originInScreenCoords.z)),
                Quaternion.identity);
            }
        }
    }
}
