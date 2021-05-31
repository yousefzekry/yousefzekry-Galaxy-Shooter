﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

	private Animator _anim;

	// Use this for initialization
	void Start () 
	{
		_anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			_anim.SetBool ("Turn_Right", false);
			_anim.SetBool ("Turn_Left", true);
		}
		else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
		{
			_anim.SetBool ("Turn_Right", false);
			_anim.SetBool ("Turn_Left", false);
		}


		if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
		{
			_anim.SetBool ("Turn_Right", true);
			_anim.SetBool ("Turn_Left", false);
		}else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
		{
			_anim.SetBool ("Turn_Right", false);
			_anim.SetBool ("Turn_Left", false);
		}


	}
}
