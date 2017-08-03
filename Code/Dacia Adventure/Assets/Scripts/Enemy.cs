using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speed;
	public float timeToSpawn;
	public float minTimeToSpawn;
	public float maxTimeToSpawn;
	public GameObject[] enemies = new GameObject[5];

	void Start () 
	{
		minTimeToSpawn = 0.5f;
		maxTimeToSpawn = 2f;
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
			Debug.Log ("SPAWNEO ALGO!");
		}
	}

	void SpawnEnemy()
	{
		for (int i = 0; i < enemies.Length; i++) 
		{
			if (enemies[i].activeSelf == false) 
			{
				enemies[i].SetActive (true);
				return;
			}
		}
	}

	void Move()
	{
		for (int i = 0; i < enemies.Length; i++) 
		{
			if (enemies[i].activeSelf == true) 
			{
				enemies[i].transform.Translate(Vector3.up * (speed * Time.deltaTime));
			}

			if (enemies[i].transform.position.y < -6) 
			{
				enemies[i].transform.position = new Vector3 (Random.Range (-1.7f, 1.7f), 8f, enemies[i].transform.localPosition.z);
				enemies[i].SetActive (false);
			}
		}
	}
}