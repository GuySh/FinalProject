using UnityEngine;
using System.Collections;
using System.IO;

public class OtherAvatar : MonoBehaviour {

	// Use this for initialization
	GameObject player;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");

		byte[] bytes = File.ReadAllBytes(Application.persistentDataPath + "/PositiveCopy.png");
		Texture2D texture = new Texture2D(80, 80);
		texture.filterMode = FilterMode.Trilinear;
		texture.LoadImage(bytes);

		//Sprite sprite = Sprite.Create(texture, new Rect(0,0,100, 100), new Vector2(0.5f,0.0f), 1.0f);
		Sprite sprite = Sprite.Create(texture, new Rect(0,0, 80, 80), new Vector2(0,0));
		player.GetComponent<SpriteRenderer>().sprite = sprite;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
