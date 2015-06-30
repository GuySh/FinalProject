#pragma strict

/*	
	<<TESTING TESTING>>
	
	This class is for android devices only
	this class is for running code with the EVAL function
*/


var moving  = new Vector2();	
var up;
var left;
var right;


function Start () {

		up = false;
		left = false;
		right = false;

}

function Update () {

	eval("moving.x = moving.y = 0;");

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

}


function moveUp()			// all the functions below aare for the touch input
{
	up = true;
}

function moveLeft()
{
	left = true;
}

function moveRight()
{
	right = true;
}

function clearUp()
{
	up = false;
}

function clearLeft()
{
	left = false;
}

function clearRight()
{
	right = false;
}
	