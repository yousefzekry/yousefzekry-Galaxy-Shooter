using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		// check if the shieldup == true
		// if true, desable the damage on the player
		// make a courotuine to desable the sheild and re-enable the player damage

		//SpawnShield ();
	}

	/*public void SpawnShield()
	{
		PLayer p = GetComponent <PLayer> ();

		if (p.Shieldup == true)
		{
			Instantiate (p.Shield, p.transform.position, Quaternion.identity);
		}
	}*/
}
