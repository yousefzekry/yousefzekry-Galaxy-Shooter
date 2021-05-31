using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour {

	[SerializeField]
	private float _powerup_move_speed = 1;

	[SerializeField]
	private int _power_ID; //0 ==> triple , 1 ==> speed , 2 ==> sheild

	public float Y_boundry = -4;

	[SerializeField]
	private AudioClip _clip;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate (Vector3.down * Time.deltaTime * _powerup_move_speed);

		if(transform.position.y <= Y_boundry)
		{
			Destroy (this.gameObject);
		}

	}


	void OnTriggerEnter2D (Collider2D other)
	{

		// check the tag of the player
		if(other.tag == "Player")
		{
			// create a handler to access the player script on trigger
			PLayer p = other.GetComponent<PLayer> ();

			if(p != null) // check if the player exists 
			{
				if(_power_ID == 0)
				{
					p.tripleshoot_ON ();
				}
				else if (_power_ID == 1)
				{
					
					p.speedup_ON ();				
				}
				else if (_power_ID == 2)
				{
					p.Shieldup_ON ();
				}

				
		
			}

			AudioSource.PlayClipAtPoint (_clip, Camera.main.transform.position, 1f);

			Destroy (this.gameObject);
		}

	}
}
