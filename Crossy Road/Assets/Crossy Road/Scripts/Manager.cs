using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Manager : MonoBehaviour {

	public Text coin = null;
	public Text distance = null;
	public Camera camera = null;
	public GameObject guiGameOver = null;

	private int currentCoins = 0;
	private int currecntDistance = 0;
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


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
