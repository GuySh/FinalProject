using UnityEngine;
using System.Collections;

public class LevelSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void restart()		// load the current scene  
	{
		Application.LoadLevel (Application.loadedLevelName);
	}

	public void StartLevel1()		// load the PushBlockStaging scene  
	{
		Application.LoadLevel ("PushBlockStaging");
	}

}
