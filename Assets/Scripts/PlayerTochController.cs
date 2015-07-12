using UnityEngine;
using System.Collections;

public class PlayerTochController : MonoBehaviour {

	public AllPlayerMovement apm;

	// Use this for initialization
	void Start () 
	{

		if (Application.platform == RuntimePlatform.Android && PlayerInit.mode.Equals(Modes.Regular))
		{
			apm = GetComponent<AllPlayerMovement> ();
		}


	}
	
	// Update is called once per frame
	void Update () {

		if (Application.platform == RuntimePlatform.Android && PlayerInit.mode.Equals(Modes.Regular))
		{
			apm = GetComponent<AllPlayerMovement> ();
		}
	
	}

	public void moveUp()			// all the functions below aare for the touch input
	{
		if (Application.platform == RuntimePlatform.Android && PlayerInit.mode.Equals(Modes.Regular))
		{
			apm.moveUp ();
		}
	
	}
	
	public void moveLeft()
	{	
		if (Application.platform == RuntimePlatform.Android && PlayerInit.mode.Equals(Modes.Regular))
		{
			apm.moveLeft ();
		}

	}
	
	public void moveRight()
	{	
		if (Application.platform == RuntimePlatform.Android && PlayerInit.mode.Equals(Modes.Regular))
		{
			apm.moveRight ();
		}

	}
	
	public void clearUp()
	{		
		if (Application.platform == RuntimePlatform.Android && PlayerInit.mode.Equals(Modes.Regular))
		{
			apm.clearUp ();
		}

	}
	
	public void clearLeft()
	{	
		if (Application.platform == RuntimePlatform.Android && PlayerInit.mode.Equals(Modes.Regular))
		{
			apm.clearLeft ();
		}

	}
	
	public void clearRight()
	{	
		if (Application.platform == RuntimePlatform.Android && PlayerInit.mode.Equals(Modes.Regular))
		{
			apm.clearRight ();
		}

	}
}
