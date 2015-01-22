using UnityEngine;
using System.Collections;

public class CustomSerialization : MonoBehaviour
{

	public float health = 100;

	private void Update()
	{
		if(Input.GetKey(KeyCode.Space))
		{
			health -= 10;
		}

		if(Input.GetKey(KeyCode.UpArrow))
		{
			transform.position += Vector3.up * Time.deltaTime * 5;
		}

		if(Input.GetKey(KeyCode.DownArrow))
		{
			transform.position -= Vector3.up * Time.deltaTime * 5;
		}
	}

	private void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
	{
		if (stream.isWriting)
		{
			Vector3 pos1 = transform.position;

			stream.Serialize(ref health);
			stream.Serialize(ref pos1);
		}
		else
		{
			Vector3 pos2 = Vector3.zero;

			stream.Serialize(ref health);
			stream.Serialize(ref pos2);

			transform.position = pos2; 
		}
	}
}
