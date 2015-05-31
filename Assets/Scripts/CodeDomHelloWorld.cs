using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Text;
using System;
using System.Reflection;

public class CodeDomHelloWorld : MonoBehaviour {

	string smilyMove = @"
using UnityEngine;
using System.Collections;

public class SmilyMove : MonoBehaviour {


	public float speed; //set the speed value of the main character
	public int jumpHeight; //set the jump height value of the main character

	bool left, right;


	// Use this for initialization
	void Start () {

		speed = 5;				//set the speed
		jumpHeight = 300;		//set the jump height

	}
	
	// Update is called once per frame
	void Update () {


		Movement (); //call the movement function below

		var absVelY = Mathf.Abs (GetComponent<Rigidbody2D>().velocity.y);
		
		if (absVelY == 0)						//Jump by detecting if is touching the ground
		{
			GetComponent<Rigidbody2D>().AddForce (Vector2.up * jumpHeight);			// set the new force values
			
		}
		else
		{

		}
	
	}


	void Movement()
	{
		//Move Right
		if (Input.GetKey (KeyCode.RightArrow) || right) 
		{
			transform.Translate (Vector2.right * speed * Time.deltaTime);		// set the new position
			transform.eulerAngles = new Vector2(0,0); 
		}
		//Move Left
		if (Input.GetKey (KeyCode.LeftArrow) || left) 
		{
			transform.Translate (Vector2.right * speed * Time.deltaTime);		// set the new position
			transform.eulerAngles = new Vector2(0,180); //flip the character on its x axis
		}
	
		
	}


	public void setLeft()		//set the left flag for the touch screen 
	{
		left = true;
	}

	public void setRight()		//set the right flag for the touch screen 
	{
		right = true;
	}

	public void clearLeftRight()		//clear the right and right flag
	{
		left = false;
		right = false;
	}

}


";
	string playerMove = @"using UnityEngine;
						using System.Collections;

public class PlayerMovementtest : MonoBehaviour {


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


	string code = @"
    using System;
	using UnityEngine;

    namespace First
    {
        public class Program : MonoBehaviour 
        {
			void Start () 
			{
			" +
				"Debug.Log (\"Start ()Start ()Start ()CODE_DOM TESTTTTTT!!!\");" 
			+ @"
			}
			
			void Update () 
			{
				"+ "Debug.Log (\"Update ()CODE_DOM !!!\");" + @"
			}
	
        }
    }
";

	string code2 = @"
    using System;
	using UnityEngine;

    namespace First
    {
        public class Program
        {
            public static void Main()
            {
            " +
		"Console.WriteLine(\"Hello, world!\");"
			+ @"
            }
        }
    }
";

	string code1 = @"using UnityEngine;
using System.Collections;
using System;


public class CodeDomHelloWorldTesting : MonoBehaviour {

	// Use this for initialization
	void Start () {
			Debug.Log ('CODE_DOM!!!');

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}";



