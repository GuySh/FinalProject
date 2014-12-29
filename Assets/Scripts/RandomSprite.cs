using UnityEngine;
using System.Collections;

public class RandomSprite : MonoBehaviour {

	public Sprite[] sprites;
	public string resourceName;
	public int currentsprite = -1;

	// Use this for initialization
	void Start () {
		if (resourceName != "") 
		{
			sprites = Resources.LoadAll<Sprite>(resourceName);

			if(currentsprite == -1)
			{
				currentsprite = Random.Range(0, sprites.Length);
			}
			else if(currentsprite > sprites.Length)
			{
				currentsprite = sprites.Length-1;
			}

			GetComponent<SpriteRenderer>().sprite = sprites[currentsprite]; 
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
