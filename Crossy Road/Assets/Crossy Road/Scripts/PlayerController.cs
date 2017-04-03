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

	public AudioClip audioIdle1		= null;
	public AudioClip audioIdle2		= null;
	public AudioClip audioHop		= null;
	public AudioClip audioHit		= null;
	public AudioClip audioSplash	= null;

	public ParticleSystem splash	= null;
	public bool partentedToObject	= false;

	private Renderer	  renderer = null;
	private bool		  isVisable = false;


	void CanIdle()
	{
		if (isIdle)
		{
			if (Input.GetKeyDown(KeyCode.UpArrow)    ) { CheckIfIdle(270, 0, 0)  ; }
			if (Input.GetKeyDown(KeyCode.DownArrow)  ) { CheckIfIdle(270, 180, 0); }
			if (Input.GetKeyDown(KeyCode.LeftArrow)  ) { CheckIfIdle(270, -90, 0) ; }
			if (Input.GetKeyDown(KeyCode.RightArrow) ) { CheckIfIdle(270, 90, 0) ; }		
		}		
	}

	void CheckIfIdle(float x, float y, float z)
	{
		chick.transform.rotation = Quaternion.Euler(x, y, z);

		CheckIfCanMove();
		int a = Random.Range(0, 12);
		if (a < 4 ) PlayAudioClip(audioIdle1);
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
				isIdle = true;
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

		PlayAudioClip(audioHop);
		LeanTween.move(gameObject, pos, moveTime).setOnComplete( MoveComplete );
	}

	void MoveComplete()
	{
		isJumping = false;
		isIdle = true;

		int a = Random.Range(0, 12);
		if (a < 4) PlayAudioClip(audioIdle2);
	}

	void SetMoveForwardState()
	{
		Manager.instance.UpdateDistanceCount();
	}

	public void GotHit()
	{
		// isIdle = false;
		isDead = true;

		ParticleSystem.EmissionModule em = particle.emission;
		em.enabled = true;

		PlayAudioClip(audioHit);

		Manager.instance.GameOver();
	}

	public void GotSoaked()
	{
		// isIdle = false;
		isDead = true;

		ParticleSystem.EmissionModule em = splash.emission;
		em.enabled = true;

		PlayAudioClip(audioSplash);

		chick.SetActive(false);

		Manager.instance.GameOver();
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
	}
	// Use this for initialization
	void Start () {
		renderer = chick.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!Manager.instance.CanPlay()) return;
		if (isDead) return;
		CanMove();
		CanIdle();
		IsVisable();
	}

	void PlayAudioClip(AudioClip clip )
	{
		GetComponent<AudioSource>().PlayOneShot(clip);
	}
}
