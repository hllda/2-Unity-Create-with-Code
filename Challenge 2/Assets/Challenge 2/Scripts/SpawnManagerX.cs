using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float interval;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        while (true)
        {
            interval = Random.Range(3, 5);
            Invoke("SpawnRandomBall", interval);
        }
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {       
        // Generate random ball index and random spawn position
        int randomBall = Random.Range(0, ballPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[randomBall], spawnPos, ballPrefabs[randomBall].transform.rotation);
    }
}
