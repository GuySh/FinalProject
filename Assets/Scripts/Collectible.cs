﻿using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D target)			
	{
		if (target.gameObject.tag == "Player")	// destroy the collictible if the player touched it
		{
			GameLogic.items++;
			Destroy(gameObject);		
		}
	}
}
