using UnityEngine;
using System.Collections;

public class RandomSprite : MonoBehaviour {

	public Sprite[] sprites;
	public string resourceName;			// for sprite sheet
	public int currentsprite = -1;

	// Use this for initialization
	void Start () {
		if (resourceName != "") 
		{
			sprites = Resources.LoadAll<Sprite>(resourceName);		// get all sprites from the chosen sprite sheet	

			if(currentsprite == -1)
			{
				currentsprite = Random.Range(0, sprites.Length);	// get random sprite index
			}
			else if(currentsprite > sprites.Length)
			{
				currentsprite = sprites.Length-1;
			}

			GetComponent<SpriteRenderer>().sprite = sprites[currentsprite]; 	// get the current sprite
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
