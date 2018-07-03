using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxRenderer : MonoBehaviour {
	public GameObject awaitingInput;
	public static bool persistText;
	public static float updateTime;

	private Image textBox;
	private Image inputIndicator;
	private bool textIsDisplayed;
	private static Text infoText;

	// Use this for initialization
	void Start () {
		textBox = gameObject.GetComponent<Image>();
		inputIndicator = GameObject.Find("AwaitingInput").GetComponent<Image>();
		infoText = GameObject.Find("InfoText").GetComponent<Text>();

		updateTime = Time.time;

		textIsDisplayed = false;
		textBox.enabled = false;
		inputIndicator.enabled = false;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(infoText.text != "" && !textIsDisplayed) {
			textBox.enabled = true;
			textIsDisplayed = true;
			inputIndicator.enabled = persistText;
		}

		if(Time.time > updateTime + 1.5f && textIsDisplayed && !persistText) {
			infoText.text = "";
			textBox.enabled = false;
			textIsDisplayed = false;
		}

		// Debug.Log("textIsDisplayed: " + textIsDisplayed);

		if(Time.time > updateTime + 0.5f && textIsDisplayed && persistText && Input.anyKeyDown) {
			infoText.text = "";
			textBox.enabled = false;
			inputIndicator.enabled = false;
			persistText = false;
			textIsDisplayed = false;
		}
	}

	public static void DisplayTextOnUI(string text, bool setPersistText) {
		infoText.text = text;
		updateTime = Time.time;
		persistText = setPersistText;
	}
}
