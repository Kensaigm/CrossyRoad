using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	public float speed			= 1.0f;
	public float moveDirection	= 0;
	public bool parentOnTrigger = true;
	public bool hitBoxOnTrigger = false;
	public GameObject moverObject = null;

	private Renderer renderer	= null;
	private bool isVisible		= false;

	// Use this for initialization
	void Start () {
		renderer = moverObject.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(speed * Time.deltaTime, 0, 0);
		IsVisible();
	}

	void IsVisible() {
		if (renderer.isVisible)
		{
			isVisible = true;
		}

		if ( !renderer.isVisible && isVisible)
		{
			Debug.Log(" Remove object. No longer seen by camera.");
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter( Collider other) { }
	void OnTriggerExit(Collider other) { }
}
