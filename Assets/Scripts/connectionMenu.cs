using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using System;
using System.Text;
using UnityEngine.EventSystems;
using System.Collections;

public class connectionMenu : MonoBehaviour {

	// Use this for initialization
	public GameObject go;		// pointer to game object
	public Panel p;				// pointer to Panel panel in go
	public string textClass = "";
	private WWW loadFile;		
	
	public List<string> chatHistory = new List<string>();
	void Start () {
	
		go = GameObject.FindGameObjectWithTag ("Panel");	
		p = go.GetComponent<Panel>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator LinkStreamingFolder()		// --- testing ---
	{
		string FinalPath = "file://"+Application.streamingAssetsPath + "/test.cs";
		WWW linkstream = new WWW(FinalPath);
		yield return linkstream;
		p.setText(linkstream.text);
	} 

	public void wwwTest()			// --- testing --- getting test.cs file from android device and print the file content to screen
	{
		loadFile = new WWW("jar:file://" + Application.dataPath + "!/assets/test.cs");
		while (!loadFile.isDone) {
				}


		textClass = loadFile.text;
		p.setText(loadFile.text);

	}




	public void sendClassToOtherSystem()
	{

	}


	public void loadGame()		// load PushBlockStaging scene
	{
		Application.LoadLevel("PushBlockStaging");
	}

	public void showAllScripts()		// --- testing ---
	{

//		string filesList = "";

		//LinkStreamingFolder ();
		//string [] fileEntries = Directory.GetFiles (Application.streamingAssetsPath);

		//string filePath = "jar:file://" + Application.dataPath + "!/assets/" + "";

		/*
		foreach (string fileName in fileEntries) 
		{
			filesList+=fileName + "\n";
		}

		p.setText(filesList);
		*/
	}


	public void showFiles()		// --- testing ---
	{

		//string temp = "jar:file://" + Application.dataPath + "!/assets/test.cs" + "\n\n" + Application.persistentDataPath + "/test.cs";
		
		p.setText (Application.dataPath + "\n" + Application.persistentDataPath + "\n" + Application.streamingAssetsPath + "\n" +Application.temporaryCachePath);
	}


	public void OnSubmit(BaseEventData eventData)	// --- testing ---
	{
		p.setText(eventData.currentInputModule.guiText.text);
	}





}

