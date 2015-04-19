using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HelloWorld : MonoBehaviour {

	public GameObject go;
	public Panel p;

	// Use this for initialization
	void Start () {
		
		go = GameObject.FindGameObjectWithTag ("CommunicationMenuCanvas");	//find the objct "CommunicationMenuCanvas"
		p = go.GetComponentInChildren<Panel>();								// get the Panel component of the "CommunicationMenuCanvas" object

		p.setText("In Hello World!!!!");
	}

}
  