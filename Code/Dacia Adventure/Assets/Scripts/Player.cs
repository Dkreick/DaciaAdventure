﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public float speed;
	public float travelDistance;
	public Text travelDistanceText;

	void Start () 
	{
		travelDistance = 0;
		speed = 5;
		Color randomColor = new Color( Random.value, Random.value, Random.value, 1.0f);
		gameObject.GetComponent<Renderer> ().material.color = randomColor;
	}
		
	void Update () 
	{
		MovePlayer();
		ClampPlayer();
		UpdateTravelDistance ();
	}

	void MovePlayer () 
	{
		if (Input.GetKey(KeyCode.A)) 
		{
			transform.Translate(Vector3.left * (speed * Time.deltaTime));
		}
		if (Input.GetKey(KeyCode.D))
		{
			transform.Translate(Vector3.right * (speed * Time.deltaTime));
		}
		if (Input.GetKey(KeyCode.W))
		{
			transform.Translate(Vector3.up * (speed * Time.deltaTime));
		}
		if (Input.GetKey(KeyCode.S))
		{
			transform.Translate(Vector3.down * (speed * 2 * Time.deltaTime));
		}
	}

	void ClampPlayer ()
	{
		Vector3 clampedPosition = transform.position;
		clampedPosition.x = Mathf.Clamp(transform.position.x, -2.4f, 2.4f);
		clampedPosition.y = Mathf.Clamp(transform.position.y, -4f, 2.5f);
		transform.position = clampedPosition;
	}

	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.gameObject.tag == "Enemy") 
		{
			Debug.Log ("CHOCO!");
		}
	}

	void UpdateTravelDistance()
	{
		travelDistance += speed * 0.1f; 
		travelDistanceText.text = "Distance traveled: " + travelDistance + "Mts";
	}
}
