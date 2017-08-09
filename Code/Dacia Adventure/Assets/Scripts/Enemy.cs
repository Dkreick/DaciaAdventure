using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public Text carsAvoidedText;
	public int carsAvoided;
	public float speed;
	public float timeToSpawn;
	public float minTimeToSpawn;
	public float maxTimeToSpawn;
	public GameObject[] enemies = new GameObject[5];

	void Start () 
	{
		carsAvoided = 0;
		minTimeToSpawn = 1f;
		maxTimeToSpawn = 3f;
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
			timeToSpawn = Random.Range (minTimeToSpawn, maxTimeToSpawn);
			DecrementTimeSpawn ();
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
				carsAvoided++;
				carsAvoidedText.text = "Cars\navoided: " + carsAvoided;
			}
		}
	}

	void SpawnEnemy()
	{
		int num = Random.Range (0, enemies.Length);
		do 
		{
			enemies[num].SetActive (true);
			Color randomColor = new Color( Random.value, Random.value, Random.value, 1.0f);
			enemies[num].GetComponent<Renderer> ().material.color = randomColor;
			return;
		}	while (enemies[num].activeSelf == false);
	}

	void DecrementTimeSpawn()
	{
		minTimeToSpawn -= 0.1f;
		maxTimeToSpawn -= 0.1f;

		if (minTimeToSpawn < 0.1f) 
		{
			minTimeToSpawn = 0.1f;
		}

		if (minTimeToSpawn < 0.25f) 
		{
			minTimeToSpawn = 0.25f;
		}
	}
}