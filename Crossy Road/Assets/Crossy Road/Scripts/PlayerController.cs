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
		if (isIdle)
		{
			if (Input.GetKeyDown(KeyCode.UpArrow)     || 
				Input.GetKeyDown(KeyCode.DownArrow)   ||
				Input.GetKeyDown(KeyCode.LeftArrow)   ||
				Input.GetKeyDown(KeyCode.RightArrow) 
				)
			{
				CheckIfCanMove();
			}
		}
	}

	void CheckIfCanMove()
	{
		// raycast  - find if there is a collider box in front of player
		RaycastHit hit;

		Physics.Raycast(transform.position, -chick.transform.up, out hit, colliderDistCheck);

		Debug.DrawRay(transform.position, -chick.transform.up * colliderDistCheck, Color.red, 2.0f);

		if (hit.collider == null)
		{
			SetMove();
		} else
		{
			if (hit.collider.tag == "collider")
			{
				Debug.Log("Hit something with collider tag.");
			} else
			{
				SetMove();
			}
		}
	}

	void SetMove()
	{
		Debug.Log("Hit nothing.  Keep moving.");
		isIdle		= false;
		isMoving	= true;
		jumpStart	= true;
	}

	void CanMove()
	{
		if (isMoving)
		{
			if (Input.GetKeyUp(KeyCode.UpArrow))
			{
				Moving(new Vector3(transform.position.x, transform.position.y, transform.position.z + moveDistance));
				SetMoveForwardState(); 
			}
			else if (Input.GetKeyUp(KeyCode.DownArrow))
			{
				Moving(new Vector3(transform.position.x, transform.position.y, transform.position.z - moveDistance));
				// SetMoveForwardState();
			}
			else if (Input.GetKeyUp(KeyCode.LeftArrow))
			{
				Moving(new Vector3(transform.position.x - moveDistance, transform.position.y, transform.position.z));
				// SetMoveForwardState();
			}
			else if (Input.GetKeyUp(KeyCode.RightArrow))
			{
				Moving(new Vector3(transform.position.x + moveDistance, transform.position.y, transform.position.z));
				// SetMoveForwardState();
			}
		}

	}

	void Moving( Vector3 pos)
	{
		isIdle = false;
		isMoving = false;
		isJumping = true;
		jumpStart = false;
		LeanTween.move(gameObject, pos, moveTime).setOnComplete( MoveComplete );
	}

	void MoveComplete()
	{
		isJumping = false;
		isIdle = true;
	}

	void SetMoveForwardState()
	{

	}

	public void GotHit()
	{
		isDead = true;

		ParticleSystem.EmissionModule em = particle.emission;
		em.enabled = true;

		// Manager -> GameOver()
	}

	void IsVisable()
	{
		if (renderer.isVisible)
		{
			isVisable = true;
		}

		if ( !renderer.isVisible && isVisable)
		{
			Debug.Log("Player off screen. Apply GotHit()");

			GotHit();
		}
	//	if (GetComponent<Renderer>().isVisible)
	//	{
	//		isVisable = true;
	//	}
	//	if(!GetComponent<Renderer>().isVisible && isVisable)
	//	{
	//		Debug.Log("Player off screen. Apply Gothit()");
	//		GotHit();
	//	}
	}
	// Use this for initialization
	void Start () {
		renderer = chick.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		//TODO:  Manager -> CanPlay()
		if (isDead) return;
		CanMove();
		CanIdle();
		IsVisable();
	}
}
