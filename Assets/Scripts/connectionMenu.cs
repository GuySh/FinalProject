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
	public GameObject go;
	public Panel p;
	public string textClass = "";
	private WWW loadDB;
	
	public List<string> chatHistory = new List<string>();
	void Start () {
	
		go = GameObject.FindGameObjectWithTag ("Panel");
		p = go.GetComponent<Panel>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator LinkStreamingFolder()
	{
		string FinalPath = "file://"+Application.streamingAssetsPath + "/test.cs";
		WWW linkstream = new WWW(FinalPath);
		yield return linkstream;
		p.setText(linkstream.text);
	} 

	public void wwwTest()
	{
		loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/test.cs");
		//WWW loadDB = new WWW(Application.persistentDataPath + "/test.cs");
		while (!loadDB.isDone) {
				}


		textClass = loadDB.text;
		p.setText(loadDB.text);

	}




	public void sendClassToOtherSystem()
	{

	}


	public void loadGame()
	{
		Application.LoadLevel("PushBlockStaging");
	}

	public void showAllScripts()
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


	public void showFiles()
	{

		//string temp = "jar:file://" + Application.dataPath + "!/assets/test.cs" + "\n\n" + Application.persistentDataPath + "/test.cs";
		
		p.setText (Application.dataPath + "\n" + Application.persistentDataPath + "\n" + Application.streamingAssetsPath + "\n" +Application.temporaryCachePath);
	}


	public void OnSubmit(BaseEventData eventData)
	{
		p.setText(eventData.currentInputModule.guiText.text);
	}





}

