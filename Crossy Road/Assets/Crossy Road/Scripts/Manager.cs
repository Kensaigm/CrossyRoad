﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Manager : MonoBehaviour {

	// Testing
	public int levelCount = 50;

	public Text coin = null;
	public Text distance = null;
	public Camera camera = null;
	public GameObject guiGameOver = null;
	public LevelGenerator levelGenerator = null;

	private int currentCoins = 0;
	private int currentDistance = 0;
	private bool canPlay = false;

	private static Manager s_Instance;
	public static Manager instance
	{
		get
		{
			if (s_Instance == null)
			{
				s_Instance = FindObjectOfType(typeof(Manager)) as Manager;
			}

			return s_Instance;
		}
	}

	public void UpdateCoinCount (int value)
	{
		Debug.Log("Player picked up another coin for " + value);

		currentCoins += value;

		coin.text = currentCoins.ToString();
	}

	public void UpdateDistanceCount()
	{
		Debug.Log("Player moved forward one point.");

		currentDistance += 1;

		distance.text = currentDistance.ToString();

		// TODO:  generate new level piece here
		levelGenerator.RandomGenerator();
	}

	public bool CanPlay()
	{
		return canPlay;
	}

	public void StartPlay()
	{
		canPlay = true;
	}

	public void GameOver()
	{
		camera.GetComponent<CameraShake>().Shake();
		camera.GetComponent<CameraFollow>().enabled = false;

		GuiGameOver();
	}

	void GuiGameOver()
	{
		Debug.Log("Game over!");

		guiGameOver.SetActive(true);
	}

	public void PlayAgain()
	{
		Scene scene = SceneManager.GetActiveScene();

		SceneManager.LoadScene(scene.name);
	}

	public void Quit()
	{
		Application.Quit();
	}

	// Use this for initialization
	void Start () {
		for (int i = 0; i < levelCount; i++)
		{
			levelGenerator.RandomGenerator();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
