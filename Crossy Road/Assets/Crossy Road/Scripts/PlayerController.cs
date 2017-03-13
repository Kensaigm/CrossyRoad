using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float	moveDistance = 1;
	public float	moveTime = 0.4f;
	public float	colliderDistCheck = 1;
	public bool		isIdle = true;
	public bool		isDead = false;
	public bool		isMoving = false;
	public bool		isJumping = false;
	public bool		jumpStart = false;
	public ParticleSystem particle = null;
	public GameObject	  chick = null;

	private Renderer	  renderer = null;
	private bool		  isVisable = false;


	void CanIdle()
	{

	}

	void CheckIfCanMove()
	{

	}

	void SetMove()
	{

	}

	void CanMove()
	{
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			Moving(new Vector3( transform.position.x, transform.position.y, transform.position.z + moveDistance));
		}
	}

	void Moving( Vector3 pos)
	{
		LeanTween.move(this.gameObject, pos, moveTime);
	}

	void MoveComplete()
	{

	}

	void SetMoveForwardState()
	{

	}

	public void GotHit()
	{

	}

	void IsVisable()
	{
		if (GetComponent().isVisible)
		{
			isVisable = true;
		}
		if(!GetComponent().isVisible && isVisable)
		{
			Debug.Log("Player off screen. Apply Gothit()");
			GotHit();
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CanMove();
	}
}
