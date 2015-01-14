using UnityEngine;
using System.Collections;

public class MoveCapsule   : MonoBehaviour {



	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.UpArrow))
		{
			transform.position += Vector3.up * Time.deltaTime * 5;
		}

		if (Input.GetKey (KeyCode.DownArrow))
		{
			transform.position -= Vector3.up * Time.deltaTime * 5;
		}
	}
}
