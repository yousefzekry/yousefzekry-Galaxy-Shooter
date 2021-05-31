using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{
	public Sprite[] lives;

	public Image livesImageDisplay ;

	public int score;

	public Text scoreText;

	public GameObject title;

	void Start()
	{
		//PLayer player = GetComponent<PLayer> ();

		//title.SetActive (false);
	}

	void Update()
	{
		
	}

	public void Updatelives(int cr_lives)
	{
		Debug.Log (cr_lives);
		livesImageDisplay.sprite = lives [cr_lives];
	}

	public void Score()
	{
		score += 10;	

		scoreText.text = "Score:" + score;
	}

	public void Showtitlescreen()
	{
		title.SetActive (true);
	}

	public void Hidetitlescreen()
	{
		title.SetActive (false);

		scoreText.text = "Score:";
	}

}
