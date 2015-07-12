using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour {

	public int totalItems = 10;
	public static int items = 0;
	public float remainingTime = 70;
	public float messageTime = 3;

	bool messageTimeUp = false;

	Text timeText;
	Text itemsText;
	Text messageText;
	GameObject go;

	// Use this for initialization
	void Start () {
	
		if (Time.timeScale == 0)
		{
			Time.timeScale = 1;
		}

		items = 0;
		go = GameObject.FindGameObjectWithTag("TimeText");
		timeText = go.GetComponent<Text>();
		go = GameObject.FindGameObjectWithTag("ItemsText");
		itemsText = go.GetComponent<Text>();
		go = GameObject.FindGameObjectWithTag("MessageText");
		messageText = go.GetComponent<Text>();

		messageText.text = "Collect All Items";

	}
	
	// Update is called once per frame
	void Update () {

		itemsText.text = "Items: " + items + "/" + totalItems;

		if (!messageTimeUp)
		{
			if (messageTime > 0) 
			{
				messageTime -= Time.deltaTime;
			} else
			{
				messageText.text = "";
				messageTimeUp = true;
			}
		}


		if (items == totalItems)
		{
			Time.timeScale = 0;
			messageText.text = "Congratulation You Rock!";
		}

		remainingTime -= Time.deltaTime;

		if (remainingTime >= 0)
		{
			timeText.text = "Time: " + (int)remainingTime + "s";

		} 
		else
		{
			Time.timeScale = 0;
			messageText.text = "Game Over";
		}
	}
}
