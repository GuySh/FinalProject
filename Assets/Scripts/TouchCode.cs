using UnityEngine;
using System.Collections;

public class TouchCode : MonoBehaviour {


	public Vector2 moving = new Vector2();
	public string direction = "";

	Player player;
	public GameObject respawnPrefab;
	public GameObject respawn;

	// Use this for initialization
	void Start () {
		//player = GameObject.FindGameObjectWithTag ("Player");

	}
	// Update is called once per frame
	void Update ()
	{
		//player.moving.y = 0;
		//player.GetComponentInChildren (PlayerController);
		moving.x = moving.y = 0;
		//player.moving.x = player.moving.y = 0;

		int fingerCount = 0;
		foreach (Touch touch in Input.touches) {
			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
				fingerCount++;
			if(direction == "up")
			{
				player.moving.y = 1;
				moving.y = 1;
				//player.setUp();
			}
			
		}
		if (fingerCount > 0)
			print("User has " + fingerCount + " finger(s) touching the screen");
		
	
	}
}
