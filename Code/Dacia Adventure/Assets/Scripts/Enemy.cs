using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speed;
	public float timeToSpawn;
	public float minTimeToSpawn;
	public float maxTimeToSpawn;

	void Start () 
	{
		minTimeToSpawn = 1;
		maxTimeToSpawn = 5;
		timeToSpawn = Random.Range (minTimeToSpawn, maxTimeToSpawn);
		speed = 10;
		transform.position = new Vector3 (Random.Range (-1.7f, 1.7f), transform.position.y, transform.position.z);
	}
	
	void Update ()	
	{
		Move ();

		timeToSpawn -= Time.deltaTime;

		if (timeToSpawn < 0) 
		{
			SpawnEnemy ();
			timeToSpawn = Random.Range (minTimeToSpawn, maxTimeToSpawn);;
			Debug.Log (timeToSpawn);
		}
	}

	void SpawnEnemy()
	{
		Debug.Log ("APARECIO UN ENEMIGO");
	}

	void Move()
	{
		transform.Translate(Vector3.up * (speed * Time.deltaTime));

		if (transform.position.y < -6) 
		{
			
		}
	}
}