	// Use this for initialization
	void Start () {
	
		Debug.Log("LOGGER TEST");

		CSharpCodeProvider provider = new CSharpCodeProvider();
		CompilerParameters parameters = new CompilerParameters();

		System.Reflection.Assembly[] assemblies = System.AppDomain.CurrentDomain.GetAssemblies();
		foreach (var A in assemblies)
		{
			if(A.FullName.Contains("PlayerController"))
			{
				Debug.Log("contains contains contains contains contains contains");
			}
			if(A.FullName.Contains("UnityEngine") || A.FullName.Contains("Assembly-CSharp-firstpass"))
			{
				//Debug.Log(A.FullName);
				//Debug.Log(A.Location);
				parameters.ReferencedAssemblies.Add(A.Location);
				/*
				if(A.FullName.Contains("UnityEngine"))
				{
					//Debug.Log("jar:file://" + Application.dataPath + "!/assets/bin/Data/Managed/");
					Debug.Log ("LOOKING FOR : " + "jar:file://" + Application.dataPath + "!/assets/bin/Data/Managed/UnityEngine.dll");
						
					WWW loadFile = new WWW("jar:file://" + Application.dataPath + "!/assets/bin/Data/Managed/UnityEngine.dll");
					while (!loadFile.isDone) {
					}
					Debug.Log (loadFile.url);

					parameters.ReferencedAssemblies.Add("jar:file://" + Application.dataPath + "!/assets/bin/Data/Managed/UnityEngine.dll");
				}
				else
				{
					parameters.ReferencedAssemblies.Add(A.Location);
				}
				*/



			}
		}

		Debug.Log ("AFTER ADDING DLLS");

		//GetAllSubTypesVoid();


		/*
		foreach (System.Reflection.Assembly assemb in AppDomain.CurrentDomain.GetAssemblies())
		{
			//Dbg.Log("refer: {0}", assembly.FullName);
			if( assemb.FullName.Contains("Cecil") || assemb.FullName.Contains("UnityEditor") )
				continue;
			parameters.ReferencedAssemblies.Add(assemb.ToString());
		}
*/
		//parameters.ReferencedAssemblies.Add("UnityEngine.dll");
		//parameters.GenerateInMemory = true;
		//parameters.GenerateExecutable = false;

		Debug.Log ("BEFORE CompilerResults");

		CompilerResults results;
		//results = provider.CompileAssemblyFromSource(parameters, playerMove);
		Modified.Mono.CSharp.CSharpCodeCompiler compi = new Modified.Mono.CSharp.CSharpCodeCompiler ();
		//CompilerResults results = provider.CompileAssemblyFromSource(parameters, code1);
		//results = compi.CompileAssemblyFromSource (parameters, playerMove);
		results = compi.CompileAssemblyFromSource (parameters, smilyMove);


		Debug.Log ("BEFORE results CHECKS");

		if (results.Errors.HasErrors)
		{

			StringBuilder sb = new StringBuilder();
			
			foreach (CompilerError error in results.Errors)
			{
				sb.AppendLine(String.Format("Error ({0}): {1}", error.ErrorNumber, error.ErrorText));
			}
			Debug.Log(sb.ToString());
			//throw new InvalidOperationException(sb.ToString());
		}

		Debug.Log ("AFTER results CHECKS");

		Assembly assembly = results.CompiledAssembly;
		//Type program = assembly.GetType("First.Program");
		Type program = assembly.GetType ("SmilyMove");


		ConstructorInfo programConstructor = program.GetConstructor(Type.EmptyTypes);
		//object programClassObject = programConstructor.Invoke(new object[]{});

		//MethodInfo start = program.GetMethod("Start");

		//Type T = program.Assembly.GetType ();
		//gameObject.AddComponent<T>();
		//Debug.Log (program.Assembly);

		//var t = System.Type.GetType(program.Name);
		//var t = program.Assembly.GetName().FullName;
		//gameObject.AddComponent (t); 

		UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent(gameObject, "Assets/Scripts/CodeDomHelloWorld.cs (136,3)", program.Name);



//		Assembly assembly = results.CompiledAssembly;
//		Type program = assembly.GetType("CodeDomHelloWorldTesting");
//		MethodInfo start = program.GetMethod("Start");

		
		//start.Invoke(programClassObject, null);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static System.Type[] GetAllSubTypes(System.Type aBaseClass)
	{
		var result = new System.Collections.Generic.List<System.Type>();
		System.Reflection.Assembly[] AS = System.AppDomain.CurrentDomain.GetAssemblies();
		foreach (var A in AS)
		{
			System.Type[] types = A.GetTypes();
			foreach (var T in types)
			{
				if (T.IsSubclassOf(aBaseClass))
					result.Add(T);
			}
		}
		return result.ToArray();
	}

	public void GetAllSubTypesVoid()
	{
		var result = new System.Collections.Generic.List<System.Type>();
		System.Reflection.Assembly[] AS = System.AppDomain.CurrentDomain.GetAssemblies();
		foreach (var A in AS)
		{
			System.Type[] types = A.GetTypes();
			foreach (var T in types)
			{
				if(T.Name.Contains("PlayerController"))
				{
					Debug.Log("THE TYPE: " + T.Name + ",THE ASSEMBLY: " + A.FullName);
				}

				//if (T.IsSubclassOf(aBaseClass))
				//{
				//	result.Add(T);
				//	Debug.Log(T.Name);
				//}
			}
		}
	}

}
