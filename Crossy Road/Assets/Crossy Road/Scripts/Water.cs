using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

	bool hitWater = false;


	void OnTriggerStay( Collider other )
	{
		if (hitWater) return;

		if (other.tag == "Player")
		{
			PlayerController playerController = other.GetComponent<PlayerController>();

			if ( !playerController.partentedToObject && !playerController.isJumping)
			{
				Debug.Log("Player fell into the water.");

				hitWater = true;

				playerController.GotSoaked();
			}
		}
	}



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
