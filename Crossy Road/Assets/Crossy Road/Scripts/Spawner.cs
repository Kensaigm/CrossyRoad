using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public Transform startPos = null;

	//spawn time based
	public float delayMin = 1.5f;
	public float delayMax = 5.0f;
	public float speedMin = 1.0f;
	public float speedMax = 4.0f;

	//spwan at start
	public bool useSpawnPlacement = false;
	public int spawnCountMin = 4;
	public int spawnCountMax = 20;

	private float lastTime = 0.0f;
	private float delayTime = 0.0f;
	private float speed = 0.0f;

	[HideInInspector]
	public GameObject item = null;
	[HideInInspector]
	public bool goLeft = false;
	[HideInInspector]
	public float spawnLeftPos = 0;
	[HideInInspector]
	public float spawnRightPos = 0;


	Vector3 GetSpawnPosition()
	{
		if (useSpawnPlacement)
		{

		} else
		{

		}

		return Vector3.zero;
	}

	void SpawnItem()
	{
		// GameObject Instantiate Placement, Posision, Direction
		GameObject obj = Instantiate(item) as GameObject;

		obj.transform.position = GetSpawnPosition();

	}

	// Use this for initialization
	void Start () {
		// Loop through GameObject
	}
	
	// Update is called once per frame
	void Update () {
		// Loop
	}
}
