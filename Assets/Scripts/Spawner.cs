using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //Array of spawns
    public Transform[] spawnPoints;

    //Array of enemy (hazards)
    public GameObject[] hazards;

    //time rate of spawn
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;

    //difficulty management
    public float minTimeBetweenSpanws;
    public float decrease;

    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if(player!= null)
        {
            if(timeBtwSpawns<=0)
            {
                //spawn hazard
                Transform randomSpawnPoints = spawnPoints[Random.Range(0, spawnPoints.Length)];
                GameObject randomHazard = hazards[Random.Range(0, hazards.Length)];
                //spawn random hazards at random spawn points
                Instantiate(randomHazard, randomSpawnPoints.position, Quaternion.identity);
                if (startTimeBtwSpawns > minTimeBetweenSpanws)
                {
                    startTimeBtwSpawns -= decrease;
                }
                //time between spawns
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
    }
}
