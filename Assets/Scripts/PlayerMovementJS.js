#pragma strict


/*	
	<<TESTING TESTING>>
	
	This class is for android devices only
	this class is for running code with the EVAL function
*/


	var speed = 10f; 							
	var maxVelocity = Vector2(3, 5);		
	var standing;
	var jetSpeed = 15f;
	var airSpeedMultiplier = .3f;

	var animator : Animator;
	var controller : PlayerControllerJS;
	var rigidbody2d : Rigidbody2D;
	var x = {};
	
	var forceX = 0f;
	var forceY = 0f;
	var absVelX;
	var absVelY;


function Start () {

//eval("x['one']=5;");
//eval("Debug.Log(x['one']);");
//eval("Debug.Log(x + '!!!!!!');");


//eval("x['controller'] : PlayerControllerJS;");


//x['controller'] = GetComponent(PlayerControllerJS);		// get the PlayerController componnent

	controller = GetComponent(PlayerControllerJS);
	animator = GetComponent(Animator);				//// get the Animator componnent
	rigidbody2d = GetComponent(Rigidbody2D);
}

function Update () {


	eval("forceX = 0f;");
	eval("forceY = 0f;");
	eval("absVelX = Mathf.Abs (rigidbody2d.velocity.x);");
	eval("absVelY = Mathf.Abs (rigidbody2d.velocity.y);");

	eval("standing = absVelY < .2f ? true : false;");
//	if (absVelY < .2f)
//	{
//		standing = true;
//	}
//	else
	//{
//		standing = false;
//	}


	eval("if (controller.moving.x != 0){if (absVelX < maxVelocity.x){forceX = standing ? speed * controller.moving.x : (speed * controller.moving.x * airSpeedMultiplier);transform.localScale = new Vector3 (forceX > 0 ? 1 : -1, 1, 1);}animator.SetInteger ('AnimState', 1);}else {animator.SetInteger ('AnimState', 0);}");
/*
	if (controller.moving.x != 0)
	{			// if the player is moving
		if (absVelX < maxVelocity.x)
		{
			eval("forceX = standing ? speed * controller.moving.x : (speed * controller.moving.x * airSpeedMultiplier);");

			eval("transform.localScale = new Vector3 (forceX > 0 ? 1 : -1, 1, 1);");
		}

		eval("animator.SetInteger ('AnimState', 1);");
	}
	else 
	{
	eval("animator.SetInteger ('AnimState', 0);");
	}
*/



//	((controller.moving.y > 0 && absVelY < maxVelocity.y && (forceY = jetSpeed * controller.moving.y)) && animator.SetInteger ("AnimState", 2) ) || (absVelY > 0 && animator.SetInteger ('AnimState', 3));


	//eval("if(true){Debug.Log('YES!!');}else{Debug.Log('FALSE!!');}");

	eval("if (controller.moving.y > 0){if (absVelY < maxVelocity.y){forceY = jetSpeed * controller.moving.y;}animator.SetInteger ('AnimState', 2);}else if (absVelY > 0) {animator.SetInteger ('AnimState', 3);}");

/*
	if (controller.moving.y > 0)
	{
		if (absVelY < maxVelocity.y) 
		{
			forceY = jetSpeed * controller.moving.y;
		}

		animator.SetInteger ("AnimState", 2);
	}
	else if (absVelY > 0) 
	{
		 eval("animator.SetInteger ('AnimState', 3);");
	}
*/

    eval("forceY = Input.GetKey ('up') && absVelY < maxVelocity.y  ? jetSpeed : forceY ;");

//	if (Input.GetKey ("up")) 
//	{
//		if(absVelY < maxVelocity.y)
//		{
//			forceY = jetSpeed;
//		}
//	}

	
	
	eval("rigidbody2d.AddForce (new Vector2 (forceX, forceY));");
//	eval("GetComponent(Rigidbody2D).AddForce (new Vector2 (forceX, forceY));");
}
