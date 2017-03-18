using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	public int coinValue = 1;
	
	void OnTriggerEnter( Collider other)
	{
		if (other.tag == "Player")
		{
			Debug.Log("Player picked up a coin!");

			// TODO: Manager -> upade coin count

			Destroy(gameObject);
		}
				
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
