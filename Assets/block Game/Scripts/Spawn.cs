using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject fallingPrefabs;
    public Vector2 secondBeteweenSpawnsMinMax;
    float nextSpawnTime;

    public  Vector2 spawnSizeMinMax;
    public float spawnAngleMax;

    Vector2 screenHalfSizeWorldUnits;

    private void Start ( )
    {
        screenHalfSizeWorldUnits=new Vector2 ( Camera. main. aspect*Camera. main. orthographicSize, Camera. main. orthographicSize );
    }

    private void Update ( )
    {
        if ( Time. time>nextSpawnTime )
        {
            float secondsBetweenSpawns=Mathf.Lerp(secondBeteweenSpawnsMinMax.y,secondBeteweenSpawnsMinMax.x,Difficulty.GetDiffcultyPercent());
            nextSpawnTime=Time. time+secondsBetweenSpawns;
          
            float spawnAngle = Random.Range(-spawnAngleMax,spawnAngleMax);
            float spawnSize = Random.Range(spawnSizeMinMax.x,spawnSizeMinMax.y);
            Vector2 spawnPosition = new Vector2 (Random.Range(-screenHalfSizeWorldUnits.x,screenHalfSizeWorldUnits.x),screenHalfSizeWorldUnits.y+spawnSize);
           GameObject newblock=(GameObject)  Instantiate ( fallingPrefabs, spawnPosition, Quaternion.Euler(Vector3.forward*spawnAngle) );

            newblock. transform. localScale=Vector2. one*spawnSize;
        }
    }
}
