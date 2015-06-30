using UnityEngine;
using System.Collections;


// TESTING FOR ANDROID
public class MoveCapsule   : MonoBehaviour {



	// Update is called once per frame
	void Update () 	
	{
		if (Input.GetKey (KeyCode.UpArrow))		// move the capsule up
		{
			transform.position += Vector3.up * Time.deltaTime * 5;
		}

		if (Input.GetKey (KeyCode.DownArrow))	// move the capsule down
		{
			transform.position -= Vector3.up * Time.deltaTime * 5;
		}
	}
}
