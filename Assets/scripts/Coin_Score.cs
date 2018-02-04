using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin_Score : MonoBehaviour {
	public Text countscore;
	private int count;
	// Use this for initialization
	void Start () {
		count = 0;

		SetCountTex ();
		SetCountText ();
	}
	
	// Update is called once per frame

		void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.tag == "Coin")
		{
				Destroy (other.gameObject);
		count++;
			SetCountText ();
		}	
	}
	void SetCountText()
	{
		countscore.text = "Score:" + count.ToString ();

	}

}
