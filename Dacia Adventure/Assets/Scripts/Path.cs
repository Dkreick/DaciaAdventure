using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Path : MonoBehaviour {

	public GameObject path0;
	public GameObject path1;
	public Text speedText;
	public float minSpeed;
	public float maxSpeed;
	public float speed;
	public float pathPositionReset = 4.6f;

	void Start () 
	{
		minSpeed = 5f;
		maxSpeed = 20f;
		speed = 10;
	}
	
	void Update () 
	{
		speedText.text = "Speed: " + (speed * 5).ToString("####") + "Km/h";
		MovePaths ();
		AcceleratePaths ();
	}

	void MovePaths()
	{
		path0.transform.Translate(Vector3.down * (speed * Time.deltaTime));
		path1.transform.Translate(Vector3.down * (speed * Time.deltaTime));

		if (path0.transform.localPosition.y < -16f) 
		{
			path0.transform.localPosition = new Vector3 (path0.transform.localPosition.x, pathPositionReset, path0.transform.localPosition.z);
		}
		if (path1.transform.localPosition.y < -16f) 
		{
			path1.transform.localPosition = new Vector3 (path1.transform.localPosition.x, pathPositionReset, path1.transform.localPosition.z);
		}
	}

	void AcceleratePaths ()
	{
		if (Input.GetKey(KeyCode.W))
		{
			speed += 1.5f * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.S))
		{
			speed -= 3f * Time.deltaTime;
		}

		speed = Mathf.Clamp (speed, minSpeed, maxSpeed);
	}
}