using UnityEngine;
using System.Collections;
using System;
using Mono.CSharp;

public class MonoCSharpTester : MonoBehaviour {


	string playerMove = @"using UnityEngine;
						using System.Collections;

public class PlayerMovement : MonoBehaviour {


	public float speed = 10f; 							
	public Vector2 maxVelocity = new Vector2(3, 5);		
	public bool standing;
	public float jetSpeed = 15f;
	public float airSpeedMultiplier = .3f;

	private Animator animator;
	public PlayerController controller;


	void Start (){
		controller = GetComponent<PlayerController> ();		// get the PlayerController componnent
		animator = GetComponent<Animator> ();				//// get the Animator componnent
	}

	// Update is called once per frame
	void Update () {
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

		GetComponent<Rigidbody2D>().AddForce (new Vector2 (forceX, forceY));
	}
}
";


	public KeyCode[] m_ShortcutKeys = new KeyCode[]{KeyCode.LeftAlt, KeyCode.F12}; //the keys used to open Console;
	public bool m_IsConsoleOpen = false;
	
	private string m_editstr = "";
	private string m_result = "";
	
	private int m_cmdId = 0; //used to identify cmd

	String method;


	// Use this for initialization
	void Start () {
		Mono.CSharp.Evaluator.Init(new string[] { });

		foreach (System.Reflection.Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
		{
			//Dbg.Log("refer: {0}", assembly.FullName);
			//if( assembly.FullName.Contains("Cecil") || assembly.FullName.Contains("UnityEditor") )
			//	continue;
			Mono.CSharp.Evaluator.ReferenceAssembly(assembly);
		}
		Evaluator.Run ("using UnityEngine;\n" + 
		               "using System;"
		               );

		method = "public void print1(){Debug.Log(\"In print1()!!!\");}";
		//String method = "Debug.Log(\"In Method!!!\");";
		//CompiledMethod c =  Mono.CSharp.Evaluator.Compile (method);


		CompiledMethod c = Evaluator.Compile (playerMove);
		Evaluator.Run ("int x = 0;");
		Evaluator.Run ("Debug.Log(x);");
		Evaluator.Run ("Debug.Log(\"before\");");
		Evaluator.Run ("print1();");

		Evaluator.Run ("print2();");

		//c.DynamicInvoke (new string[] { });

		object o = new int();
		//c.Invoke (ref o);
		if (c == null)
		{
			Debug.Log ("method is null");
		}
		else
		{
			Debug.Log(c.ToString ());
		}

		//Evaluator.Run (method);


//		var evaluator = new Evaluator(
//			new CompilerSettings(),
//			new Report(new ConsoleReportPrinter()));

		m_IsConsoleOpen = true;
	}
	
	void Update() {
		Evaluator.Run ("Debug.Log(x);");
		//check if the console should be opened
		if (m_IsConsoleOpen)
			return;
		
		bool bAllKeysDown = true;
		foreach ( KeyCode kc in m_ShortcutKeys )
		{
			if( !Input.GetKey(kc) )
			{
				bAllKeysDown = false;
				break;
			}
		}
		
		if( bAllKeysDown )
		{
			m_IsConsoleOpen = true;
		}
	}


	
	void OnGUI()
	{
		if (!m_IsConsoleOpen)
			return;
		
		m_editstr = GUI.TextArea(new Rect(10, 10, 400, 100), m_editstr);
		
		if( GUI.Button(new Rect(420, 60, 100, 40), "Execute") )
		{
			++m_cmdId;
			bool bSuccess = Run(m_editstr);
			m_result = string.Format("{0}: {1}", m_cmdId, bSuccess ? "OK" : "Fail");
			m_editstr = ""; //clear the script
		}
		
		if( GUI.Button(new Rect(530, 60, 100, 40), "Close") )
		{
			m_IsConsoleOpen = false;
		}
		
		if (m_result.Length > 0)
		{
			GUI.TextArea(new Rect(420, 10, 200, 30), m_result);
		}
	}

	//public void print(){Debug.Log("In Method!!!");}
	
	public bool Run(string cmd) {
		return Evaluator.Run(cmd);
	}

	public void print2(){Debug.Log("In print2!!!");}
}
