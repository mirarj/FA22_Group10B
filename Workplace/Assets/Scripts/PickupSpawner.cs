using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    //Object variables
    public Vector2[] spawnPoints;
    private int numSpawnPoints;
    private bool canSpawn;
    private float spawnGap = 10f;
    public int value = 5;

    IEnumerator DelayPickup()
    {
        yield return new WaitForSeconds(spawnGap);
        canSpawn = true;
    }


    void Start()
    {
        canSpawn = true;
        numSpawnPoints = spawnPoints.Length;
    }

    void Update()
    {
        if (canSpawn == true)
        {
            int i = Random.Range(0, numSpawnPoints);
            transform.position = spawnPoints[i];
            canSpawn = false;
            StartCoroutine(DelayPickup());
            StopCoroutine(DelayPickup());

        }
    }
}