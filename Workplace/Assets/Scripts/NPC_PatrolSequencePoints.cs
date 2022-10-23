using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class NPC_PatrolSequencePoints : MonoBehaviour {
       public float speed = 10f;
       private float waitTime;
       public float startWaitTime = 2f;

       public Transform[] moveSpots;
       public int startSpot = 0;
       public bool moveForward = true; 

       // Turning
       private int nextSpot;
       private int previousSpot;
       public bool faceRight = true;

       void Start(){
              waitTime = startWaitTime;
              nextSpot = startSpot; 
       }

       void FixedUpdate(){
              transform.position = Vector2.MoveTowards(transform.position, moveSpots[nextSpot].position, speed * Time.deltaTime);

              if (Vector2.Distance(transform.position, moveSpots[nextSpot].position) < 0.2f){
                     print(moveSpots[nextSpot].position);
                     previousSpot = nextSpot;
                     if(nextSpot == (moveSpots.Length -1))
                            { previousSpot = nextSpot; nextSpot=0; }
                     else { nextSpot += 1;
                            }

              }
       }     

}
