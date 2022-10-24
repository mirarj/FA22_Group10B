using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    //Object variables
    public Transform[] children;
    public Vector2[] spawnPoints;
    private bool[] SPAvailable;
    private int numSpawnPoints;
    private bool canSpawn;
    public float spawnGap = 5f;

    IEnumerator DelayPickup()
    {
        yield return new WaitForSeconds(spawnGap);
        canSpawn = true;
    }


    void Start()
    {
        canSpawn = true;
        numSpawnPoints = spawnPoints.Length;
        SPAvailable = new bool[numSpawnPoints];
        children = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            children[i] = transform.GetChild(i);
        }
        RespawnAll();
    }

    void Update()
    {
        if (canSpawn == true)
        {
            RespawnAll();
            canSpawn = false;
            StartCoroutine(DelayPickup());
            StopCoroutine(DelayPickup());
            
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "player") {
            RespawnOne(transform);
        }
    }
    void RespawnAll() {
        for (int i = 0; i < numSpawnPoints; i++) {SPAvailable[i] = true;}
        for (int i = 0; i < children.Length; i++)
        {
            int r = Random.Range(0, numSpawnPoints);
            if (SPAvailable[r]) // readjust for if spawn points > num children
            { // dont spawn in same spot 
                children[i].position = spawnPoints[r];
                SPAvailable[r] = false;
            }
            else
            {
                RespawnOne(children[i]);
            }
        }
    }

    public void RespawnOne(Transform food) {
        int r = Random.Range(0, numSpawnPoints);
        if (SPAvailable[r])
        {
            food.position = spawnPoints[r];
            SPAvailable[r] = false;
        }
        else
        {
            RespawnOne(food);
        }
    }
}