using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Panel : MonoBehaviour {		// to be composed on panel

	public Text text;
	// Use this for initialization
	void Start () {
		text = gameObject.GetComponentInChildren<Text>();
	}

	public void setText(string t)		// set the panel text
	{
		text.text = t;
	}



}
