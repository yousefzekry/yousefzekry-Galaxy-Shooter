using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour 
{
	[SerializeField]
	private float _speed = 10.0f;

	[SerializeField]
	private float _laser_destroy_dist = 10.0f;

    
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//laser move up with speed variable
		transform.Translate(Vector3.up * _speed * Time.deltaTime);

		//removing the laser from the scene when it reaches the end of the screen

		if(transform.position.y > _laser_destroy_dist)
		{
			Destroy (this.gameObject);
		}
			
	}

	// detect the collsion with the enemy and get removed from the scene
	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.tag == "Enemy")
		{
			EnemyAI enemy = other.GetComponent<EnemyAI> ();

			if (enemy != null)
			{
				Destroy (this.gameObject);
			}
		}
	}
}
