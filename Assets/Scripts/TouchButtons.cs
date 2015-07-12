using UnityEngine;
using System.Collections;

public class TouchButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {

		if (Application.platform == RuntimePlatform.Android)
		{
			Debug.Log ("Android");
		}
		else
		{
			Debug.Log ("Not Android");
		}
	}
	
	// Update is called once per frame
	void Update () {
	

	}
}
