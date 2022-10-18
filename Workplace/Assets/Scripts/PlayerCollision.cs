using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public int currSP;
    // Start is called before the first frame update
    void Start()
    {
        currSP = -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        GetComponentInParent<PickupSpawner>().RespawnOne(transform);

    }
}
