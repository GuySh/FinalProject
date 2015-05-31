using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.IO;
using Mono.CSharp;

public class CommunicationMenu : MonoBehaviour {


	public GameObject go;
	public Panel p;

//	StreamReader fileReader = null;

	public string connectionIp = "127.0.0.1";   //initial ip	
	public int portNumber = 8632;				//initial ip
	private bool connected = false;				// connected flag
	public InputField portIn, ipIn;				// port and ip from the to set from the input fields
	public string ip = " ";


	private WWW loadFile;	
	public string rpcString;


	// Use this for initialization
	void Start () {

		go = GameObject.FindGameObjectWithTag ("CommunicationMenuCanvas");	//find the objct "CommunicationMenuCanvas"
		p = go.GetComponentInChildren<Panel>();								// get the Panel component of the "CommunicationMenuCanvas" object

		go = GameObject.FindGameObjectWithTag ("PortInputField");			//find the objct "PortInputField"
		portIn = go.GetComponentInChildren<InputField>();					// get the InputField component of the "PortInputField" object

		go = GameObject.FindGameObjectWithTag ("IpInputField");				//find the objct "IpInputField"
		ipIn = go.GetComponentInChildren<InputField>();						// get the InputFields component of the "CommunicationMenuCanvas" object


		monoStart ();		///////////////////

		rpcString = "Rpc string is empty";
	}
	
	// Update is called once per frame
	void Update () {
	
			//p.setText (ip + "\n Connctions: " + Network.connections.Length.ToString ());

	}


	private void OnconnectedToServer()	// check if connected to server
	{
		connected = true; 
	}
	
	private void OnServerInitialized()	// when starting server set the connected flag
	{
		connected = true; 
	}
	
	private void OnDisconnectedFromServer()	// check if disonnected 
	{
		connected = false;
	}





	public void showMyIp()
	{
		ip = Network.player.ipAddress;		// get the ip of the device and print to screen
		p.setText(ip);
	}

	public void connect()		// connect to server
	{
		if (connected)
		{
			return;		
		}

		Int32.TryParse(portIn.text, out portNumber);	// get the port from input field
		connectionIp = ipIn.text;						// get the ip from input field

		p.setText (connectionIp + " " + portNumber);
		Network.Connect (connectionIp, portNumber);
		//p.setText ("Connctions: " + Network.connections.Length.ToString ());
	}

	public void host()		// be the server
	{
		if (connected)
		{
			return;		
		}

		Int32.TryParse(portIn.text, out portNumber);	//get the port from the input field

		Network.InitializeServer (1, portNumber, true);	// start the server

		p.setText (Network.TestConnection ().ToString ());
	}

	public void printNumOfConnections()		// print the number of connections
	{
		p.setText ("Connections: " + Network.connections.Length.ToString ());
	}


	public void rpcSendButton()
	{
		if (connected) 
		{
			GetComponent<NetworkView>().RPC ("sendString", RPCMode.Others, new object[]{rpcString});
		}
	}



	[RPC]
	public void sendString(string str)		// sed the string to client
	{
		rpcString = str;
	}

	public void printRpcString()
	{
		p.setText (rpcString);
	}


	public void wwwGetfileContent()			// --- testing --- getting test.cs file from android device and print the file content to screen
	{
		loadFile = new WWW("jar:file://" + Application.dataPath + "!/assets/HelloWorld.cs");
		while (!loadFile.isDone) {
		}
		

		rpcString = loadFile.text;
		p.setText(loadFile.text);
		
	}


	public void makeTestFile()			// --- testing --- 
	{
		StreamWriter fileWriter = null;
		string fileName = Application.persistentDataPath + "/" + "HelloWorldTest.cs";
		fileWriter = File.CreateText(fileName);
		fileWriter.WriteLine("Hello world");
		fileWriter.Close();

		p.setText (Application.persistentDataPath);
		//p.setText("created HelloWorldTTest file");
		
	}


	public void addHelloWorldComponent()
	{
		p.setText ("In addHelloWorldComponent");
		//loadFile = new WWW("jar:file://" + Application.dataPath + "!/assets/test.cs");
		//p.setText (loadFile.url);
		if (File.Exists (Application.persistentDataPath + "/" + "HelloWorldTest.cs"))
		{
			p.setText ("File exist");
		}
		else
		{
			p.setText ("Not exist");
			loadFile = new WWW("jar:file://" + Application.dataPath + "!/assets/HelloWorld.cs");
			while (!loadFile.isDone) {
			}

			StreamWriter fileWriter = null;
			string fileName = Application.persistentDataPath + "/" + "HelloWorldTest.cs";
			fileWriter = File.CreateText(fileName);
			fileWriter.WriteLine(loadFile.text);
			fileWriter.Close();


			//File.Copy (loadFile.url, Application.persistentDataPath + "/" + "HelloWorldTest.cs");
		}
		//go.AddComponent<HelloWorld>();
	}


	public void copyPng()
	{
		p.setText ("In copyJpg");
		//loadFile = new WWW("jar:file://" + Application.dataPath + "!/assets/test.cs");
		//p.setText (loadFile.url);
		if (File.Exists (Application.persistentDataPath + "/" + "PositiveCopy.png"))
		{
			p.setText ("File exist");
		}
		else
		{
			p.setText ("Not exist");
			loadFile = new WWW("jar:file://" + Application.dataPath + "!/assets/scaledPositive.png");
			while (!loadFile.isDone) {
			}

			Stream fileWriter = null;
			//StreamWriter fileWriter = null;
			string fileName = Application.persistentDataPath + "/" + "PositiveCopy.png";
			fileWriter = File.Create(fileName);
			for(int i=0; i < loadFile.bytes.Length; i++)
			{
				fileWriter.WriteByte(loadFile.bytes[i]);
			}
			//fileWriter.WriteByte(loadFile.bytes);
			fileWriter.Close();
			
			
			//File.Copy (loadFile.url, Application.persistentDataPath + "/" + "HelloWorldTest.cs");
		}
		//go.AddComponent<HelloWorld>();
	}




	public void TryMonoEval()
	{
		object resualt = Mono.CSharp.Evaluator.Evaluate("1+1;");
		Mono.CSharp.Evaluator.Run("p.setText (resualt.ToString());");

		//Debug.Log (resualt.ToString());
	}

	public void monoStart()
	{
		/*
		int cnt = 0;
		while (cnt < 2) {
			// this needs to be run twice, as the references fail the first time through
			foreach (System.Reflection.Assembly assembly in AppDomain.CurrentDomain.GetAssemblies()) {
				if (assembly == null) {
					Debug.Log ("Null Assembly");
					continue;
				}
				Debug.Log (assembly);
				try {
					Mono.CSharp.Evaluator.ReferenceAssembly (assembly);
				} catch (NullReferenceException e) {
					Debug.Log ("Bad Assembly");
				}
			}
			Mono.CSharp.Evaluator.Evaluate ("1+2;");
			cnt++;
		}
		Mono.CSharp.Evaluator.Run("using UnityEngine;");
		Debug.Log (Mono.CSharp.Evaluator.GetUsing ());
		*/
	}

	/*
	public static CommunicationMenu instance;
	void Awake ()
	{
		instance = this;
	}
*/

	public void addJsTest()
	{
	//	UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent(gameObject, "Assets/Scripts/CommunicationMenu.cs (271,3)", "JavaScriptTest");

		//UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent (gameObject, "Assets/Scripts/CommunicationMenu.cs (268,3)", "JavaScriptTest");
	}
	
	
	
}
