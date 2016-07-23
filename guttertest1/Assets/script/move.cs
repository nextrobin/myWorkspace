using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class move : MonoBehaviour {
	
	public bool updateOn = true;
	public float speed = 0.1f;
	public Vector3 position,orignal,store;
	RaycastHit2D hit;
	public AudioSource close;



	void Start () {
		
		position = transform.position;
		store = transform.position;
		orignal = transform.position;

		StartCoroutine (updateOff());


		close = gameObject.AddComponent<AudioSource>();

		//close = (AudioClip)gameObject.AddComponent ("AudioSource");
	AudioClip myAudioClip;
		myAudioClip = (AudioClip)Resources.Load ("SFX/closegut");
		close.clip = myAudioClip;
		//close.loop = true;




	}
	
	void Update () {

		if (updateOn == true) {
		
			position.y += speed * Time.deltaTime;
			position.y = Mathf.Clamp (position.y, -2f, 2f);
			transform.position = position;	



		}

		//transform.position = new Vector3 (Random.Range (7.2f, -7.2f), Random.Range (4f, -4f), Random.Range (4f, -4f));

		if (Input.touchCount > 0) {
			
			//if (Input.GetMouseButtonDown(0) && Input.GetTouch(0).phase == TouchPhase.Moved)
			if (Input.GetMouseButtonDown (0)) 
				
			{
				hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
				if (hit.collider != null && hit.transform.gameObject.tag == "gut2") 
					
				{

					transform.position = orignal;
					close.Play();
				}


			}
	
		}


	}


	IEnumerator updateOff ()
	{
		yield return new WaitForSeconds (2.0f);
		updateOn = false;
	
	}

}



//transform.Translate (speed*Time.deltaTime,0,0);
//transform.Translate (new Vector3(speed*Time.deltaTime,0,0));
//Mathf.Clamp(transform.position.x,0,0)
//Mathf.Clamp (0,0,0);
//position.y=Mathf.Clamp (0,0,0);

//Vector3 temp = transform.position;


//Debug.Log (temp.x);

//transform.position = new Vector3 (transform.position.x, Mathf.Clamp(transform.position.y, 0, 0), transform.position.z);
