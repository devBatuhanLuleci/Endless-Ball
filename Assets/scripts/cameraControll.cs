using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class cameraControll : MonoBehaviour {
	private Transform maincamera;
	private Vector3 istedigimizYer;
	private Vector3 moveVector;
	private float sure=0.0f;
	private float animasyonunsuresi=2.0f;
	private Vector3 animasyonKamera = new Vector3 (0, 5, 5);
	// Use this for initialization
	void Start () {
		
		maincamera= GameObject.FindGameObjectWithTag ("Player").transform;
		istedigimizYer = transform.position - maincamera.position;
	}
	
	// Update is called once per frame
	void Update () {
		moveVector = maincamera.position+istedigimizYer;
		//x icin	
		moveVector.x=0;

		//y icin
		moveVector.y=Mathf.Clamp(moveVector.y,3,5);

		if (sure > 1.0f) {
			transform.position = moveVector;
		
		}	
		//Animasyonda icin
		else 
		{
			transform.position = Vector3.Lerp (moveVector + animasyonKamera, moveVector, sure);
			sure += Time.deltaTime * 1 / animasyonunsuresi;
			transform.LookAt (maincamera.position + Vector3.up);
         
		}	

	}
}
