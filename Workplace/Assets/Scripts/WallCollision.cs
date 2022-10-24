using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    public SpriteRenderer sr;
    public Sprite defaultSprite;
    public Sprite collisionSprite;
    
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = defaultSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
	{
        
        if (other.gameObject.tag == "wall"){
            sr.sprite = collisionSprite;
            StartCoroutine(Bump());
            StopCoroutine(Bump());
			
			// gameObject.GetComponent<AudioSource>().Play();

			// GameObject boomFX = Instantiate(hitVFX, other.gameObject.transform.position, Quaternion.identity);
            // StartCoroutine(DestroyVFX(boomFX));
			
			// Destroy(other.gameObject);
			// gameHandlerObj.AddScore(1);
        }
        else if (other.gameObject.tag == "enemy"){
            sr.sprite = collisionSprite;
            sr.color = new Color(1,0.9f,0.9f,0.75f);
            StartCoroutine(BigBump());
            StopCoroutine(BigBump());
        }
    }

    void ChangeSprite()
    {
    }

    IEnumerator Bump()
    {
        yield return new WaitForSeconds(0.3f);
        sr.sprite = defaultSprite;
    }

    IEnumerator BigBump(){
        yield return new WaitForSeconds(1f);
        sr.sprite = defaultSprite;
        sr.color = new Color(1,1,1,1);
        }



}
