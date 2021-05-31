using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer : MonoBehaviour 
{
	[SerializeField]
	public GameObject player;

	[SerializeField]
	private float _speedmultiplayer = 3.0f;

	public Vector3 p_currentPositon;

	[SerializeField]
	private GameObject _laser;

	[SerializeField]
	private Vector3 _laser_postion = new Vector3(0 , 1.06f , 0);

	[SerializeField]
	private float _p_y_poundry =-3.75f;

	[SerializeField]
	private float _p_x_poundry =11;

	[SerializeField]
	private float _firerate = 0.25f;

	private float _nextfire = 0.0f;

	public bool canTripleshot = false;

	public GameObject tripleshoot;

	public Vector3 _triplehot_position = new Vector3(0 , 0 , 0);

	public bool canSpeedup = false;

	public float speedadd = 1.5f;

	public int healthPoints = 3;

	public GameObject Player_Explosion;

	public int P_healthLost = 1;

	public bool Shieldup = false;

	public GameObject shield;

	private UIManager _uimanager;

	private GameManager _gamemanager;

	private SpawnManager _spawnmanager;

	private AudioSource _audioSource;

	public GameObject[] Engines;



	public int hitCount = 0;

	//public bool playerAlive = true;


	// Use this for initialization
	void Start () 
	{
		_uimanager = GameObject.Find ("Canvas").GetComponent<UIManager> ();

		if(_uimanager != null)
		{
			_uimanager.Updatelives (healthPoints);
		}

		_gamemanager = GameObject.Find ("GameManager").GetComponent<GameManager> ();

		_spawnmanager = GameObject.Find ("SpawnManager").GetComponent<SpawnManager> ();

		if(_spawnmanager != null)
		{
			_spawnmanager.spawning ();
		}

		_audioSource = GetComponent<AudioSource> ();

		hitCount = 0;

	

	}

	// Update is called once per frame
	void Update () 
	{
		movement ();

		shooting ();

		//preview the player current coordinates
		p_currentPositon = transform.position;
	}

	public void movement()
	{
		
		if(canSpeedup == true)
		{
			// move forward with w key
			if(Input.GetKey(KeyCode.W))
			{
				transform.Translate (new Vector3(0,1,0) * Time.deltaTime *  _speedmultiplayer * speedadd );
			}
			// move backward with s key
			else if (Input.GetKey(KeyCode.S))
			{
				transform.Translate (new Vector3(0,1,0) * Time.deltaTime *  -_speedmultiplayer * speedadd );
			}
			// move left with d key
			else if (Input.GetKey(KeyCode.D))
			{
				transform.Translate (new Vector3(1,0,0) * Time.deltaTime *  _speedmultiplayer * speedadd );
			}
			// move right with a key
			else if (Input.GetKey(KeyCode.A))
			{
				transform.Translate (new Vector3(1,0,0) * Time.deltaTime *  -_speedmultiplayer * speedadd ) ;
			}
		}
		else
		{
			// move forward with w key
			if(Input.GetKey(KeyCode.W))
			{
				transform.Translate (new Vector3(0,1,0) * Time.deltaTime *  _speedmultiplayer);
			}
			// move backward with s key
			else if (Input.GetKey(KeyCode.S))
			{
				transform.Translate (new Vector3(0,1,0) * Time.deltaTime *  -_speedmultiplayer);
			}
			// move left with d key
			else if (Input.GetKey(KeyCode.D))
			{
				transform.Translate (new Vector3(1,0,0) * Time.deltaTime *  _speedmultiplayer);
			}
			// move right with a key
			else if (Input.GetKey(KeyCode.A))
			{
				transform.Translate (new Vector3(1,0,0) * Time.deltaTime *  -_speedmultiplayer);
			}
		}

		// another simpler method
		/*float horizontalinput = Input.GetAxis ("Horizontal");
		transform.Translate (Vector3.right * speedmultiplayer * horizontalinput * Time.deltaTime);
		float verticalinput = Input.GetAxis ("Vertical");
		transform.Translate (Vector3.up * speedmultiplayer * verticalinput * Time.deltaTime);*/


		// player movement poundries on the y-axis
		if(transform.position.y >= 0)
		{
			transform.position = (new Vector3 (transform.position.x, 0, 0));
		}
		else if (transform.position.y <= _p_y_poundry)
		{
			transform.position = (new Vector3 (transform.position.x, _p_y_poundry , 0));
		}

		// player movement poundries on the x-axis
		if(transform.position.x <= -_p_x_poundry)
		{
			transform.position = (new Vector3 (_p_x_poundry , transform.position.y , 0));
		}
		else if (transform.position.x >= _p_x_poundry)
		{
			transform.position = (new Vector3 (-_p_x_poundry, transform.position.y , 0));
		}

	}

	public void shooting()
	{
	 // pressing space key or the left mouse click to spawn laser prefab	

	// cool down fire time

		if(canTripleshot == true)
		{
			if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
			{
				if(Time.time > _nextfire)
				{
					_audioSource.Play ();

					Instantiate(tripleshoot, transform.position + _triplehot_position , Quaternion.identity);

					// add the current game time to the fire rate to creat the new nextfiring time
					_nextfire = Time.time + _firerate;
				}

			}
		}
		else if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
		{
			// fire rate
			// player can fire if the rate amount is passed
			// using time.time 

			// check if the current time greater thatn the next firing time
			if(Time.time > _nextfire)
			{
				_audioSource.Play ();
				Instantiate(_laser, transform.position + _laser_postion , Quaternion.identity);

				// add the current game time to the fire rate to creat the new nextfiring time
				_nextfire = Time.time + _firerate;
			}

		}
	}

	//call the coroutine
	public void tripleshoot_ON()
	{
		canTripleshot = true;
		StartCoroutine (tripleshotPowerdown ());
	}

	public IEnumerator tripleshotPowerdown()
	{
		// start the coundown
		yield return new WaitForSeconds (20.0f);

		canTripleshot = false;
	}

	public void speedup_ON()
	{
		canSpeedup = true;

		StartCoroutine (speedupPowerDown());
	}

	public IEnumerator speedupPowerDown()
	{
		yield return new WaitForSeconds (10.0f);

		canSpeedup = false;
	}

	public void playerHealthDamage()
	{
			hitCount++;
		//int randomEngine = Random.Range [0,2];
		if(hitCount == 1)
		{
			
			//Engines[randomEngine].SetActive (true);
			Engines[0].SetActive (true);

		}
		else if (hitCount == 2)
		{
			//Engines[randomEngine].SetActive (true);
			Engines[1].SetActive (true);
		}

			healthPoints = healthPoints - P_healthLost;

			_uimanager.Updatelives (healthPoints);

			if(healthPoints == 0)
			{
			//playerAlive = false;
			Destroy (this.gameObject);
			Instantiate(Player_Explosion, transform.position , Quaternion.identity);
			_gamemanager.gameover = true;
			
			_uimanager.Showtitlescreen ();
			}

	}

	public void check_Shield()
	{
		if(Shieldup == true)
		{
			Shieldup_ON ();
		}
		else if (Shieldup == false)
		{
			playerHealthDamage ();
		}

	}

	public void Shieldup_ON()
	{
		Shieldup = true;

		//Instantiate(shield , transform.position , Quaternion.identity);

		shield.SetActive (true);

	

		StartCoroutine (shieldpowerupDown());
	}
		
	public IEnumerator shieldpowerupDown()
	{
		yield return new WaitForSeconds (10.0f);

		//Destroy (GameObject.FindWithTag ("Shield"));

		shield.SetActive (false);

		Shieldup = false;
	}
}
