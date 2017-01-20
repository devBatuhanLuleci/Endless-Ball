using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {
	private Vector3	moveVector;
	private CharacterController controller;
	private float speed = 9.0f;
	private float duseyHiz = 0.0f;	
	private float yercekimi=11.0f;
	private float animasyonunsuresi=2.0f;		  
	private bool isDead=false;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();	
	}

	// Update is called once per frame
	void Update () {	
		//ölmüsse diger tuslara basamasın.
	
	if (isDead)
			return;


		if (Time.time < animasyonunsuresi) {
			controller.Move (Vector3.forward * speed * Time.deltaTime);	
			return;
			//cok anlayamadım uygulamalı göster return;
		}


		moveVector = Vector3.zero;

		if (controller.isGrounded)
		{
			duseyHiz = -0.5f;

		} else 
		{
          
			duseyHiz -= yercekimi * Time.deltaTime;




		}	
		//for x
		moveVector.x=Input.GetAxisRaw("Horizontal")*speed/1.5f;	


		//for y
		moveVector.y=duseyHiz;

		//for z 
		moveVector.z=speed;//daima ileri götürmek icin bu fonsiyonu kullanıyoruz.
		controller.Move (moveVector*Time.deltaTime);
	
	


	
	}
	//altın toplama
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Coin")
			Destroy (other.gameObject);
	}
	//ölme
	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (hit.point.z > transform.position.z + controller.radius){
			Death ();
		}



	}

	void Death()
	{ 
		Debug.Log ("dead");
		isDead = true;
	}







}
	