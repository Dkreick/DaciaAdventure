using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed;

	void Start () 
	{
		speed = 10;
	}
		
	void Update () 
	{
		MovePlayer();
		ClampPlayer();
	}

	void MovePlayer () 
	{
		if (Input.GetKey(KeyCode.A)) 
		{
			transform.Translate(Vector3.left * (speed * Time.deltaTime));
		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.Translate(Vector3.right * (speed *Time.deltaTime));
		}
	}

	void ClampPlayer ()
	{
		Vector3 clampedPosition = transform.position;
		clampedPosition.x = Mathf.Clamp(transform.position.x, -2.6f, 2.6f);
		transform.position = clampedPosition;
	}
}
