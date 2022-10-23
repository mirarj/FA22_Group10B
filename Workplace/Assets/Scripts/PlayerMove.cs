using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMove : MonoBehaviour
{
    
	public Rigidbody2D rb;
    public float moveSpeed = 5000f;
	public GameHandler gameHandlerObj;
	// public GameObject hitVFX;
    private Vector2 moveVec;
    public GameObject recipeItem1;

	  
	// Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();

		if (GameObject.FindWithTag("GameController") != null){
               gameHandlerObj = GameObject.FindWithTag("GameController").GetComponent<GameHandler>();
        }
		// if (GameObject.FindWithTag("GameController") != null){
        //        gameHandlerObj = GameObject.FindWithTag("GameController").GetComponent<GameHandler>();
        //   }
        if (GameObject.FindWithTag("GameHandler") != null){ 
               gameHandlerObj = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
          }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
	
    void OnMove(InputValue moveVal)
	{
		moveVec = moveVal.Get<Vector2>();
	}

	void FixedUpdate()
	{
        // moveVec.x = Input.GetAxisRaw ("Horizontal");
        // moveVec.y = Input.GetAxisRaw ("Vertical");
        rb.AddForce(moveVec * moveSpeed * Time.fixedDeltaTime);
        float angle = 90 + Mathf.Atan2(moveVec.y, moveVec.x)*180/Mathf.PI;
        if(moveVec!=new Vector2(0,0)){
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0,0,angle), 10);
        }
    }
	
	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.gameObject.tag == "food"){
            if (other.name==gameHandlerObj.getItemName(1))
            {
            print(gameHandlerObj.getItemName(1));
                gameHandlerObj.ListItemRefresh(1);
                gameHandlerObj.AddScore(5);
                // big vfx
            }
            else if (other.name==gameHandlerObj.getItemName(2))
            {
            print(gameHandlerObj.getItemName(2));
                gameHandlerObj.ListItemRefresh(2);
                gameHandlerObj.AddScore(5);
                // big vfx
            }
            else if (other.name==gameHandlerObj.getItemName(3))
            {
            print(gameHandlerObj.getItemName(3));
                gameHandlerObj.ListItemRefresh(3);
                gameHandlerObj.AddScore(5);
                // big vfx
            }
            else {
                gameHandlerObj.AddScore(1);
                //small vfx
            }
			// gameObject.GetComponent<AudioSource>().Play();

			// GameObject boomFX = Instantiate(hitVFX, other.gameObject.transform.position, Quaternion.identity);
            // StartCoroutine(DestroyVFX(boomFX));
			
        }
    }
	
	
	// IEnumerator DestroyVFX(GameObject theEffect){
    //       yield return new WaitForSeconds(0.5f);
    //       Destroy(theEffect);
	// 	  gameObject.GetComponent<AudioSource>().Stop();

    //  }
}
