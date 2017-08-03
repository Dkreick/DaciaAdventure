using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour {

	public GameObject path0;
	public GameObject path1;
	public float minSpeed;
	public float maxSpeed;

	public float speed;

	void Start () 
	{
		minSpeed = 5f;
		maxSpeed = 20f;
		speed = 10;
	}
	
	void Update () 
	{
		MovePaths ();
		AcceleratePaths ();
	}

	void MovePaths()
	{
		path0.transform.Translate(Vector3.down * (speed * Time.deltaTime));
		path1.transform.Translate(Vector3.down * (speed * Time.deltaTime));

		if (path0.transform.localPosition.y < -16f) 
		{
			path0.transform.localPosition = new Vector3 (path0.transform.localPosition.x, 4.8f, path0.transform.localPosition.z);
		}
		if (path1.transform.localPosition.y < -16f) 
		{
			path1.transform.localPosition = new Vector3 (path1.transform.localPosition.x, 4.8f, path1.transform.localPosition.z);
		}
	}

	void AcceleratePaths ()
	{
		if (Input.GetKey(KeyCode.W))
		{
			speed += 0.1f;
		}
		if (Input.GetKey(KeyCode.S))
		{
			speed -= 0.1f;
		}

		speed = Mathf.Clamp (speed, minSpeed, maxSpeed);
	}
}