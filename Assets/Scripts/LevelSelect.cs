using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void restart()
	{
		Application.LoadLevel (Application.loadedLevelName);
	}

	public void StartLevel1()
	{
		Application.LoadLevel ("PushBlockStaging");
	}

}
