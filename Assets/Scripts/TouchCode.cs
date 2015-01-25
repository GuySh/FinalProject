using UnityEngine;
using System.Collections;

public class TouchCode : MonoBehaviour {  // --- for testing! ---


	public Vector2 moving = new Vector2();
	public string direction = "";
	
	//public GameObject playerObj;

	//public PlayerController player;
	// Use this for initialization
	void Start () {
		//player = GetComponent<PlayerController> ();

	}
	// Update is called once per frame
	void Update ()
	{
		moving.x = moving.y = 0;

		int fingerCount = 0;
		foreach (Touch touch in Input.touches) {
			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
				fingerCount++;


			if(direction == "up")
			{
				//player.moving.y = 1;
				moving.y = 1;
				print ("xxxxxxxxxxxxxxxxxxxxxxxxxxxx" + " " + moving.y);
				//player.setUp();
			}
			
		}
		if (fingerCount > 0)
			print("User has " + fingerCount + " finger(s) touching the screen");
		
	
	}


	void OnTriggerEnter2D(Collider2D target)
	{
		print ("WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWwwwwwwwoooooooooooooooooooooooooooooo");
	}

}
