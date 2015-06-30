using UnityEngine;
using System.Collections;

public class PlayerFlight : MonoBehaviour {


	public float speed = 10f; 							
	public Vector2 maxVelocity = new Vector2(3, 5);		
	//public bool standing;
	public float jetSpeed = 50f;
	//public float airSpeedMultiplier = .3f;



	// Use this for initialization
	void Start ()
	{



	
	}
	
	// Update is called once per frame
	void Update () {
		//var forceX = 0f;
		var forceY = 0f;
		
		//var absVelX = Mathf.Abs (GetComponent<Rigidbody2D>().velocity.x);
		var absVelY = Mathf.Abs (GetComponent<Rigidbody2D>().velocity.y);


		if (Input.GetKey ("up")) 
		{
			if(absVelY < maxVelocity.y)
			{
				forceY = jetSpeed;
			}
		}


		GetComponent<Rigidbody2D>().AddForce (new Vector2 (0, forceY));
	}
}
