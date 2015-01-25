using UnityEngine;
using System.Collections;

public class NetworkMenu : MonoBehaviour {		// --- for testing --- 

	public string connectionIp = "127.0.0.1";
	public int portNumber = 8632;
	private bool connected = false;




	private void OnconnectedToServer()
	{
		connected = true; 
	}

	private void OnServerInitialized()
	{
		connected = true; 
	}

	private void OnDisconnectedFromServer()
	{
		connected = false;
	}

	private void OnGUI()
	{

		if (!connected)
		{
			connectionIp = GUILayout.TextField (connectionIp);
			int.TryParse(GUILayout.TextField (portNumber.ToString()), out portNumber);

			if (GUILayout.Button ("connect")) 
			{
					Network.Connect (connectionIp, portNumber);
			}

			if (GUILayout.Button ("Host")) 
			{
					Network.InitializeServer (4, portNumber, true);
			}
		} 
		else 
		{
			GUILayout.Label ("Connctions: " + Network.connections.Length.ToString ());
		}
	}
}
