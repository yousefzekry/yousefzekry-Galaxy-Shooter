using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour 
{

	public GameObject enemy;

	public GameObject[] powerups;

	public float E_x_position;

	public Vector3 pos;

	public bool playeralive = true;

	public GameObject player;

	[SerializeField]
	private float y_poundry = 5.94f;

	private GameManager _gamemanager;

	void Start () 
	{
		_gamemanager = GameObject.Find ("GameManager").GetComponent<GameManager> ();

		StartCoroutine (SpawningEnemies ());
		StartCoroutine (SpawningPowerups ());
	}



	public void spawning()
	{
		
			StartCoroutine (SpawningEnemies ());
			StartCoroutine (SpawningPowerups ());
		
	}
		
	IEnumerator SpawningEnemies ()
	{
		//if(_gamemanager.gameover==false)
		//{
		while (_gamemanager.gameover==false)
			{
				// spwn eneimes at random x-axis pos. every 5 sec

				E_x_position = Random.Range (-8.0f, 8.0f);

				pos = new Vector3 (E_x_position, y_poundry, 0);

				Instantiate (enemy, pos, Quaternion.identity);

				yield return new WaitForSeconds (5.0f);
			}
		//}

	}

	IEnumerator SpawningPowerups()
	{
		//if(_gamemanager.gameover==false)
		//{
		while(_gamemanager.gameover==false)
			{
				int randomPowerup = Random.Range (0, 3);

				Instantiate(powerups[randomPowerup] , new Vector3(Random.Range(-8.0f,8.0f),4,0) ,Quaternion.identity);

				yield return new WaitForSeconds (5.0f);
			}

		//}
	
	}

}
