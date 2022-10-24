using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class NPC_PatrolSequencePoints : MonoBehaviour {
       public float speed = 10f;

       public Transform[] moveSpots;
       public int startSpot = 0;

       private int nextSpot;

       void Start(){
              transform.position = moveSpots[startSpot].position;
              nextSpot = startSpot+1;
       }

       void FixedUpdate(){
              transform.position = Vector2.MoveTowards(transform.position, moveSpots[nextSpot].position, speed * Time.deltaTime);

              if (Vector2.Distance(transform.position, moveSpots[nextSpot].position) < 0.2f){
                     if(nextSpot == (moveSpots.Length -1)) {nextSpot=0;}
                     else {nextSpot += 1;}

              }
       }     

}
