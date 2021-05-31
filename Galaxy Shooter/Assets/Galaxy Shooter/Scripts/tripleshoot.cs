using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tripleshoot : MonoBehaviour 
{
	[SerializeField]
	private float _speed = 10.0f;

	[SerializeField]
	private float _shot_destroy_dist = 10.0f;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(Vector3.up * _speed * Time.deltaTime);

		if(transform.position.y > _shot_destroy_dist)
		{
			Destroy (this.gameObject);
		}
	}
}
