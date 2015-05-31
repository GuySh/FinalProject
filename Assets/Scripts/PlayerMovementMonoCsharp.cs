using UnityEngine;
using System.Collections;
using System;
using Mono.CSharp;
using Microsoft.CSharp;
using System.CodeDom.Compiler;

public class PlayerMovementMonoCsharp : MonoBehaviour {


	/*
	public float speed = 10f; 							
	public Vector2 maxVelocity = new Vector2(3, 5);		
	public bool standing;
	public float jetSpeed = 15f;
	public float airSpeedMultiplier = .3f;
	
	private Animator animator;
	public PlayerController controller;
*/

	String vars = @"
	 float speed = 10f; 							
	 Vector2 maxVelocity = new Vector2(3, 5);		
	 bool standing;
	 float jetSpeed = 15f;
	 float airSpeedMultiplier = .3f;
	
	 Animator animator;
	 PlayerController controller;
     var x = 3; 
	";
	
	void Start ()
	{


		Mono.CSharp.Evaluator.Init(new string[] { });
		
		foreach (System.Reflection.Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
		{
			//Dbg.Log("refer: {0}", assembly.FullName);
			if( assembly.FullName.Contains("Cecil") || assembly.FullName.Contains("UnityEditor") )
				continue;
			Mono.CSharp.Evaluator.ReferenceAssembly(assembly);
		}
		Evaluator.Run ("using UnityEngine;\n" + 
		               "using System;"
		               );

		Evaluator.Run (vars);

		//controller = GetComponent<PlayerController> ();		// get the PlayerController componnent
		//animator = GetComponent<Animator> ();				//// get the Animator componnent

		//Evaluator.Run ("Debug.Log(\"Test\");");


		string start = @"
		controller = GetComponent<PlayerController> ();		// get the PlayerController componnent
		animator = GetComponent<Animator> ();				//// get the Animator componnent
		";


		Evaluator.Run (start);
		Evaluator.Run ("controller.moving.x;");
		
	}
	
	// Update is called once per frame
	void Update () {

		//Evaluator.Run ("Debug.Log (x);");
		//Evaluator.Run ("var absVelX = Mathf.Abs (GetComponent<Rigidbody2D>().velocity.x);");
		//Evaluator.Run ("Debug.Log (absVelX);");
		//Evaluator.Run ("Debug.Log (jetSpeed);");
		string code = @"

		Debug.Log (jetSpeed);		

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



		if (controller.moving.x != 0) {			// if the player is moving
			if (absVelX < maxVelocity.x)
			{
				forceX = standing ? speed * controller.moving.x : (speed * controller.moving.x * airSpeedMultiplier);

				transform.localScale = new Vector3 (forceX > 0 ? 1 : -1, 1, 1);
			}

			" + "animator.SetInteger (\"AnimState\", 1);" + @"
			}
			else 
			{
			" + "animator.SetInteger (\"AnimState\", 0);" + @"
			}


		if (controller.moving.y > 0) {
			if (absVelY < maxVelocity.y) 
			{
				forceY = jetSpeed * controller.moving.y;
			}
			
			" + " animator.SetInteger (\"AnimState\", 2);" +@"
		}
		else if (absVelY > 0) 
		{
		" +	"animator.SetInteger (\"AnimState\", 3);" + @"
		}

		" + "if (Input.GetKey (\"up\"))" +@" 
		{
			if(absVelY < maxVelocity.y)
			{
				forceY = jetSpeed;
			}
		}

		GetComponent<Rigidbody2D>().AddForce (new Vector2 (forceX, forceY));";

		Evaluator.Run (code);



		/*
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
		
		
		
		if (controller.moving.x != 0) {			// if the player is moving
			if (absVelX < maxVelocity.x)
			{
				forceX = standing ? speed * controller.moving.x : (speed * controller.moving.x * airSpeedMultiplier);
				
				transform.localScale = new Vector3 (forceX > 0 ? 1 : -1, 1, 1);
			}
			
			animator.SetInteger ("AnimState", 1);
		}
		else 
		{
			animator.SetInteger ("AnimState", 0);
		}
		
		
		if (controller.moving.y > 0) {
			if (absVelY < maxVelocity.y) 
			{
				forceY = jetSpeed * controller.moving.y;
			}
			
			animator.SetInteger ("AnimState", 2);
		}
		else if (absVelY > 0) 
		{
			animator.SetInteger ("AnimState", 3);
		}
		
		if (Input.GetKey ("up")) 
		{
			if(absVelY < maxVelocity.y)
			{
				forceY = jetSpeed;
			}
		}
		
		GetComponent<Rigidbody2D>().AddForce (new Vector2 (forceX, forceY));
		*/
	}
}
