using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
	public bool gameover = true;

	public GameObject player;

	private UIManager _uimanager;

	void Start()
	{
		_uimanager = GameObject.Find("Canvas").GetComponent <UIManager> ();
	}

	void Update()
	{
		if(gameover == true)
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				Instantiate(player,Vector3.zero ,Quaternion.identity);
				gameover = false;
				_uimanager.Hidetitlescreen ();
			}
		}
	}
}
