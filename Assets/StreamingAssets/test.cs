using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {


	public GameObject go;
	public Panel p;

	// Use this for initialization
	void Start () {
	
		go = GameObject.FindGameObjectWithTag ("Panel");
		p = go.GetComponent<Panel>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void writeGuy()
	{
		p.setText("Guy");
	}
}
