using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

	//speed variable
	//move from the y-axis down
	//if at bottom of the screen reposotion at the top with random postion on x-axis with bounds of the screen

	public float speed = 3.0f;

	public int explosionlifetime = 5;

	[SerializeField]
	private float _E_y_poundry =-5.94f;

	[SerializeField]
	private float _y_poundry = 5.94f;

	private float _E_x_postion;

	[SerializeField]
	private AudioClip _clip;

	Vector3 pos;

	// health variables
	public float healthPoints = 100.0f;

	// public float P_healthLost = 25.0f;

	public float E_healthLost = 100.0f;

	public GameObject Enemy_Explosion;

	private UIManager _uimanager;


	// Use this for initialization
	void Start () 
	{
		_uimanager = GameObject.Find ("Canvas").GetComponent<UIManager> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		Movement ();
	}

	void Movement ()
	{

		// check the positon of the enemy on y-axis
		if(transform.position.y <= _E_y_poundry)
		{
			//create a random range between the x-axis boundries of the scene
			_E_x_postion = Random.Range (8.0f , -8.0f);

			// creating the new postion on  x and y axis
			pos = new Vector3 (_E_x_postion , _y_poundry , 0);

			// make the enemy move to the new random postion form the top of the scene
			transform.position = pos;
		}

		transform.Translate (Vector3.down * Time.deltaTime * speed );
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		// detect the collsion between the eenmy and the player , the enemy and the laser 
		// if the player collided with the enemy the player loses 25 point of it`s health and the enemy loses it health
		// if the laser collided with the enemy the enemy loses it`s health

		PLayer p = other.GetComponent<PLayer> ();

		if(other.tag == "Player")
		{
			if(p != null)
			{
				//p.healthPoints = p.healthPoints - P_healthLost;

				p.check_Shield ();

				healthPoints = healthPoints - E_healthLost;
			}
		}
		else if(other.tag == "Laser")
		{
			healthPoints = healthPoints - E_healthLost;
		}

		if (healthPoints == 0)
		{
			Destroy (this.gameObject);

			_uimanager.Score ();

			//spawn the explosion clip at the maincamera position

			AudioSource.PlayClipAtPoint (_clip, Camera.main.transform.position, 1f);

			// view the Enemy_Explosion Prefab
			 GameObject explosion = Instantiate(Enemy_Explosion, transform.position , Quaternion.identity) as GameObject ;

			// destroy the explosion after 5 sec.
			Destroy (explosion.gameObject, 5);


		}
	}
}
