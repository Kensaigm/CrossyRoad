using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	public int coinValue = 1;
	public GameObject coin = null;
	public AudioClip audioClip = null;

	
	void OnTriggerEnter( Collider other)
	{
		if (other.tag == "Player")
		{
			Debug.Log("Player picked up a coin!");

			Manager.instance.UpdateCoinCount(coinValue);

			// Add delay to play sound then destroy object.
			coin.SetActive(false);
			GetComponent<AudioSource>().PlayOneShot(audioClip);


			Destroy(gameObject, audioClip.length);
		}
				
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
