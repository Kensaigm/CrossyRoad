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
			int x = (int) Random.Range(spawnLeftPos, spawnRightPos);

			Vector3 pos = new Vector3(x, startPos.position.y, startPos.position.z);

			return pos;
		} else
		{
			return startPos.position;
		}
	}

	void SpawnItem()
	{
		// GameObject Instantiate Placement, Posision, Direction
		Debug.Log("Spawn Item " + item.name.ToString());
		GameObject obj = Instantiate(item) as GameObject;

		obj.transform.position = GetSpawnPosition();

		float direction = 0.0f;
		if (goLeft)
		{
			direction = 180f;
		}

		if (!useSpawnPlacement)
		{
			obj.GetComponent<Mover>().speed = speed;
			obj.transform.rotation = obj.transform.rotation * Quaternion.Euler(0, direction, 0);
		}

		
	}

	// Use this for initialization
	void Start () {
		// Setup GameObject by type
		if (useSpawnPlacement)
		{
			int spawnCount = Random.Range(spawnCountMin, spawnCountMax);

			for (int i = 0; i < spawnCount; i++)
			{
				SpawnItem();
			}

		} else
		{
			speed = Random.Range(speedMin, speedMax);
		}
	}
	
	// Update is called once per frame
	void Update () {
		// Loop by type
		if (useSpawnPlacement) return;

		if (Time.time > lastTime + delayTime)
		{
			lastTime = Time.time;

			delayTime = Random.Range(delayMin, delayMax);

			SpawnItem();
		}
	}
}
