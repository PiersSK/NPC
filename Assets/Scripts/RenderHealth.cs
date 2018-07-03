using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderHealth : MonoBehaviour {
	private int health;

	// Use this for initialization
	void Start () {
		health = PlayerHealth.health;
	}
	
	// Update is called once per frame
	void Update () {
		health = PlayerHealth.health;
		var healthBarTransform = gameObject.transform as RectTransform;
		healthBarTransform.sizeDelta = new Vector2 (health * 36, 72);

	}
}
