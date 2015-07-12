using UnityEngine;
using System.Collections;

public class AllPlayerMovement : MonoBehaviour {

	public bool up,left,right;

	public float speed = 10f; 							
	public Vector2 maxVelocity = new Vector2(3, 5);		
	public bool standing;
	public float jetSpeed = 15f;
	public float airSpeedMultiplier = .3f;
	
	private Animator animator;
	//public PlayerController controller;
	public Vector2 moving  = new Vector2();
	
	void Start (){
		up = false;
		left = false;
		right = false;


		//controller = GetComponent<PlayerController> ();		// get the PlayerController componnent
		animator = GetComponent<Animator> ();				//// get the Animator componnent

		Rigidbody2D r = gameObject.AddComponent<Rigidbody2D> ();
		r.drag = 0.3f;
		r.angularDrag = 0.05f;
		r.mass = 1;
		r.gravityScale = 1;
		r.fixedAngle = true;

		CircleCollider2D c = gameObject.AddComponent<CircleCollider2D>();
		PhysicsMaterial2D material = new PhysicsMaterial2D ();
		//material.bounciness = 0.2f;
		material.friction = 0.4f;
		c.sharedMaterial = material;
		c.radius = 0.3f;
		Vector2 vec = new Vector2 ();
		vec.x = 0f;
		vec.y = -0.09f;
		c.offset = vec;

	}
	
	// Update is called once per frame
	void Update () {
		moving.x = moving.y = 0;

		if (Input.GetKey ("right") || right) 		// set the direction to right
		{
			moving.x = 1;
		}
		else if (Input.GetKey ("left") || left) 	// set the direction to left
		{
			moving.x = -1;	
		}
		
		
		if (Input.GetKey ("up") || up)			// set the direction to up
		{
			moving.y = 1;
		}
		else if (Input.GetKey ("down")) 
		{
			moving.y = -1;	
		}


		var forceX = 0f;
		var forceY = 0f;
		
		var absVelX = Mathf.Abs (GetComponent<Rigidbody2D>().velocity.x);
		var absVelY = Mathf.Abs (GetComponent<Rigidbody2D>().velocity.y);
		
		if (absVelY < .2f)
		{
			standing = true;
		}
		else
		{
			standing = false;
		}
		
		
		
		if (moving.x != 0) {			// if the player is moving
			if (absVelX < maxVelocity.x)	// set the new x axis value
			{
				forceX = standing ? speed * moving.x : (speed * moving.x * airSpeedMultiplier);
				
				transform.localScale = new Vector3 (forceX > 0 ? 1 : -1, 1, 1);
			}

			if(animator != null)			// if animation is avalible
			{
				animator.SetInteger ("AnimState", 1);
			}

		}
		else 
		{
			if(animator != null)
			{
				animator.SetInteger ("AnimState", 0);
			}
		}
		
		
		if (moving.y > 0) {
			if (absVelY < maxVelocity.y) 
			{
				forceY = jetSpeed * moving.y;
			}

			if(animator != null)
			{
				animator.SetInteger ("AnimState", 2);
			}

		}
		else if (absVelY > 0) 
		{
			if(animator != null)
			{
				animator.SetInteger ("AnimState", 3);
			}

		}
		
		if (Input.GetKey ("up")) 	// set the new y axis value
		{
			if(absVelY < maxVelocity.y)
			{
				forceY = jetSpeed;
			}
		}

		//set the new force to player
		GetComponent<Rigidbody2D>().AddForce (new Vector2 (forceX, forceY));
	}


	public void moveUp()			// all the functions below aare for the touch input
	{
		up = true;
	}
	
	public void moveLeft()
	{
		left = true;
	}
	
	public void moveRight()
	{
		right = true;
	}
	
	public void clearUp()
	{
		up = false;
	}
	
	public void clearLeft()
	{
		left = false;
	}
	
	public void clearRight()
	{
		right = false;
	}
}