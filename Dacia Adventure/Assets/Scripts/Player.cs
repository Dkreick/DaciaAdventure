using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float speed;
    public float travelDistance;
    public Text travelDistanceText;
    public static bool isPlaying;

    void Start()
    {
        isPlaying = true;
        travelDistance = 0;
        speed = 5;
    }

    void Update()
    {
        if (isPlaying)
        {
            MovePlayer();
            ClampPlayer();
            UpdateTravelDistance();    
        }
    }

    void MovePlayer()
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

    void ClampPlayer()
    {
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(transform.position.x, -2.4f, 2.4f);
        clampedPosition.y = Mathf.Clamp(transform.position.y, -4f, 0f);
        transform.position = clampedPosition;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            Debug.Log("CHOCO!");
            isPlaying = false;
        }
    }

    void UpdateTravelDistance()
    {
        travelDistance += speed * 0.1f; 
        travelDistanceText.text = "Distance\ntraveled: " + (int)travelDistance + "Mts";
    }
}
