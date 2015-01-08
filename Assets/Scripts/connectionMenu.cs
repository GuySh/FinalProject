using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using UnityEngine.UI;

public class connectionMenu : MonoBehaviour {

	// Use this for initialization
	public GameObject go;
	public Panel p;
	public string myIp = "waiting for ip";

	void Start () {
	
		go = GameObject.FindGameObjectWithTag ("Panel");
		p = go.GetComponent<Panel>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setMyIp()
	{
		IPHostEntry host;
		string localIP = "?";
		host = Dns.GetHostEntry(Dns.GetHostName());
		foreach (IPAddress ip in host.AddressList)
		{
			if (ip.AddressFamily == AddressFamily.InterNetwork)
			{
				localIP = ip.ToString();
			}
		}

		myIp = localIP;
		p.setText(myIp);
	}



	public void loadGame()
	{
		Application.LoadLevel("PushBlockStaging");
	}
}
