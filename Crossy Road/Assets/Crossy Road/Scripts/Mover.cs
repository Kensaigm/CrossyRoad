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

	void OnTriggerEnter( Collider other) {
		if (other.tag == "Player")
		{
			Debug.Log("mover trigger enter player.");

			if (parentOnTrigger) {
				Debug.Log("Enter: Parent to me");

				other.transform.parent = transform;
			}
			if (hitBoxOnTrigger) {
				Debug.Log("Enter: Gothit. Game over.");

				other.GetComponent<PlayerController>().GotHit();
			}
		}
	}
	void OnTriggerExit(Collider other) {
		if (other.tag == "Player")
		{
			Debug.Log("mover trigger exit player.");

			if (parentOnTrigger) {
				Debug.Log(" Exit. ");
				other.transform.parent = null;
			}
			if (hitBoxOnTrigger) {
				Debug.Log(" Exit. But dead, this should not happen.");
				// TODO:  Make sure animation state is Dead only.
			}
		}
	}
}
