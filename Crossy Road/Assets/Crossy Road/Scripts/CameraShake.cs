using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

	public float jumpIter = 4.5f;


	public void Shake()
	{
		float height = Mathf.PerlinNoise(jumpIter, 0.0f) * 5;
		height = height * height * 0.2f;

		float shakeAmt = height; // * 0.01f; // degress to shake the camera
		float shakePeriodTime = 0.25f;  // period of each shake
		float dropOffTime = 1.25f; // how long it takes the shaking to settle down to nothing


		LTDescr shakeTween = LeanTween.rotateAroundLocal(gameObject, Vector3.right, shakeAmt, shakePeriodTime).setEase(LeanTweenType.easeShake).setLoopClamp().setRepeat(-1);

		LeanTween.value(gameObject, shakeAmt, 0, dropOffTime).setOnUpdate((float val) => { shakeTween.setTo(Vector3.right * val); }).setEase(LeanTweenType.easeOutQuad);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// if (Input.GetKeyDown( "c"))
		// {
		//	Shake();
		// }
	}
}
